
using Application.DTO.EventUser.Request;
using Application.DTO.EventUser;
using Infrastructure.Support;

namespace Application.Services.EventUser
{
    public interface IEventsUser
    {
        Response<bool> InsertEvent(Request_EventUserDTO Request);
        Response<List<EventUserDTO>> GetFilterEvents(Request_FilterCalendarUserDTO Request);
        Response<bool> UpdateEvent(Request_UpdateEventUserDTO Request);
        Response<bool> DeleteEvent(int Id);
        Response<List<TypeEventDTO>> GetTypeEvent();
        Response<bool> InsertEventSeriado(EventSeriadoDTO evento);
        Response<List<ListEventSerializadoDTO>> GetEventSeriados();
        Response<EventSeriadoDTO> GetEventSeriado(int Id);
        Response<bool> UpdateEventSeriado(EventSeriadoDTO evento);
        Response<List<UserDTO>> GetEmpleados();
        Response<List<UserPeriodoDTO>> GetEmpleadoPeriodo(int Id);
        Response<List<InhabilesDTO>> GetInhabiles();
    }
}