using AutoMapper;
using CRUD.API.DTOs;
using CRUD.Application.Models;

namespace CRUD.API.Mapper
{
    public class CrudProfile : Profile
    {
        public CrudProfile()
        {
            CreateMap<CustomerToCreateDto, CustomerModel>().ReverseMap();
            CreateMap<CustomerDto, CustomerModel>().ReverseMap();
        }
    }
}
