using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class Fee
    {
        public int FeeID { get; set; }

        [Required("Tên khoản thu")]
        [CheckDuplicate("Tên khoản thu")]
        public String FeeName { get; set; }
        public int? FeeGroupID { get; set; }

        [Required("Mức thu")]
        public int Price { get; set; }

        [Required("Đơn vị")]
        public int Unit { get; set; }

        [Required("Phạm vi thu")]
        public String ApplyObject { get; set; }
        public int Property { get; set; }

        [Required("Kỳ thu")]
        public int Period { get; set; }
        public bool IsApplyRemisson { get; set; }
        public bool IsRequire { get; set; }
        public bool AllowCreateInvoice { get; set; }
        public bool AllowCreateReceipt { get; set; }
        public bool IsActive { get; set; }
        public bool IsInternal { get; set; }
        public bool IsSystem { get; set; }
        public String FeeGroupName { get; set; }

    }
}
