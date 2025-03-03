using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EventUser
{
    public class TypeEvent
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public bool Activo { get; set; }
        public string Color { get; set; }
    }
}
