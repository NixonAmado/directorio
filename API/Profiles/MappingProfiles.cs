using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public  MappingProfiles()
    {
        CreateMap<Person,PersonDto>().ReverseMap();
        CreateMap<PhoneNumber,PhoneNumberDto>().ReverseMap();
    }
}