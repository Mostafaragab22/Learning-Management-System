using AutoMapper;
using Learning_Management_System.Application.DTOs.SubmissionDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;

namespace Learning_Management_System.Application.Services
{
    public class SubmissionService:ISubmissionService
    {

        IMapper _mapper;
        ISubmissionRepository _repository;
        ICacheService _cacheService;

        private const string CacheKey_All = "submissions";
        private const string CacheKey_Prefix = "submission_";

        public SubmissionService(IMapper mapper, ISubmissionRepository repository, ICacheService cacheService)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;
        }
        public async Task<SubmissionResponseDto> CreateAsync(AddSubmissionDto dto)
        {
            var submission = _mapper.Map<Submission>(dto);
            _repository.Add(submission);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_All);
            return _mapper.Map<SubmissionResponseDto>(submission);
        }

        public async Task<SubmissionResponseDto> UpdateAsync(long id, UpdateSubmissionDto dto)
        {

            var submission = await _repository.GetById(id) ??
                throw new NotFoundException("submission not found");
            _mapper.Map(dto, submission);
            _repository.Update(submission);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
            return _mapper.Map<SubmissionResponseDto>(submission);

        }

        public async Task DeleteAsync(long id)
        {
            var submission = await _repository.GetById(id) ??
                throw new NotFoundException("submission not found");
            _repository.Delete(submission);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);

        }

        public async Task<SubmissionResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<SubmissionResponseDto>(CacheKey_Prefix + id);
            if (cached != null)
                return cached;
            var submission = await _repository.GetById(id) ??
                throw new NotFoundException("submission not found");
            var result = _mapper.Map<SubmissionResponseDto>(submission);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result, TimeSpan.FromMinutes(10));

            return result;
        }
        public async Task<SubmissionResponseDto> GetByNameAsync(string Name)
        {
            var cached = await _cacheService.GetAsync<SubmissionResponseDto>(CacheKey_Prefix + Name);
            if (cached != null)
                return cached;
            var submission = await _repository.GetByName(Name) ??
                throw new NotFoundException("submission not found");
            var result = _mapper.Map<SubmissionResponseDto>(submission);
            await _cacheService.SetAsync(CacheKey_Prefix + Name, result, TimeSpan.FromMinutes(10));

            return result;

        }


        public async Task<IEnumerable<SubmissionResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync<IEnumerable<SubmissionResponseDto>>(CacheKey_All);
            if (cached != null)
                return cached;
            var submission = await _repository.GetAll();
            var result = _mapper.Map<IEnumerable<SubmissionResponseDto>>(submission);
            await _cacheService.SetAsync(CacheKey_All, result, TimeSpan.FromMinutes(10));

            return result;


        }
    }
}
