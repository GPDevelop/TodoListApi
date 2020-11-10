using System;
using System.Collections.Generic;

namespace TodoList.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
