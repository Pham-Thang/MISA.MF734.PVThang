using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class FeeGroup
    {
        /// <summary>
        /// Mã nhóm khoản thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public int? FeeGroupID { get; set; }

        /// <summary>
        /// Tên nhóm khoản thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Tên nhóm khoản thu")]
        [CheckDuplicate("Tên nhóm khoản thu")]
        public String FeeGroupName { get; set; }

        /// <summary>
        /// Là dữ liệu hệ thống: true|false
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Tên nhóm khoản thu")]
        public bool? IsSystem { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [CheckLenght("Mô tả", 255)]
        public String Description { get; set; }
    }
}
