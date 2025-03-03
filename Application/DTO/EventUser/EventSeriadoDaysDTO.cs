using Domain.Models.EventUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser
{
    public class EventSeriadoDaysDTO
    {
        public int? Id { get; set; }
        public int? Id_Evento_Seriado { get; set; }
        public int Dia { get; set; }
        public bool Checked  { get; set; }
        public string Day { get; set; }
        public DateTime Fecha_Creacion { get { return DateTime.Now; } }

    }
}
