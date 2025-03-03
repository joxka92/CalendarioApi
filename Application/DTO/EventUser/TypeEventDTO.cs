using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser
{
    public class TypeEventDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public bool Activo { get; set; }
        public string Color { get; set; }
    }
}
