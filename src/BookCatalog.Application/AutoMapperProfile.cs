using AutoMapper;
using BookCatalog.Application.Models;
using BookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Book, BookModelResult>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dest => dest.Description, src => src.MapFrom(x=> x.Description))
                .ForMember(dest => dest.PublishDate, src => src.MapFrom(x=>x.PublishDate))
                .ForMember(dest => dest.Categories, src => src.MapFrom(x => x.BookCategories.Select(x=> new CategoryResult() { CategoryId = x.Category.Id, Name = x.Category.Name }).ToList()));

            CreateMap<Book, CreateBookModel>()
                .ForMember(dest => dest.Title, src => src.MapFrom(x=>x.Title))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.PublishDate, src => src.MapFrom(x => x.PublishDate))
                .ReverseMap();

            CreateMap<Book, UpdateBookModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.PublishDate, src => src.MapFrom(x => x.PublishDate))
                .ReverseMap();
        }
    }
}
