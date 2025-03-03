using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EventUser
{
    public class UserCalendar
    {
        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha_Ingreso { get; set; }
        public string Dias { get; set; }  
    }
}
