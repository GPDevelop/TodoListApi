using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Models.Response;
using TodoList.Models.ClientRequest;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    var lst = db.Tarea.Include("Usuario").Include("Estado").ToList();
                    oResponse.Result = 1;
                    oResponse.Message = "Listado de Tareas obtenido exitosamente";
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
        public IActionResult Add(TareaRequest oTareaRequest)
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    Tarea oTarea = new Tarea();
                    oTarea.Nombre = oTareaRequest.Nombre;
                    oTarea.IdUsuario = oTareaRequest.IdUsuario;
                    oTarea.IdEstado = oTareaRequest.IdEstado;
                    oTarea.Descripcion = oTareaRequest.Descripcion;

                    db.Tarea.Add(oTarea);
                    db.SaveChanges();

                    oResponse.Result = 1;
                    oResponse.Message = "Tarea agregada exitosamente";

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
        public IActionResult Edit(TareaRequest oTareaRequest)
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    Tarea oTarea = db.Tarea.Find(oTareaRequest.Id);
                    oTarea.Nombre = oTareaRequest.Nombre;
                    oTarea.IdUsuario = oTareaRequest.IdUsuario;
                    oTarea.IdEstado = oTareaRequest.IdEstado;
                    oTarea.Descripcion = oTareaRequest.Descripcion;

                    db.Entry(oTarea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResponse.Result = 1;
                    oResponse.Message = "Tarea modificada exitosamente";

                    return Ok(oResponse);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }



        [HttpDelete("{Id}")]
        public IActionResult Delete(Int64 Id)
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    Tarea oTarea = db.Tarea.Find(Id);
                    db.Tarea.Remove(oTarea);
                    db.SaveChanges();

                    oResponse.Result = 1;
                    oResponse.Message = "Tarea eliminada exitosamente";

                    return Ok(oResponse);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }

    }
}
