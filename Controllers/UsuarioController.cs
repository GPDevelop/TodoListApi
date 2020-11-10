using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TodoList.Models;
using TodoList.Models.Response;
using TodoList.Models.Request;
using TodoList.Models.ClientRequest;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext()) {
                    var lst = db.Usuario.ToList();
                    oResponse.Result = 1;
                    oResponse.Message = "Listado de Usuario obtenido exitosamente";
                    oResponse.Data = lst;

                    return Ok(oResponse);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }


        [HttpPost]
        public IActionResult Add(UsuarioRequest oUsuarioRequest)
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Nombre = oUsuarioRequest.Nombre;
                    oUsuario.Password = oUsuarioRequest.Password;
                    oUsuario.UserName = oUsuarioRequest.UserName;

                    db.Usuario.Add(oUsuario);
                    db.SaveChanges();

                    oResponse.Result = 1;
                    oResponse.Message = "Usuario agregado exitosamente";

                    return Ok(oResponse);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }


        [HttpPut]
        public IActionResult Edit(UsuarioRequest oUsuarioRequest)
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    Usuario oUsuario = db.Usuario.Find(oUsuarioRequest.Id);
                    oUsuario.Nombre = oUsuarioRequest.Nombre;
                    oUsuario.Password = oUsuarioRequest.Password;
                    oUsuario.UserName = oUsuarioRequest.UserName;

                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResponse.Result = 1;
                    oResponse.Message = "Usuario modificado exitosamente";

                    return Ok(oResponse);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }



        [HttpDelete]
        public IActionResult Delete(UsuarioRequest oUsuarioRequest)
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    Usuario oUsuario = db.Usuario.Find(oUsuarioRequest.Id);
                    db.Usuario.Remove(oUsuario);
                    db.SaveChanges();

                    oResponse.Result = 1;
                    oResponse.Message = "Usuario eliminado exitosamente";

                    return Ok(oResponse);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }

        private IUserService _userService;
        public UsuarioController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autenticar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();

            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                respuesta.Result = 0;
                respuesta.Message = "Usuario o contraseña incorrecto.";

                return BadRequest(respuesta);
            }

            respuesta.Result = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }

    }
}
