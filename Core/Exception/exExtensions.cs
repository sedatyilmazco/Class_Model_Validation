using Class_Model_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Model_Validation.Core.exException
{
    public static class exReturnModel
    {
        public static ReturnModel ToReturnModel(this Exception ex,string ErrorMessage)
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
    }
}
