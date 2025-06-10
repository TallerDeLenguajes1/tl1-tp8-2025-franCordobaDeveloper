using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class Tarea
    {
        public int TareaID { get; set; }

        public required string Descripcion { get; set; }

        public int Duracion { get; set; }
    }

}