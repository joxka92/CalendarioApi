using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser
{
    public class EventUserDTO
    {
        public int Id { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public int Id_Usuario { get; set; }
        public string Color { get; set; }
        public DateTime Fecha { get; set; }
        public bool DiaCompleto { get; set; }

    }
}
