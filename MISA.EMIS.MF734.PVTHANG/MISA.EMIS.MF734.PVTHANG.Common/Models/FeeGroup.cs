using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class FeeGroup
    {
        public int FeeGroupID { get; set; }
        public String FeeGroupName { get; set; }
        public bool IsSystem { get; set; }
        public String Description { get; set; }
    }
}
