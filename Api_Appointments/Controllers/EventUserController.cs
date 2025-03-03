
using Application.DTO.EventUser.Request;
using Application.Services.EventUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Appointments.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventUserController : ControllerBase
    {
        private readonly IEventsUser _event;

        public EventUserController(IEventsUser eventuser)
        {
            _event = eventuser;
        }

        [HttpPost]
        [Route("InsertEvent")]
        public IActionResult InsertEvent(Request_EventUserDTO Request)
        {
            return Ok(_event.InsertEvent(Request));
        }

        [HttpPost]
        [Route("UpdateEvent")]
        public IActionResult UpdateEvent(Request_UpdateEventUserDTO Request)
        {
            return Ok(_event.UpdateEvent(Request));
        }

        [HttpPost]
        [Route("DeleteEvent")]
        public IActionResult DeleteEvent([FromBody] int Id)
        {
            return Ok(_event.DeleteEvent(Id));
        }

        [HttpPost]
        [Route("FilterEvent")]
        public IActionResult FilterEvent(Request_FilterCalendarUserDTO Request)
        {
            return Ok(_event.GetFilterEvents(Request));
        }

        [HttpPost]
        [Route("GetTypeEvent")]
        public IActionResult GetTypeEvent()
        {
            return Ok(_event.GetTypeEvent());
        }

        [HttpPost]
        [Route("InsertEventSeriado")]
        public IActionResult InsertEventSeriado(EventSeriadoDTO evento)
        {
            return Ok(_event.InsertEventSeriado(evento));
        }

        [HttpPost]
        [Route("GetEventosSeriados")]
        public IActionResult GetEventosSeriados()
        {
            return Ok(_event.GetEventSeriados());
        }

        [HttpPost]
        [Route("GetEventoSeriado")]
        public IActionResult GetEventoSeriado([FromBody] int Id)
        {
            return Ok(_event.GetEventSeriado(Id));
        }

        [HttpPost]
        [Route("UpdateEventoSeriado")]
        public IActionResult UpdateEventoSeriado(EventSeriadoDTO evento)
        {
            return Ok(_event.UpdateEventSeriado(evento));
        }

        [HttpPost]
        [Route("GetAdviserUser")]
        public IActionResult GetEmpleados()
        {
            return Ok(_event.GetEmpleados());
        }


    }
}
