using Application.DTO.EventUser;
using Application.DTO.EventUser.Request;
using AutoMapper;
using Domain.Models.CalendarUser;
using Domain.Models.EventUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<IEventUserDTO, EventUser>().ReverseMap();
            CreateMap<EventUserStore, EventUserDTO>().ReverseMap();
            CreateMap<TypeEvent, TypeEventDTO>();
            CreateMap<EventSeriadoDaysDTO, EventSeriadoDays>()
                .ReverseMap();
            CreateMap<EventSeriadoDTO, EventSeriado>()
            .ForMember(u => u.Inicio, o => o.MapFrom(z => TimeSpan.Parse(z.Inicio)))
            .ForMember(u => u.Fin, o => o.MapFrom(z => TimeSpan.Parse(z.Fin)))
            .ReverseMap()
            .ForMember(u => u.Inicio, o => o.MapFrom(z =>z.Inicio.ToString(@"hh\:mm")))
            .ForMember(u => u.Fin, o => o.MapFrom(z => z.Fin.ToString(@"hh\:mm")));

            CreateMap<ListEventSerializado, ListEventSerializadoDTO>();
            CreateMap<UserCalendar, UserDTO>()
              .ForMember(u => u.Id_Usuario, o => o.MapFrom(z => z.Id_Empleado)).ForMember(u => u.Id_Usuario, o => o.MapFrom(z => z.Id_Empleado))
                            .ForMember(u => u.Nombre_Completo, o => o.MapFrom(z => z.Nombre));





        }

    }
}
