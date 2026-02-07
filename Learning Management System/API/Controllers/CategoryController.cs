using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Reflection;

namespace Learning_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(AddToCatogeryDto categoryDto)
        
           => Ok(await  _categoryService.CreateAsync(categoryDto));

        [HttpPut("{id}")]
       [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdatCategoryDto categoryDto, long id)
            => Ok(await _categoryService.UpdateAsync(id, categoryDto));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(await _categoryService.GetByIdAsync(id));

        [HttpGet("ByName/{Name}")]
        public async Task<IActionResult> GetByNameAsync(string Name)
            => Ok(await _categoryService.GetByNameAsync(Name));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _categoryService.GetAllAsync());


    }
}
