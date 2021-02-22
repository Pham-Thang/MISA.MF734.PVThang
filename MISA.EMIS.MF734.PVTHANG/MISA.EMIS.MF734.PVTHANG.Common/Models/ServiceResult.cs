using MISA.EMIS.MF734.PVTHANG.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public ResultCode Code { get; set; }
        public Object Data { get; set; }
        public ErrorMessage ErrorMessage { get; set; }
        public ServiceResult()
        {
            this.Success = true;
            this.ErrorMessage = new ErrorMessage();
        }
    }
}
