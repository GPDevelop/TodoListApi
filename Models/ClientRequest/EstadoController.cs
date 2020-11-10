using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TodoList.Models.Response;

namespace TodoList.Models.ClientRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oResponse = new Respuesta();

            try
            {
                using (TodoListContext db = new TodoListContext())
                {
                    var lst = db.Estado.ToList();
                    oResponse.Result = 1;
                    oResponse.Message = "Listado de Estados obtenido exitosamente";
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

    }
}
