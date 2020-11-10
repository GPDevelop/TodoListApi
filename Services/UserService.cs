using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models.Request;
using TodoList.Models.Response;
using TodoList.Models;
using TodoList.Tools;
using TodoList.Models.Utils;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace TodoList.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings )
        {
            _appSettings = appSettings.Value;
        }
        public UserResponseSvr Auth(AuthRequest model)
        {
            UserResponseSvr userResponse = new UserResponseSvr();

            using (var db = new TodoListContext()) {
                string spassword = Encript.GetSHA256(model.Password);

                var usuario = db.Usuario.Where(d => d.UserName == model.UserName && d.Password == spassword).FirstOrDefault();

                if (usuario == null) return null;

                userResponse.userName = usuario.UserName;
                userResponse.token = GetToken(usuario);
            }

            return userResponse;
            
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Hidden);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, usuario.UserName.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
