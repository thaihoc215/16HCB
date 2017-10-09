using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;

namespace QuanLyGiaiBongDa.Common
{
    public class EmailValidator : ValidationRule
    {
        private int _min = 1;
        private int _max = Int32.MaxValue;

        public EmailValidator()
        {
            ValidatesOnTargetUpdated = true;
        }
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = Constants.GetBoundValue(value) as string;
            if (string.IsNullOrEmpty(stringValue))
            {
                //ValidationStep = ValidationStep.UpdatedValue;
                return new ValidationResult(false, "Value cannot be empty.");
            }

            else
            {
                if (!IsValid(stringValue))
                    return new ValidationResult(false, "Not Email adress");

                if (stringValue.Length < Min || stringValue.Length > Max)
                    return new ValidationResult(false, "Value length: " + Min + " - " + Max + ".");
            }
            return ValidationResult.ValidResult;
        }

        private bool IsValid(string emailaddress)
        {
            Regex regex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$");
            return regex.IsMatch(emailaddress);
        }
    }

    public class StringValidator : ValidationRule
    {
        private int _min = 1;
        private int _max = Int32.MaxValue;

        public StringValidator()
        {
            ValidatesOnTargetUpdated = true;
        }
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = Constants.GetBoundValue(value) as string;
            if (string.IsNullOrEmpty(stringValue))
            {
                //ValidationStep = ValidationStep.UpdatedValue;
                return new ValidationResult(false, "Value cannot be empty.");
            }
                
            else
            {
                if (stringValue.Length < Min || stringValue.Length > Max)
                    return new ValidationResult(false, "Value length: " + Min + " - " + Max + ".");
            }
            return ValidationResult.ValidResult;
        }
    }
    
    public class NumberValidator : ValidationRule
    {
        public NumberValidator()
        {
            ValidatesOnTargetUpdated = true;
        }
        private int _min = 1;
        private int _max = Int32.MaxValue;



        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = Constants.GetBoundValue(value) as string;
            if (string.IsNullOrEmpty(stringValue.ToString()))
                return new ValidationResult(false, "Value cannot be empty.");
            else
            {
                int number = 0;
                if (Int32.TryParse(stringValue.ToString(), out number))
                {
                    if(number < Min || number > Max)
                        return new ValidationResult(false, "Value between: " + Min + " - " + Max + ".");
                }
                else
                {
                    return new ValidationResult(false, "Value must be a number.");
                }
               
            }
            return ValidationResult.ValidResult;
        }
    }
}
