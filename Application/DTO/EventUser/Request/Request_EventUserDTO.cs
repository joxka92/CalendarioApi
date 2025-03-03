using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.EventUser.Request
{
    public class Request_EventUserDTO
    {
        public int Id { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

    }

    public class Request_UpdateEventUserDTO
    {
        public int Id { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha { get; set; }

    }


    public class IEventUserDTO
    {
        public int Id { get; set; }
        public int Id_Tipo_Evento { get; set; }
        public string Descripcion { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha { get; set; }


        public IEventUserDTO(Request_EventUserDTO request, DateTime inicio)
        {
            this.Id_Tipo_Evento = request.Id_Tipo_Evento;
            this.Descripcion = request.Descripcion;
            this.Fecha = inicio;
            this.Id_Usuario = request.Id_Usuario;
            
        }
    }


}
