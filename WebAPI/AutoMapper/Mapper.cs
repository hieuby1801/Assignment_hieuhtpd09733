
using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Combo, ComboDto>().ReverseMap();
            CreateMap<ComboDetail, ComboDetailDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<FoodCategory, FoodCategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<PersonalProfile, PersonalProfileDto>().ReverseMap();
        }
    }
}
