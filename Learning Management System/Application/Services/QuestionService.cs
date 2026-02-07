using AutoMapper;
using Learning_Management_System.Application.DTOs.QuestionsDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;

namespace Learning_Management_System.Application.Services
{
    public class QuestionService:IQuestionService
    {
        IMapper _mapper;
        IQuestionRepository _repository;
        ICacheService _cacheService;

        private const string CacheKey_All = "questions";
        private const string CacheKey_Prefix = "question_";

        public QuestionService(IMapper mapper, IQuestionRepository repository, ICacheService cacheService)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;
        }
        public async Task<QuestionsResponseDto> CreateAsync(CreateQuestionsDto dto)
        {
            var question = _mapper.Map<Question>(dto);
            _repository.Add(question);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_All);
            return _mapper.Map<QuestionsResponseDto>(question);
        }

        public async Task<QuestionsResponseDto> UpdateAsync(long id, UpdateQuestionsDto dto)
        {

            var question = await _repository.GetQuestion(id) ??
                throw new NotFoundException("question not found");
            _mapper.Map(dto, question);
            _repository.Update(question);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
            return _mapper.Map<QuestionsResponseDto>(question);

        }

        public async Task DeleteAsync(long id)
        {
            var question = await _repository.GetQuestion (id) ??
                throw new NotFoundException("question not found");
            _repository.Delete(question);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);

        }

        public async Task<QuestionsResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<QuestionsResponseDto>(CacheKey_Prefix + id);
            if (cached != null)
                return cached;
            var question = await _repository.GetQuestion(id) ??
                throw new NotFoundException("question not found");
            var result = _mapper.Map<QuestionsResponseDto>(question);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result, TimeSpan.FromMinutes(10));

            return result;
        }

        
        public async Task<IEnumerable<QuestionsResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync<IEnumerable<QuestionsResponseDto>>(CacheKey_All);
            if (cached != null)
                return cached;
            var question = await _repository.GetQuestions();
            var result = _mapper.Map<IEnumerable<QuestionsResponseDto>>(question);
            await _cacheService.SetAsync(CacheKey_All, result, TimeSpan.FromMinutes(10));

            return result;


        }
    }
}
