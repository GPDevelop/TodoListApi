using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models.Request;
using TodoList.Models.Response;

namespace TodoList.Services
{
    public interface IUserService
    {
        UserResponseSvr Auth(AuthRequest model);
    }
}
