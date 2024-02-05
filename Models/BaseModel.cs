using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Model_Validation.Models
{
    public class ReturnModel
    {
    
        public bool Result { get; set; }
        public object Data { get; set; }
        public Exception Exception { get; set; }

        public long? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
