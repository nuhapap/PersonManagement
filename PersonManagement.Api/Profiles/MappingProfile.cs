using AutoMapper;
using PersonManagement.Api.Models;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.Data.Contracts.Entities;

namespace PersonManagement.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapsBetweenBusinessAndApi();
            CreateMapsBetweenDataAndBusiness();
        }
        
        private void CreateMapsBetweenBusinessAndApi()
        {
            CreateMap<PersonDto, PersonModel>().ForMember(
                x => x.Color, opt => opt.MapFrom(src => src.Color.Name));
            CreateMap<PersonModel, PersonDto>().ForMember(
                x => x.Color, opt => opt.Ignore());
        }

        private void CreateMapsBetweenDataAndBusiness()
        {
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<ColorDto, Color>().ReverseMap();
        }
    }
}