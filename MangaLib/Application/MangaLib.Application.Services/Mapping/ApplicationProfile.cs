using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Manga, MangaModel>()
                .ForMember(dest => dest.Authors,
                    opt => opt.MapFrom(src => src.GetAuthors()
                        .Split('|', StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => src.GetTags()
                        .Split('|', StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<CreateMangaModel, Manga>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    dest.SetAuthors(src.Authors);
                    dest.SetTags(src.Tags);
                });
            CreateMap<Chapter, ChapterModel>()
                .ForMember(dest => dest.PageCount,
                opt => opt.MapFrom(src => src.Pages.Count));
        }
    }
}