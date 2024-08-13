using AutoMapper;
using DataAccess.Identity;
using Entity.Entities;
using Entity.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<AppUser, CustomerViewModel>()
    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    .ReverseMap();
            CreateMap<Customer, CustomerViewModel>()
    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))    
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    .ReverseMap();


            CreateMap<Category, CategoryViewModel>().ReverseMap();           
            CreateMap<BookRent, BookRentViewModel>().ReverseMap();
            CreateMap<BookRentDetail, BookRentDetailViewModel>().ReverseMap();
            
            
        }





        
    }
}
