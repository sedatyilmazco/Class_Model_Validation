using Class_Model_Validation.Core.CoreExtensions;
using Class_Model_Validation.Core.CoreValidatorService;
using Class_Model_Validation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Model_Validation.Core.CoreValidation
{
    public static class CoreModelExtensions
    {

        public static ReturnModel Validate<T>(this T model) where T : class
        {
            return ValidatorService.ValidateModel(model);
        }

        public static ReturnModel Validate<T>(this List<T> model) where T : class
        {
            return ValidatorService.ValidateModel(model);
        }
    }

}

namespace Class_Model_Validation.Core.CoreValidatorService
{

    internal static class ValidatorService
    {

        internal static ReturnModel ValidateModel<T>(this List<T> models)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var errors = new List<string>();

                foreach (var model in models)
                {
                    var context = new ValidationContext(model, serviceProvider: null, items: null);
                    bool isValid = Validator.TryValidateObject(model, context, validationResults, true);

                    if (!isValid)
                    {
                        errors.AddRange(validationResults.Select(result => result.ErrorMessage));
                    }
                }

                if (errors.Count == 0)
                {
                    return new ReturnModel { Result = true };
                }
                else
                {
                    return new ReturnModel
                    {
                        Data = errors.Select(e => $"Hata Mesajı: {e}"),
                        Result = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return ex.ToReturnModel("Veri dorğulamada hata oluştu!");
            }
        }

        internal static ReturnModel ValidateModel<T>(T model)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(model, serviceProvider: null, items: null);
                bool isValid = Validator.TryValidateObject(model, context, validationResults, true);

                if (isValid)
                {
                    return new ReturnModel { Result = true };
                }
                else
                {
                    var errors = validationResults
                    .Select(result => new { Message = result.ErrorMessage })
                    .ToList();

                    return new ReturnModel
                    {
                        Data = errors.Select(e => $"Hata Mesajı: {e.Message}"),
                        Result = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return ex.ToReturnModel("Veri dorğulamada hata oluştu!");

            }
        }
    }
}