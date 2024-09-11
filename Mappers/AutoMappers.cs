using AutoMapper;
using Web_Api_JWT.Models;
using Web_Api_JWT.Models.DTOs;

namespace Web_Api_JWT.Mappers
{
    public class AutoMappers:Profile
    {
        public AutoMappers()
        {
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
