using AutoMapper;
using BABA.Application.Dto;
using BABA.Domain.Models;

namespace BABA.Application.Helpers
{
    public class BabaProfile : Profile
    {
        public BabaProfile()
        {
            CreateMap<Atleta, AtletaDto>();
        }
    }
}