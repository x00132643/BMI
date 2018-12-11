using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BMICalculatorUnitTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BMIUnitTest
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

        [DataRow(5, 0, 7, 1, "Underweight")]
        [DataRow(10, 5, 5, 5, "Normal")]
        [DataRow(14, 0, 6, 0, "Overweight")]
        [DataRow(14, 0, 5, 0, "Obese")]
        [DataTestMethod]
        public void TestBmiCategory(int WeightStones, int WeightPounds, int HeightFeet, int HeightInches, string Output)
        {
            //arrange

            string expectedValue = Output;

            BMI TestBmi = new BMI();
            TestBmi.WeightStones = WeightStones;
            TestBmi.WeightPounds = WeightPounds;
            TestBmi.HeightFeet = HeightFeet;
            TestBmi.HeightInches = HeightInches;




            //act
            string actualValue = TestBmi.BMICategory.ToString();

            //asserrt
            Assert.AreEqual(expectedValue, actualValue);

        }
        [DataRow(5, 0, 7, 1, 0)]
        [DataRow(10, 5, 5, 5, 0)]
        [DataRow(14, 0, 6, 0, 5.62574694400001)]
        [DataRow(14, 0, 5, 0, 31.0718896)]
        [DataTestMethod]
        public void TestBmiWeightToLose(int WeightStones, int WeightPounds, int HeightFeet, int HeightInches, double Output)
        {
            //arrange

            double expectedValue = Math.Round(Output,2);

            BMI TestBmi = new BMI();
            TestBmi.WeightStones = WeightStones;
            TestBmi.WeightPounds = WeightPounds;
            TestBmi.HeightFeet = HeightFeet;
            TestBmi.HeightInches = HeightInches;




            //act
            double actualValue = Math.Round(TestBmi.WeightToLose,2);

            //asserrt
            Assert.AreEqual(expectedValue, actualValue);

        }
    }
}
