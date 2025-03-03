using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EventUser
{
    public class EventSeriado
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Usuario_Creacion { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public virtual Collection<EventSeriadoDays> Dias { get; set; }
    }
}
