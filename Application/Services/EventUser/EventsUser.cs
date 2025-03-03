using Application.DTO;
using Application.DTO.EventUser;
using Application.DTO.EventUser.Request;
using Application.Services.Executor;
using Application.Support;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Models;
using Domain.Models.CalendarUser;
using Domain.Models.EventUser;
using Infrastructure.Services.GenericRepository;
using Infrastructure.Services.StoredProcedure;
using Infrastructure.Services.UnitOfWork;
using Infrastructure.Support;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph.Models.TermStore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using static Infrastructure.Services.StoredProcedure.Stores;

namespace Application.Services.EventUser
{
    public class EventsUser : IEventsUser
    {
        private readonly IExecutor _executor;
        private readonly IMapper _mapper;
        private readonly IGenericRepository _unitOfWork;
        private readonly IStoredProcedure _storedProcedure;
        private readonly IHttpContextAccessor _httpContext;

        public EventsUser(
            IExecutor executor,
            IMapper mapper,
            IGenericRepository unitOfWork,
            IStoredProcedure storedProcedure,
            IHttpContextAccessor httpContext)
        {
            _executor = executor;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _storedProcedure = storedProcedure;
            _httpContext = httpContext;
        }

        public Response<bool> InsertEvent(Request_EventUserDTO Request)
        {
            return _executor.SafeExecutor(() =>
            {


                var result = _storedProcedure.Execute(
                 Enum.GetName(typeof(Stores_Names), Stores_Names.SP_VALIDATE_INSERT_EVENT),
                $"'{Request.Inicio:yyyy-MM-dd}'", $"'{Request.Fin:yyyy-MM-dd}'", Request.Id_Usuario);

                while (Request.Inicio <= Request.Fin)
                {

                    var obj = new IEventUserDTO(Request, Request.Inicio);

                    Domain.Models.EventUser.EventUser eventUser = _mapper.Map<Domain.Models.EventUser.EventUser>(obj);
                    eventUser.Id_Usuario_Creacion = 0;
                    eventUser.Fecha_Creacion = DateTime.Now;
                    eventUser.Activo = true;
                    _unitOfWork.Add(eventUser);
                    Request.Inicio = Request.Inicio.AddDays(1);
                }


                return true;
            });
        }

        
        public Response<bool> UpdateEvent(Request_UpdateEventUserDTO Request)
        {
            return _executor.SafeExecutor(() =>
            {
               
                Domain.Models.EventUser.EventUser eventUser = _unitOfWork.Get<Domain.Models.EventUser.EventUser>(Request.Id);

                eventUser.Descripcion = Request.Descripcion;
                eventUser.Fecha = Request.Fecha;
                eventUser.Id_Usuario = Request.Id_Usuario;
                eventUser.Id_Tipo_Evento = Request.Id_Tipo_Evento == 0 ? eventUser.Id_Tipo_Evento: Request.Id_Tipo_Evento;
                _unitOfWork.Update<Domain.Models.EventUser.EventUser>(eventUser, null); 
                return true;
            });
        }

        public Response<bool> DeleteEvent(int Id)
        {
            return _executor.SafeExecutor(() =>
            {
                Domain.Models.EventUser.EventUser eventUser = _unitOfWork.Get<Domain.Models.EventUser.EventUser>(Id);
                _unitOfWork.Delete<Domain.Models.EventUser.EventUser>(eventUser);
                return true;
            });
        }

        public Response<List<EventUserDTO>> GetFilterEvents(Request_FilterCalendarUserDTO Request)
        {
            return _executor.SafeExecutor(() =>
            {

                if((Request.Fin- Request.Inicio  ).TotalDays <= 1)
                {
                    Request.Fin = Request.Inicio;
                }
                var result = _storedProcedure.GetCollection<EventUserStore>(
                    Enum.GetName(typeof(Stores_Names), Stores_Names.SP_GET_EVENTOS_USUARIO),
                   $"'{Request.Inicio:yyyy-MM-dd}'", $"'{Request.Fin:yyyy-MM-dd}'").ToList();
                
                var list = _mapper.Map<List<EventUserDTO>>(result);
                return list;
            });
        }

        public Response<List<TypeEventDTO>> GetTypeEvent()
        {
            return _executor.SafeExecutor(() =>
            {
                var list =  _unitOfWork.GetCollection<TypeEvent>();
                return _mapper.Map<List<TypeEventDTO>>(list);
            });
        }
        public Response<bool> InsertEventSeriado(EventSeriadoDTO evento)
        {
            return _executor.SafeExecutor(() =>
            {
                var res = _mapper.Map<EventSeriado>(evento);
                res.Fecha_Creacion = DateTime.Now;
                res.Id_Usuario_Creacion = 0;
                _unitOfWork.Add(res);
                return true;
            });
        }

        public Response<List<ListEventSerializadoDTO>> GetEventSeriados()
        {
            return _executor.SafeExecutor(() =>
            {
                var result = _storedProcedure.GetCollection<ListEventSerializado>(
                 Enum.GetName(typeof(Stores_Names), Stores_Names.SP_GET_EVENTOS_SERIADOS));
                var list = _mapper.Map<List<ListEventSerializadoDTO>>(result);
                return list;
            });
        }
       
        public Response<EventSeriadoDTO> GetEventSeriado(int Id)
        {
            return _executor.SafeExecutor(() =>
            {
                var result = _unitOfWork.Get<EventSeriado>(Id);
                return _mapper.Map<EventSeriadoDTO>(result);
            });
        }

        public Response<bool> UpdateEventSeriado(EventSeriadoDTO evento)
        {
            return _executor.SafeExecutor(() =>
            {
                EventSeriado eventoBD = _mapper.Map<EventSeriado>(evento);               
                _unitOfWork.Update<EventSeriado>(eventoBD,null);
                var result = _unitOfWork.GetCollectionFiltered<EventSeriadoDays>(u=>u.Id_Evento_Seriado == evento.Id);
                List<EventSeriadoDays> ids = result.Where(p => !evento.Dias.Any(p2 => p2.Dia == p.Dia)).ToList();
                foreach (var item in ids)
                {
                    _unitOfWork.Delete(_unitOfWork.Get<EventSeriadoDays>(item.Id));
                }

                return true;
            });
        }


        public Response<List<UserDTO>> GetEmpleados()
        {
            return _executor.SafeExecutor(() =>
            {
                var result = _storedProcedure.GetCollection<UserCalendar>(
                    Enum.GetName(typeof(Stores_Names), Stores_Names.SP_GET_ASESORES));

                var list = _mapper.Map<List<UserDTO>>(result);
                return list;
            });
        }

    }
}
