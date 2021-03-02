using MISA.EMIS.MF734.PVTHANG.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Service.Interfaces
{
    public interface IUserService : IBaseService<User>
    {

        ServiceResult login(User user);
    }
}
