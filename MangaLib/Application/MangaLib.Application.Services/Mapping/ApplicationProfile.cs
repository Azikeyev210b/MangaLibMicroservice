using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // Manga -> MangaModel
            CreateMap<Manga, MangaModel>()
                .ForMember(dest => dest.Authors,
                    opt => opt.MapFrom(src => src.GetAuthors()
                        .Split('|', StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => src.GetTags()
                        .Split('|', StringSplitOptions.RemoveEmptyEntries)));

            // CreateMangaModel -> Manga
            CreateMap<CreateMangaModel, Manga>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    dest.SetAuthors(src.Authors);
                    dest.SetTags(src.Tags);
                });
        }
    }
}