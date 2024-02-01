using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Class_Model_Validation.Core.Validation
{
    internal class CoreDataAnnotations
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class TurkishPhoneNumberAttribute : ValidationAttribute
        {
            private const string Pattern = @"^\+905\d{9}$"; 

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return ValidationResult.Success; 
                }

                var phoneNumber = value.ToString();

                if( Regex.IsMatch(phoneNumber, Pattern))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage);
            }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class NonZeroAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null && value is decimal dec)
                {
                    if (value != null && (decimal)dec != 0)
                    {
                        return ValidationResult.Success;
                    }
                }

                if (value != null && value is string str)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        return ValidationResult.Success;
                    }
                }

                if (value != null && (DateTime)value != null)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
