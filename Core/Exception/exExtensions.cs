using Class_Model_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Model_Validation.Core.CoreExtensions
{
    public static class CoreReturnModel
    {
        public static ReturnModel ToReturnModel(this Exception ex,string ErrorMessage)
        {
            try
            {
                return new ReturnModel
                {
                    Result = false,
                    Data = null,
                    Exception = ex,
                    ErrorCode = 0,
                    ErrorMessage = ErrorMessage,
                };
            }
            catch (Exception exerr)
            {
                return exerr.ToReturnModel("Hata");
            }
        }
        public static ReturnModel ToReturnModel(this ReturnModel obj, string ErrorMessage=null)
        {
            try
            {
                return new ReturnModel
                {
                    Result = obj.Result,
                    Data = obj.Data,
                    Exception = obj.Exception,
                    ErrorCode = obj.ErrorCode,
                    ErrorMessage = obj.ErrorMessage,
                };
            }
            catch (Exception ex)
            {
                return ex.ToReturnModel(ErrorMessage);
            }
        }
    }
}
