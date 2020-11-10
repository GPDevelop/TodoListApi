using System;
using System.Collections.Generic;

namespace TodoList.Models
{
    public partial class Tarea
    {
        public long Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
