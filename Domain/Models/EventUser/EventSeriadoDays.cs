using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EventUser
{
    public class EventSeriadoDays
    {
        [Key]
        public int Id { get; set; }
        public int Id_Evento_Seriado { get; set; }
        public int Dia { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public virtual EventSeriado Event { get; set; }

    }
}
