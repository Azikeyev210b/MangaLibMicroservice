using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Common.Enums;
using Domain.Entities;
using Domain.Repositories.Abstractions;
using MassTransit;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MangaCatalogService : IMangaCatalogService
    {
        private readonly IMangaRepository _mangaRepo;
        private readonly IMapper _mapper;

        public MangaCatalogService(IMangaRepository mangaRepo, IMapper mapper)
        {
            _mangaRepo = mangaRepo;
            _mapper = mapper;
        }

        public async Task<MangaModel?> GetMangaByIdAsync(int id, CancellationToken ct)
        {
            var manga = await _mangaRepo.GetByIdAsync(id, ct);
            return _mapper.Map<MangaModel?>(manga);
        }

        public async Task<IEnumerable<MangaModel>> GetAllMangaAsync(CancellationToken ct)
        {
            var manga = await _mangaRepo.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<MangaModel>>(manga);
        }

        public async Task<IEnumerable<MangaModel>> SearchMangaByTitleAsync(string title, CancellationToken ct)
        {
            var manga = await _mangaRepo.FindByTitleAsync(title, ct);
            return _mapper.Map<IEnumerable<MangaModel>>(manga);
        }

        public async Task<MangaModel> CreateMangaAsync(CreateMangaModel model, CancellationToken ct)
        {
            var manga = new Manga(
                id: 0,
                title: model.Title,
                description: model.Description,
                coverImageUrl: model.CoverImageUrl,
                releaseDate: model.ReleaseDate);

            manga.SetAuthors(model.Authors);
            manga.SetTags(model.Tags);

            await _mangaRepo.AddAsync(manga, ct);
            await _mangaRepo.SaveChangesAsync(ct);

            return _mapper.Map<MangaModel>(manga);
        }

        public async Task<bool> UpdateMangaAsync(UpdateMangaModel model, CancellationToken ct)
        {
            var existingManga = await _mangaRepo.GetByIdAsync(model.Id, ct);
            if (existingManga == null) return false;

            var updatedManga = new Manga(
                id: model.Id,
                title: model.Title ?? existingManga.Title,
                description: model.Description ?? existingManga.Description,
                coverImageUrl: model.CoverImageUrl ?? existingManga.CoverImageUrl,
                releaseDate: existingManga.ReleaseDate);

            // Устанавливаем авторов и теги
            updatedManga.SetAuthors(existingManga.GetAuthors().Split('|'));
            updatedManga.SetTags(existingManga.GetTags().Split('|'));

            // Копируем статус
            if (existingManga.GetCurrentStatus() == Common.Enums.MangaStatus.Completed)
            {
                updatedManga.MarkAsCompleted();
            }

            await _mangaRepo.UpdateAsync(updatedManga, ct);
            return await _mangaRepo.SaveChangesAsync(ct);
        }

        public async Task<bool> DeleteMangaAsync(int id, CancellationToken ct)
        {
            var manga = await _mangaRepo.GetByIdAsync(id, ct);
            if (manga == null) return false;

            await _mangaRepo.DeleteAsync(manga, ct);
            return await _mangaRepo.SaveChangesAsync(ct);
        }
    }
}