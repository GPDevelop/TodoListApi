using System;
using System.Collections.Generic;

namespace TodoList.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
