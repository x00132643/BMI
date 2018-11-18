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

    }
}
