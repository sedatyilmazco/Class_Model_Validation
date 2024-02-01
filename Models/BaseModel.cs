using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Model_Validation.Models
{
    public class ReturnModel
    {
        internal bool _result { get; set; }
        internal long? _errorcode { get; set; }
        internal object _data { get; set; }
        internal string _errormessage { get; set; }
        internal Exception _ex { get; set; }

        public bool Result { get; set; }
        public object Data { get; set; }
        public Exception Exception { get; set; }

        public long? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
