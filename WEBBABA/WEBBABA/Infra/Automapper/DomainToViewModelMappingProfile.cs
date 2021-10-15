using AutoMapper;
using WEBBABA.Infra.EF;
using WEBBABA.Models.ViewModels;

namespace WEBBABA.Infra.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AtletaModel, TBAtleta>();
            CreateMap<CategoriaModel, TBCategoria>();
            CreateMap<MensalidadeModel, TBMensalidade>();
            CreateMap<RegistroModel, TBRegistro>();
            CreateMap<SituacaoModel, TBSituacao>();
            CreateMap<TipoPagamentoModel, TBTipoPagamento>();
        }

    }
}