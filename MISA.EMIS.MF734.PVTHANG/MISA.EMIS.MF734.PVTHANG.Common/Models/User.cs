using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Common.Models
{
    public class User
    {
        public int? UserId { get; set; }

        [Required("Tên tài khoản")]
        [CheckDuplicate("Tên tài khoản")]
        [CheckLenght("Tên tài khoản", 20)]
        public String Account { get; set; }

        [Required("Mật khẩu")]
        [CheckLenght("Mật khẩu", 16)]
        public String Password { get; set; }

        [Required("Tên người dùng")]
        [CheckLenght("Tên người dùng", 100)]
        public String UserName { get; set; }

        [CheckLenght("Mô tả", 255)]
        public String Description { get; set; }


    }
}
