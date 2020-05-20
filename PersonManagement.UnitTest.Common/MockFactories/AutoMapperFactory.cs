using AutoMapper;
using PersonManagement.Api.Profiles;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class AutoMapperFactory
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}