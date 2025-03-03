using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser
{
    public class ListEventSerializadoDTO
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string Nombre_Completo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Periodo { get; set; }
        public string Tiempo { get; set; }
        public string Dias { get; set; }
    }
}
