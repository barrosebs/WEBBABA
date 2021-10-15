using AutoMapper;
using WEBBABA.Infra.EF;
using WEBBABA.Models.ViewModels;

namespace WEBBABA.Infra.Automapper
{
    public class AutoMapperConfig
    {

        public static void RegisterMappings()
        {

            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });

        }
    }

}