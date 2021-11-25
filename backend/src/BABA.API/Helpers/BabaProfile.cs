using AutoMapper;
using BABA.API.Dto;
using BABA.Domain.Models;

namespace BABA.API.Helpers
{
    public class BabaProfile : Profile
    {
        public BabaProfile()
        {
            CreateMap<Atleta, AtletaDto>();
        }
    }
}