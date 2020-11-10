using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.ClientRequest
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

    }
}
