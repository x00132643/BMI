using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BMIUnitTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class TestBmi
    {
        [DataRow(1, 1, 1, 1)]
        [DataRow(0, 5, 0, 5)]
        [DataRow(5, 5, 5, 5)]
        [DataRow(5, 0, 5, 0)]
        [DataTestMethod]
        public void TestBmiValue(int WeightStones, int WeightPounds, int HeightFeet, int HeightInches)
        {
            //arrange

            const double PoundsToKgs = 0.453592;
            const double InchestoMetres = 0.0254;

            double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
            double totalHeightInInches = (HeightFeet * 12) + HeightInches;
            double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
            double totalHeightInMetres = totalHeightInInches * InchestoMetres;
            double expectedValue = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

            BMI TestBmi = new BMI();
            TestBmi.WeightStones = WeightStones;
            TestBmi.WeightPounds = WeightPounds;
            TestBmi.HeightFeet = HeightFeet;
            TestBmi.HeightInches = HeightInches;




            //act
            double actualValue = TestBmi.BMIValue;

            //asserrt
            Assert.AreEqual(expectedValue, actualValue);

        }
        //UnderWeightUpperLimit = 18.4;              // inclusive upper limit
        //NormalWeightUpperLimit = 24.9;
        //OverWeightUpperLimit = 29.9;
        [DataRow(18.4, "Underweight")]
        [DataRow(24.9, "Normal")]
        [DataRow(29.9, "Overweight")]
        [DataRow(30, "Obese")]
        [DataTestMethod]
        public void TestBmiCategory(double bmi, string output)
        {
            //arrange

            BMI TestCategory = new BMI();

            TestCategory.BMIValue = bmi;
            string expectedValue = output;

            //act
            string actualValue = TestCategory.BMICategory.ToString();

            //asserrt
            Assert.AreEqual(expectedValue, actualValue);

        }
    }
}
