using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class Fee
    {
        /// <summary>
        /// Mã Khoản thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public int? FeeID { get; set; }

        /// <summary>
        /// Tên khoản thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Tên khoản thu")]
        [CheckDuplicate("Tên khoản thu")]
        [CheckLenght("Tên khoản thu", 100)]
        public String FeeName { get; set; }

        /// <summary>
        /// Mã nhóm khoản thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public int? FeeGroupID { get; set; }

        /// <summary>
        /// Mức thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Mức thu")]
        public int? Price { get; set; }

        /// <summary>
        /// Đơn vị
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Đơn vị")]
        public int? Unit { get; set; }

        /// <summary>
        /// Phạm vi thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Phạm vi thu")]
        [CheckLenght("Phạm vi thu", 50)]
        public String ApplyObject { get; set; }

        /// <summary>
        /// Tính chất
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public int? Property { get; set; }

        /// <summary>
        /// Kỳ thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Kỳ thu")]
        public int? Period { get; set; }

        /// <summary>
        /// Áp dụng miễn giảm
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Áp dụng miễn giảm")]
        public bool? IsApplyRemisson { get; set; }

        /// <summary>
        /// Khoản thu bắt buộc
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Khoản thu bắt buộc")]
        public bool? IsRequire { get; set; }

        /// <summary>
        /// Cho phép xuất hóa đơn
        /// </summary> 
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Cho phép xuất hóa đơn")]
        public bool? AllowCreateInvoice { get; set; }

        /// <summary>
        /// Cho phép xuất chứng từ
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Cho phép xuất chứng từ")]
        public bool? AllowCreateReceipt { get; set; }

        /// <summary>
        /// Theo dõi
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Theo dõi")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Cho phép hoàn trả
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Cho phép hoàn trả")]
        public bool? IsInternal { get; set; }

        /// <summary>
        /// Dữ liệu hệ thống
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        [Required("Dữ liệu hệ thống")]
        public bool? IsSystem { get; set; }

        /// <summary>
        /// Tên nhóm khoản thu
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public String FeeGroupName { get; set; }

    }
}
