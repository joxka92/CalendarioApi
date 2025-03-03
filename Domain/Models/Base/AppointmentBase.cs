using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public abstract class AppointmentBase
    {
        //public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Horario_Id { get; set; }
        public int Genero_Id { get; set; }
        public int Estado_Id { get; set; }
        public int Municipio_Id { get; set; }
        public string Telefono { get; set; }
        public bool Pueblo_Indigena { get; set; }
        public string Edad { get; set; }
        public string Codigo { get; set; }
        public string CodigoCita { get; set; }
        public int Tema_Id { get; set; }
        public string Otro { get; set; }
    }
}
