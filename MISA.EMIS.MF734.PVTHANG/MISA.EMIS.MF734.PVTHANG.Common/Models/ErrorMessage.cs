using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class ErrorMessage
    {
        public String DevMessage { get; set; }
        public String UserMessage { get; set; }
        public String MoreInfo { get; set; }
        public String ErrorCode { get; set; }
        public String TraceId { get; set; }
    }
}
