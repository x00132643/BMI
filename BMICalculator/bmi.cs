﻿// model classes for BMI calculator
// GC

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BMICalculator
{
    public enum BMICategory { Underweight, Normal, Overweight, Obese };
    

    public class BMI
    {
        
        const double UnderWeightUpperLimit = 18.4;              // inclusive upper limit
        const double NormalWeightUpperLimit = 24.9;
        const double OverWeightUpperLimit = 29.9;               // Obese from 30 +

        // conversion factors from imperial to metric
        const double PoundsToKgs = 0.453592;
        const double InchestoMetres = 0.0254;

        [Display(Name = "Weight - Stones")]
        [Range(5, 50, ErrorMessage = "Stones must be between 5 and 50")]                              // max 50 stone
        public int WeightStones { get; set; }

        [Display(Name = "Pounds")]
        [Range(0, 13, ErrorMessage = "Pounds must be between 0 and 13")]                              // 14 lbs in a stone
        public int WeightPounds { get; set; }

        [Display(Name = "Height - Feet")]
        [Range(4, 7, ErrorMessage = "Feet must be between 4 and 7")]                               // max 7 feet
        public int HeightFeet { get; set; }

        [Display(Name = "Inches")]
        [Range(0, 11, ErrorMessage = "Inches must be between 0 and 11")]                              // 12 inches in a foot
        public int HeightInches { get; set; }

        public static double totalWeightInKgs;
        public static double totalHeightInMetres;
        public static string BMICat;

        // calculate BMI, display to 2 decimal places
        [Display(Name = "Your BMI is")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BMIValue
        {
            get
            {
                // bmi = weight in Kgs / height in metres squared

                double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
                double totalHeightInInches = (HeightFeet * 12) + HeightInches;

                // do conversions to metric
                double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
                double totalHeightInMetres = totalHeightInInches * InchestoMetres;

                double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
                BMI.totalWeightInKgs = totalWeightInKgs;
                BMI.totalHeightInMetres = totalHeightInMetres;

                return bmi;
            }
        }

        // calculate BMI category 
        [ExcludeFromCodeCoverage]
        [Display(Name = "Your BMI Category is")]
        public BMICategory BMICategory
        {
            get
            {
                double bmi = this.BMIValue;

                // calculate BMI category based on upper limits
                if (bmi <= UnderWeightUpperLimit)
                {
                    BMI.BMICat = "Underweight";
                    return BMICategory.Underweight;
                }
                else if (bmi <= NormalWeightUpperLimit)
                {
                    BMI.BMICat = "Normal";
                    return BMICategory.Normal;
                }
                else if (bmi <= OverWeightUpperLimit)
                {
                    BMI.BMICat = "Overweight";
                    return BMICategory.Overweight;
                }
                else
                {
                    BMI.BMICat = "Obese";
                    return BMICategory.Obese;
                }
            }
        }
        [Display(Name = "You need to loose (KGs):")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double Overweight
        {
            get
            {
                double correctWeight;
                
                double Nbmi = 24.9;
                

                //BMICategory bmiCat = BMICategory;
                if (BMI.BMICat.Equals("Obese")|| BMI.BMICat.Equals("Overweight"))
                {
                    double totalWeightForNormalCategory = Nbmi * (Math.Pow(BMI.totalHeightInMetres, 2));
                    correctWeight = BMI.totalWeightInKgs - totalWeightForNormalCategory;
                    return correctWeight;

                }
                else return 0;
            }
        }
    }
}
