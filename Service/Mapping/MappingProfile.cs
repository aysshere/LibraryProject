using AutoMapper;
using DataAccess.Identity;
using Entity.Entities;
using Entity.ViewModels;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book to BookViewModel Mapping
            CreateMap<Book, BookViewModel>().ReverseMap();

            // AppUser to CustomerViewModel Mapping
            CreateMap<AppUser, CustomerViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Map Id to CustomerId
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)) // Assuming Status needs to be mapped
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)) // Assuming Gender needs to be mapped
                .ReverseMap();

            // Customer to CustomerViewModel Mapping
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Map Id to CustomerId
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)) // Assuming Status needs to be mapped
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)) // Assuming Gender needs to be mapped
                .ReverseMap();

            // Category to CategoryViewModel Mapping
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            // BookRent to BookRentViewModel Mapping
            CreateMap<BookRent, BookRentViewModel>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId)) // Ensure CustomerId is mapped
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src => src.TotalQuantity))
                .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate))
                .ReverseMap();

            // BookRentDetail to BookRentDetailViewModel Mapping
            CreateMap<BookRentDetail, BookRentDetailViewModel>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();
        }
    }
}
