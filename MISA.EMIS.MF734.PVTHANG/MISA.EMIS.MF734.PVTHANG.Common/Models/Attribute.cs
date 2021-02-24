using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class Attribute
    {
    }

    /// <summary>
    /// Bắt buộc
    /// </summary>
    /// Created by Phạm Việt Thắng (22/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : System.Attribute
    {
        public String propertyName;
        public String errorMessage;
        public Required(String propertyName, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }

    /// <summary>
    /// Không được trùng
    /// </summary>
    /// Created by Phạm Việt Thắng (22/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : System.Attribute
    {
        public String propertyName;
        public String errorMessage;
        public CheckDuplicate(String propertyName, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }

    /// <summary>
    /// Độ dài tối đa
    /// </summary>
    /// Created by Phạm Việt Thắng (22/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckLenght : System.Attribute
    {
        public String propertyName;
        public int maxSize;
        public String errorMessage;
        public CheckLenght(String propertyName, int maxSize, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
            this.maxSize = maxSize;
        }
    }
}
