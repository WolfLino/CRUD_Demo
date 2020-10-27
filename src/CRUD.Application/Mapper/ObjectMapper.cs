using AutoMapper;
using CRUD.Application.Models;
using CRUD.Core.Entities;
using System;

namespace CRUD.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<CustomerDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class CustomerDtoMapper : Profile
    {
        public CustomerDtoMapper()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }
    }
}
