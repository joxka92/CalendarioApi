using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.StoredProcedure
{
    public class Stores
    {
        public enum Stores_Names
        {
            SP_GET_DIAS_INHABILES = 1,
            SP_GET_ASESORES = 2,
            SP_GET_EVENTOS_USUARIO = 3,
            SP_GET_ASESORES_TIPO_CITA = 4,
            SP_GET_ASESORES_ASIGNACION = 5,
            SP_GET_CITAS_ASIGNACION = 6,
            SP_GET_CAMBIO_ASIGNACION = 7,
            SP_GET_CITAS_VALIDATE_ASIGNACION = 8,
            SP_GET_CITAS_ASIGNADAS = 9,
            SP_GET_EVIDENCIA = 10,
            SP_INSERT_EVIDENCIA = 11,
            SP_GET_TIPO_CITA_ASESORES = 12,
            SP_DELETE_ADVISER_TYPE_APPOINTMENT = 13,
            SP_GET_BUSQUEDA_CITAS = 14,
            Sp_Get_Report_Concentrado_Asesor = 15,
            Sp_Get_Report_Concentrado_Edad = 16,
            Sp_Get_Report_Concentrado_Estado = 17,
            Sp_Get_Report_Concentrado_Pueblo = 18,
            Sp_Get_Report_Concentrado_Sede = 19,
            Sp_Get_Report_Concentrado_Sexo = 20,
            Sp_Get_Report_Citas = 21,
            SP_DELETE_CITA_ATENCION = 22,
            SP_GET_NOTIFICACION_CALENDARIO_CITAS = 23,
            SP_GET_EVENTOS_SERIADOS = 24,
            SP_UPDATE_NOTIFICACION_CALENDARIO_CITAS = 25,
            SP_VALIDATE_INSERT_EVENT = 26,
            SP_GET_CITAS_ASESOR = 27,
            SP_VALIDATE_UPDATE_EVENT = 28,
            SP_GET_PERIODOS_USER = 29,
            SP_GET_INHABILES = 30


        }
    }
}
