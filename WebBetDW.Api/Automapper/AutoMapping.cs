using AutoMapper;
using WebBetDW.Models.DTOs.Bet;
using WebBetDW.Models.DTOs.Match;
using WebBetDW.Models.DTOs.SessionDTO;
using WebBetDW.Models.DTOs.User;
using WebBetDW.Models.Entities;
using WebBetDW.Models.Requests;

namespace WebBetDW.Api.Automapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping(  )
        {
            CreateMap<AccountDTO , Cuenta>().ReverseMap();
            CreateMap<AccountRequest, Cuenta>()
                .ForMember(dest => dest.Idcuenta, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Idcuenta) ? Guid.NewGuid() : Guid.Parse(source.Idcuenta)))
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Rol) ? Guid.Empty : Guid.Parse(source.Rol))).ReverseMap();    
            CreateMap<MatchRequest, Partido>()
                .ForMember(dest => dest.Idpartido, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Idpartido) ? Guid.NewGuid() : Guid.Parse(source.Idpartido)))
                .ForMember(dest => dest.Torneo, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Torneo) ? Guid.NewGuid() : Guid.Parse(source.Torneo)))
                .ForMember(dest => dest.EquipoLocal, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.EquipoLocal) ? Guid.NewGuid() : Guid.Parse(source.EquipoLocal)))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Fecha) ? DateTime.Now : DateTime.Parse(source.Fecha)))
                .ForMember(dest => dest.EquipoVisitante, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.EquipoVisitante) ? Guid.NewGuid() : Guid.Parse(source.EquipoVisitante))).ReverseMap(); 
            CreateMap<SessionRequest, Sesion>()
                .ForMember(dest => dest.Idsesion, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Idsesion) ? Guid.NewGuid() : Guid.Parse(source.Idsesion)))
                .ForMember(dest => dest.Partido, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Partido) ? Guid.NewGuid() : Guid.Parse(source.Partido)))
                .ForMember(dest => dest.Cuenta, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Cuenta) ? Guid.NewGuid() : Guid.Parse(source.Cuenta))).ReverseMap();
            CreateMap<BetRequest, Apuesta>()
                .ForMember(dest => dest.Idapuesta, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Idapuesta) ? Guid.NewGuid() : Guid.Parse(source.Idapuesta)))
                .ForMember(dest => dest.Sesion, opt => opt.MapFrom(source => string.IsNullOrEmpty(source.Sesion) ? Guid.NewGuid() : Guid.Parse(source.Sesion))).ReverseMap();
            CreateMap<BetDTO, Apuesta>().ReverseMap();
            CreateMap<SessionDTO, Sesion>().ReverseMap();
            CreateMap<MatchDTO, Partido>().ReverseMap();
        }

    }
}
