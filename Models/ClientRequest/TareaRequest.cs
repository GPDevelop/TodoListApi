using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.ClientRequest
{
    public class TareaRequest
    {
        public Int64 Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        //public List<Usuario> Usuarios { get; set; }
        //public List<Estado> Estado { get; set; }
    }
}
