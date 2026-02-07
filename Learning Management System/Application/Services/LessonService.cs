using AutoMapper;
using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Application.DTOs.LessonDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using Learning_Management_System.Infrastructure.Repositories;

namespace Learning_Management_System.Application.Services
{
    public class LessonService:ILessonService
    {
        IMapper _mapper;
        ILessonRepository _repository;
        ICacheService _cacheService;

        private const string CacheKey_All = "lessons";
        private const string CacheKey_Prefix = "lesson_";

        public LessonService(IMapper mapper, ILessonRepository repository, ICacheService cacheService)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;
        }
        public async Task<LessonResponseDto> CreateAsync(AddLessonDto dto)
        {
            var lesson = _mapper.Map<Lessons>(dto);
            _repository.Add(lesson);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_All);
            return _mapper.Map<LessonResponseDto>(lesson);
        }

        public async Task<LessonResponseDto> UpdateAsync(long id, UpdateLessonDto dto)
        {

            var lesson = await _repository.GetById(id) ??
                throw new NotFoundException("lesson not found");
            _mapper.Map(dto, lesson);
            _repository.Update(lesson);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
            return _mapper.Map<LessonResponseDto>(lesson);

        }

        public async Task DeleteAsync(long id)
        {
            var lesson = await _repository.GetById(id) ??
                throw new NotFoundException("lesson not found");
            _repository.Delete(lesson);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);

        }

        public async Task<LessonResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<LessonResponseDto>(CacheKey_Prefix + id);
            if (cached != null)
                return cached;
            var lesson = await _repository.GetById(id) ??
                throw new NotFoundException("lesson not found");
            var result = _mapper.Map<LessonResponseDto>(lesson);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result, TimeSpan.FromMinutes(10));

            return result;
        }

        public async Task<LessonResponseDto> GetByNameAsync(string Name)
        {
            var cached = await _cacheService.GetAsync<LessonResponseDto>(CacheKey_Prefix + Name);
            if (cached != null)
                return cached;
            var lesson = await _repository.GetByTitle(Name) ??
                throw new NotFoundException("lesson not found");
             var result = _mapper.Map<LessonResponseDto>(lesson);
            await _cacheService.SetAsync(CacheKey_Prefix + Name, result, TimeSpan.FromMinutes(10));

            return result;

        }
        public async Task<IEnumerable<LessonResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync< IEnumerable<LessonResponseDto>>(CacheKey_All);
            if (cached != null)
                return cached;
            var lesson = await _repository.Getlessons();
            var result = _mapper.Map<IEnumerable<LessonResponseDto>>(lesson);
            await _cacheService.SetAsync(CacheKey_All, result, TimeSpan.FromMinutes(10));

            return result;


        }
    }
}
