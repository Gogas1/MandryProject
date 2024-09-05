using Mandry.ApiResponses.Category;
using Mandry.Interfaces.Services;
using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.Requests.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Mandry.Controllers
{
    [Route("c")]
    public class CategoryController : Controller
    {
        private readonly IDataValidator _dataValidator;
        private readonly ICategoryService _categoryService;

        public CategoryController(IDataValidator dataValidator, ICategoryService categoryService)
        {
            _dataValidator = dataValidator;
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryModel model)
        {
            try
            {
                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    NameKey = model.NameKey,
                    CategoryPropertyDescriptionKey = model.CategoryPropertyDescriptionKey,
                    IsCategoryPropertyRequired = model.IsCategoryPropertyRequired,
                    CategoryTranslations = model.CategoryTranslations,
                    CategoryPropertyTranslations = model.CategoryPropertyTranslations
                };

                ValidationErrors errors = _dataValidator.ValidateCategoryData(categoryDTO);

                if(!errors.IsValid)
                {
                    return BadRequest(new CreateCategoryResponse
                    {
                        IsValidationFailed = true,
                        ValidationErrorsGroups = new List<ValidationErrors> { errors }
                    });
                }

                var categoryData = await _categoryService.CreateCategoryAsync(categoryDTO);

                return Ok(new CreateCategoryResponse()
                {
                    Success = true,
                    CategoryData = categoryData
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                ICollection<CategoryDTO> categories = await _categoryService.GetCategoriesAsync();

                return Ok(new GetCategoriesResponse()
                {
                    Categories = categories
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
