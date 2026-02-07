using AutoMapper;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Learning_Management_System.Application.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository _repository;
        IMapper _mapper;
        ICacheService _cacheService;
        private const string CacheKey_all = "courses";
        private const string CacheKey_Prefix = "course_";
        public CourseService(IMapper mapper, ICourseRepository repository, ICacheService cacheService)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;

        }

        public async Task<CoursesResponseDto> CreateAsync(CreateCourseDto courseDto)
        {
            
            var course = _mapper.Map<Course>(courseDto);
            _repository.Add(course);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_all);
           

            return _mapper.Map<CoursesResponseDto>(course);

        }

        public async Task<CoursesResponseDto> UpdateAsync(long id, UpdateCourseDto courseDto)
        {
            var course = await _repository.GetById(id) ??
                throw new NotFoundException("Course not Found");
            _mapper.Map(courseDto, course);
            _repository.Update(course);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_all);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);

            return _mapper.Map<CoursesResponseDto>(course);
        } 

        public async Task DeleteAsync(long id)
        {

            var course = await _repository.GetById(id) ??
                throw new NotFoundException("Course not Found");

            _repository.Delete(course);
           await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_all);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);

        }

        public async Task<CoursesResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<CoursesResponseDto>(CacheKey_Prefix + id);
            if (cached != null)
                return cached;

            var course = await _repository.GetById(id)??
                throw new NotFoundException("Course not Found");
           var result = _mapper.Map<CoursesResponseDto>(course);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result , TimeSpan.FromMinutes(10));
            return result;

        }
        public async Task<CoursesResponseDto> GetByNameAsync(string Name)
        {
            var cached = await _cacheService.GetAsync<CoursesResponseDto>(CacheKey_Prefix + Name);
            if (cached != null)
                return cached;

            var course = await _repository.GetByName(Name)??
                throw new NotFoundException("Course not Found");
            var result = _mapper.Map<CoursesResponseDto>(course);
            await _cacheService.SetAsync(CacheKey_Prefix + Name, result, TimeSpan.FromMinutes(10));
            return result;

        }

        public async Task<IEnumerable<CoursesResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync<IEnumerable<CoursesResponseDto>>(CacheKey_all);
            if (cached != null) return cached;

            var courses = await _repository.GetCourses();
            var result = _mapper.Map<IEnumerable<CoursesResponseDto>>(courses);
            await _cacheService.SetAsync(CacheKey_all, result, TimeSpan.FromMinutes(10));
            return result;
        }

    }
}
