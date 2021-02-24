using MISA.EMIS.MF734.PVTHANG.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class ServiceResult
    {
        #region Declare
        /// <summary>
        /// Thành công: true|false
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public bool Success { get; set; }

        /// <summary>
        /// Mã code
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public ResultCode Code { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public Object Data { get; set; }

        /// <summary>
        /// Tin nhắn lỗi
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public ErrorMessage ErrorMessage { get; set; }
        #endregion

        #region Constructor
        public ServiceResult()
        {
            this.Success = true;
            this.ErrorMessage = new ErrorMessage();
        }
        #endregion
    }
}
