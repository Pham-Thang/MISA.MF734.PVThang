using Microsoft.IdentityModel.Tokens;
using MISA.EMIS.MF734.PVTHANG.Common.Models;
using MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Service.Classes
{
    public class UserService : BaseService<User>, IUserService
    {
        #region Constructor
        public UserService(IUserConnector userConnector) : base(userConnector)
        {

        }
        #endregion

        #region
        public ServiceResult login(User user)
        {
            var sqlCommand = $"SELECT * FROM User WHERE Account = '{user.Account}' AND Password = '{user.Password}';";
            var res = _dbConnector.GetFirst<User>(sqlCommand, new { }, System.Data.CommandType.Text);
            if (res != null)
            {
                _serviceResult.Code = Common.Enum.ResultCode.Ok;
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var tokenOptions = new JwtSecurityToken
                    (
                        issuer: "https://localhost:60931",
                        audience: "https://localhost:60931",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                _serviceResult.Data = new
                {
                    Token = tokenString
                };
            } else
            {
                _serviceResult.Success = false;
                _serviceResult.Code = Common.Enum.ResultCode.Ok;
                _serviceResult.ErrorMessage.UserMessage = Common.Properties.Resources.ErrorLogin;
            }
            return _serviceResult;
        }
        #endregion
    }
}
