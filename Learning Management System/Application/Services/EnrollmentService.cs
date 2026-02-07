using AutoMapper;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using Learning_Management_System.Infrastructure.Repositories;

namespace Learning_Management_System.Application.Services
{
    public class EnrollmentService: IEnrollmentService
    {
        IMapper _mapper;

        IEnrollmentRepository _repository;
        ICacheService _cacheService;

        private const string CacheKey_All = "enrollments";
        private const string CacheKey_Prefix = "enrollment_";

        public EnrollmentService(IMapper mapper, IEnrollmentRepository repository, ICacheService cacheService)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;
        }
        public async Task<EnrollmentResponseDto> CreateAsync(EnrollCourseDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            _repository.Add(enrollment);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);

            return _mapper.Map<EnrollmentResponseDto>(enrollment);
        }

        public async Task<EnrollmentResponseDto> UpdateAsync(long id, UpdateEnrollmentDto enrollmentDto)
        {

            var enrollment = await _repository.GetById(id) ??
                throw new NotFoundException("enrollment not found");
            _mapper.Map(enrollmentDto,enrollment );
            _repository.Update(enrollment);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
            return _mapper.Map<EnrollmentResponseDto>(enrollment);

        }

        public async Task DeleteAsync(long id)
        {
            var enrollment = await _repository.GetById(id) ??
                throw new NotFoundException("enrollment not found");
            _repository.Delete(enrollment);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
        }

        public async Task<EnrollmentResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<EnrollmentResponseDto>(CacheKey_Prefix + id);
            if (cached != null) 
                return cached;
            var enrollment = await _repository.GetById(id) ??
                throw new NotFoundException("enrollment not found");

            var result = _mapper.Map<EnrollmentResponseDto>(enrollment);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result, TimeSpan.FromMinutes(10));

            return result;
        }


 

        public async Task<EnrollmentResponseDto> GetBystudentIdAsync(long studentId)
        {
            var cached = await _cacheService.GetAsync<EnrollmentResponseDto>(CacheKey_Prefix + studentId);
            if (cached != null)
                return cached;
            var enrollment = await _repository.GetByStudentId(studentId) ??
                throw new NotFoundException("enrollment not found");
            var result = _mapper.Map<EnrollmentResponseDto>(enrollment);
            await _cacheService.SetAsync(CacheKey_Prefix + studentId, result, TimeSpan.FromMinutes(10));

            return result;

        }
        public async Task<IEnumerable<EnrollmentResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync<IEnumerable<EnrollmentResponseDto>>(CacheKey_All);
            if (cached != null) return cached;

            var enrollments = await _repository.GetAll();
            var result = _mapper.Map< IEnumerable<EnrollmentResponseDto>>(enrollments);

            await _cacheService.SetAsync(CacheKey_All, result, TimeSpan.FromMinutes(10));

            return result;



        }
    }
}
