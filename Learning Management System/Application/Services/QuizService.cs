using AutoMapper;
using Learning_Management_System.Application.DTOs.QuizDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using Learning_Management_System.Infrastructure.Repositories;

namespace Learning_Management_System.Application.Services
{
    public class QuizService:IQuizService
    {
        IMapper _mapper;
        IQuizRepository _repository;
        ICacheService _cacheService;

        private const string CacheKey_All = "quizees";
        private const string CacheKey_Prefix = "quiz_";

        public QuizService(IMapper mapper, IQuizRepository repository, ICacheService cacheService)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;
        }
        public async Task<QuizResponseDto> CreateAsync(CreateQuizDto dto)
        {
            var quiz = _mapper.Map<Quiz>(dto);
            _repository.Add(quiz);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_All);
            return _mapper.Map<QuizResponseDto>(quiz);
        }

        public async Task<QuizResponseDto> UpdateAsync(long id, UpdateQuizDto dto)
        {

            var quiz = await _repository.GetById(id) ??
                throw new NotFoundException("quiz not found");
            _mapper.Map(dto,quiz);
            _repository.Update(quiz);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
            return _mapper.Map<QuizResponseDto>(quiz);

        }

        public async Task DeleteAsync(long id)
        {
            var quiz = await _repository.GetById(id) ??
                throw new NotFoundException("quiz not found");
            _repository.Delete(quiz);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);

        }

        public async Task<QuizResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<QuizResponseDto>(CacheKey_Prefix + id);
            if (cached != null)
                return cached;
            var quiz = await _repository.GetById(id) ??
                throw new NotFoundException("quiz not found");
            var result = _mapper.Map<QuizResponseDto>(quiz);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result, TimeSpan.FromMinutes(10));

            return result;
        }

        public async Task<QuizResponseDto> GetByNameAsync(string Name)
        {
            var cached = await _cacheService.GetAsync<QuizResponseDto>(CacheKey_Prefix + Name);
            if (cached != null)
                return cached;
            var quiz = await _repository.GetByName(Name) ??
                throw new NotFoundException("quiz not found");
            var result = _mapper.Map<QuizResponseDto>(quiz);
            await _cacheService.SetAsync(CacheKey_Prefix + Name, result, TimeSpan.FromMinutes(10));

            return result;

        }
        public async Task<IEnumerable<QuizResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync<IEnumerable<QuizResponseDto>>(CacheKey_All);
            if (cached != null)
                return cached;
            var quiz = await _repository.GetAll();
            var result = _mapper.Map<IEnumerable<QuizResponseDto>>(quiz);
            await _cacheService.SetAsync(CacheKey_All, result, TimeSpan.FromMinutes(10));

            return result;


        }
    }
}

