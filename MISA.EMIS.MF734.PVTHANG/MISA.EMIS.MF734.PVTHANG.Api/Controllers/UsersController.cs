using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.EMIS.MF734.PVTHANG.Common.Models;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.EMIS.MF734.PVTHANG.Api.Controllers
{
    public class UsersController : BaseEntityController<User>
    {
        IUserService _userService;
        public UsersController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult login(User user)
        {
            var result = _userService.login(user);
            if (result.Success == true)
                return StatusCode(200, result.Data);
            else
                return StatusCode((int)result.Code, result.ErrorMessage);
        }
    }
}
