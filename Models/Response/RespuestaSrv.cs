using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.Response
{
    public class Respuesta
    {
        public int Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Result = 0;
        }
    }
}

