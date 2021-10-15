using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBBABA.Infra.EF;
using WEBBABA.Models.ViewModels;

namespace WEBBABA.Infra.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
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