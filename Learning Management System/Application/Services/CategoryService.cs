using AutoMapper;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Application.Mapping;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using Microsoft.AspNetCore.Authorization;

namespace Learning_Management_System.Application.Services
{
    public class CategoryService:ICategoryService
    {
        ICategoryRepository _repository {  get; set; }
        IMapper _mapper {  get; set; }
        ICacheService _cacheService { get; set; }
        private const string CacheKey_all = "categories";
        private const string Cachekey_prefix = "category_";
        public CategoryService(ICategoryRepository repository, IMapper mapper, ICacheService cacheService)
        {
            _repository = repository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<CategoryResponseDto> CreateAsync (AddToCatogeryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repository.Add(category);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_all);
            return _mapper.Map<CategoryResponseDto>(category);

        }

        public async Task<CategoryResponseDto> UpdateAsync(long id, UpdatCategoryDto categoryDto)
        {
            var category =await _repository.GetById(id)??
                throw new 
                NotFoundException("Category not found");
            _mapper.Map(categoryDto, category);
            _repository.Update(category);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_all);
            await _cacheService.RemoveAsync(Cachekey_prefix + id);


            return _mapper.Map<CategoryResponseDto>(category);

        }
        public async Task DeleteAsync(long id)
        {
            var category = await _repository.GetById(id) ??
                throw new NotFoundException("Category not found");
            _repository.Delete(category);
            await _repository.Save();

            await _cacheService.RemoveAsync(CacheKey_all);
            await _cacheService.RemoveAsync(Cachekey_prefix + id);

        }

        public async Task<CategoryResponseDto> GetByIdAsync(long id)
        {
            var cached = await _cacheService.GetAsync<CategoryResponseDto>(Cachekey_prefix + id);
            if (cached != null)
                return cached;

            var categorydto = await _repository.GetById(id)??
                throw new NotFoundException("Category not found");
            var result = _mapper.Map<CategoryResponseDto> (categorydto);
            await _cacheService.SetAsync(Cachekey_prefix+id, result,TimeSpan.FromMinutes(10));
            return result;
        }
        public async Task<CategoryResponseDto> GetByNameAsync(string Name)
        {
            var cached = await _cacheService.GetAsync<CategoryResponseDto>(Cachekey_prefix + Name);
            if (cached != null) return cached;
            var categoryDto = await _repository.GetByName(Name)??
                throw new NotFoundException("Category not found");
            var result = _mapper.Map<CategoryResponseDto>(categoryDto);
            await _cacheService.SetAsync(Cachekey_prefix+ Name, result,TimeSpan.FromMinutes(10));
            return result;
        }
        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
        {
            var cached = await _cacheService.GetAsync<IEnumerable<CategoryResponseDto>>(CacheKey_all);
            if (cached != null) return cached;
            var categoriesDto = await _repository.GetAll();

            var result = _mapper.Map<IEnumerable<CategoryResponseDto>>(categoriesDto);
            await _cacheService.SetAsync(CacheKey_all,result,TimeSpan.FromMinutes(10));
            return result;


        }



    }
}
