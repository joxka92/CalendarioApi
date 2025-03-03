using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser
{
    public class UserDTO
    {
        public int Id_Usuario { get; set; }
        public string Nombre_Completo { get; set; }
        public DateTime? Fecha_Ingreso { get; set; }
        public string Dias { get; set; }
    }
}
