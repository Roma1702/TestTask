using AutoMapper;
using DataAccessLayer.DTO;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Mapper
{
    internal class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Age,  
                opt => opt.MapFrom(src => (DateTimeOffset.Now.DayOfYear < src.BirthDate.DayOfYear) ?
                (DateTimeOffset.Now.Year - src.BirthDate.Year) - 1 : ((DateTimeOffset.Now.Year - src.BirthDate.Year))));

            CreateMap<ShortPersonDto, Person>().ReverseMap();
        }
    }
}
