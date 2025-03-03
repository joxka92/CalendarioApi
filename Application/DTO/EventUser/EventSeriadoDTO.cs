using Domain.Models.EventUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser.Request
{
    public class EventSeriadoDTO
    {
        public int? Id { get; set; }
        public int Id_Usuario { get; set; }
        public int? Id_Usuario_Creacion { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public bool Activo { get { return true; } }
        public DateTime? Fecha_Creacion { get; set; }
        public List<EventSeriadoDaysDTO> Dias { get; set; }
    }
}
