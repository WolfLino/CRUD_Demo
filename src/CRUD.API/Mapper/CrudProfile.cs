using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Application.Models;

namespace CRUD.API.Mapper
{
    public class CrudProfile : Profile
    {
        public CrudProfile()
        {
            CreateMap<CustomerToCreateDto, CustomerModel>().ReverseMap();
            CreateMap<CustomerDto, CustomerModel>().ReverseMap();
            CreateMap<ViaCepModel, AddressDto>()
                .ForMember(dest => dest.Cep, source => source.MapFrom(source => source.Cep))
                .ForMember(dest => dest.City, source => source.MapFrom(source => source.Localidade))
                .ForMember(dest => dest.Complement, source => source.MapFrom(source => source.Complemento))
                .ForMember(dest => dest.Neighborhood, source => source.MapFrom(source => source.Bairro))
                .ForMember(dest => dest.State, source => source.MapFrom(source => source.Uf))
                .ForMember(dest => dest.Street, source => source.MapFrom(source => source.Logradouro));
        }
    }
}
