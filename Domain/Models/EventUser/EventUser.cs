using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EventUser
{
    public class EventUser
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Year { get; set; }
        public bool Activo { get; set; }

    }

}