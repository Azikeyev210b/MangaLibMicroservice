using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Abstractions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepo;
        private readonly IMapper _mapper;

        public ChapterService(IChapterRepository chapterRepo, IMapper mapper)
        {
            _chapterRepo = chapterRepo;
            _mapper = mapper;
        }

        public async Task<ChapterModel?> GetChapterAsync(int mangaId, int chapterId, CancellationToken ct)
        {
            var chapter = await _chapterRepo.GetByIdAsync(mangaId, chapterId, ct);
            return _mapper.Map<ChapterModel>(chapter);
        }

        public async Task<IEnumerable<ChapterModel>> GetChaptersForMangaAsync(int mangaId, CancellationToken ct)
        {
            var chapters = await _chapterRepo.GetForMangaAsync(mangaId, ct);
            return _mapper.Map<IEnumerable<ChapterModel>>(chapters);
        }

        public async Task<ChapterModel> UploadChapterAsync(UploadChapterModel model, CancellationToken ct)
        {
            var chapter = new Chapter(
                mangaId: model.MangaId,
                title: model.Title,
                chapterNumber: model.ChapterNumber);

            await _chapterRepo.AddAsync(chapter, ct);
            await _chapterRepo.SaveChangesAsync(ct);

            return _mapper.Map<ChapterModel>(chapter);
        }
    }
}