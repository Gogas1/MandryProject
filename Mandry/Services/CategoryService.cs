using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            Category newCategory = new Category();
            newCategory.NameKey = categoryDTO.NameKey;
            newCategory.IsCategoryPropertyRequired = categoryDTO.IsCategoryPropertyRequired;
            newCategory.Translation = categoryDTO.CategoryTranslations.Select(t => new Translation()
            {
                Language = t.LanguageCode,
                TranslationKey = t.Key,
                TranslationString = t.Text
            }).ToList();

            if(categoryDTO.IsCategoryPropertyRequired)
            {
                newCategory.CategoryPropertyDescriptionKey = categoryDTO.CategoryPropertyDescriptionKey;
                newCategory.CategoryPropertyTranslations = new CategoryDescriptionProperty();
                newCategory.CategoryPropertyTranslations.DescriptionKey = categoryDTO.CategoryPropertyDescriptionKey;
                newCategory.CategoryPropertyTranslations.Translation = categoryDTO.CategoryPropertyTranslations.Select(t => new Translation()
                {
                    Language = t.LanguageCode,
                    TranslationKey = t.Key,
                    TranslationString = t.Text
                }).ToList();
            }

            newCategory = await _categoryRepository.CreateCategoryAsync(newCategory);

            CategoryDTO resultData = new CategoryDTO()
            {
                NameKey = newCategory.NameKey,
                IsCategoryPropertyRequired = newCategory.IsCategoryPropertyRequired,
                CategoryPropertyDescriptionKey = newCategory.CategoryPropertyDescriptionKey,
                CategoryTranslations = newCategory.Translation.Select(t => new TranslationDTO()
                {
                    Key = t.TranslationKey,
                    LanguageCode = t.Language,
                    Text = t.TranslationString
                }).ToList()
            };

            if(resultData.IsCategoryPropertyRequired && newCategory.CategoryPropertyTranslations != null)
            {
                resultData.CategoryPropertyTranslations = newCategory.CategoryPropertyTranslations.Translation.Select(t => new TranslationDTO()
                {
                    Key = t.TranslationKey,
                    LanguageCode = t.Language,
                    Text = t.TranslationString
                }).ToList();
            }

            return resultData;
        }

        public async Task<ICollection<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesWithTranslations();
            var categoriesDTO = categories.Select(c =>
            {
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.Id = c.Id.ToString();
                categoryDTO.NameKey = c.NameKey;
                categoryDTO.IsCategoryPropertyRequired = c.IsCategoryPropertyRequired;
                categoryDTO.CategoryPropertyDescriptionKey= c.CategoryPropertyDescriptionKey;
                categoryDTO.CategoryTranslations = c.Translation.Select(t => new TranslationDTO()
                {
                    Key = t.TranslationKey,
                    LanguageCode = t.Language,
                    Text = t.TranslationString
                }).ToList();

                if (c.CategoryPropertyTranslations != null)
                {
                    categoryDTO.CategoryPropertyTranslations = c.CategoryPropertyTranslations.Translation.Select(t => new TranslationDTO()
                    {
                        Key = t.TranslationKey,
                        LanguageCode = t.Language,
                        Text = t.TranslationString
                    }).ToList();
                }

                return categoryDTO;
            }).ToList();

            return categoriesDTO;
        }
    }
}
