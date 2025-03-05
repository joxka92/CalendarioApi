using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EventUser
{
    public class UserPeriodo
    {
        public int Id { get; set; }
        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
