using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class ErrorMessage
    {
        /// <summary>
        /// Thông báo cho lập trình viên
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public String DevMessage { get; set; }

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public String UserMessage { get; set; }

        /// <summary>
        /// Thông tin khác
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public String MoreInfo { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public String ErrorCode { get; set; }

        public String TraceId { get; set; }
    }
}
