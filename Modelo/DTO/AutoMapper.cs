using AutoMapper;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Modelo.DTO
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Donador, DonadorDTO>().ReverseMap();
            CreateMap<DonacionUrgente, DonacionUrgenteDTO>().ReverseMap();
            CreateMap<Cita, CitaDTO>().ReverseMap();
            CreateMap<TipoDonacion, TipoDonacionDTO>().ReverseMap();
        }
    }
}
