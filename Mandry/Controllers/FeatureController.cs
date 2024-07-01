using Mandry.Interfaces.Services;
using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Features;
using Microsoft.AspNetCore.Mvc;
using Mandry.ApiResponses.Feature;

namespace Mandry.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IDataValidator _dataValidator;

        public FeatureController(IFeatureService featureService, IDataValidator dataValidator)
        {
            _featureService = featureService;
            _dataValidator = dataValidator;
        }

        [HttpPost("/f/create")]
        public async Task<IActionResult> CreateFeature(FeatureDataDTO featureData)
        {
            try
            {
                ValidationErrors featureErros = _dataValidator.ValidateFeatureData(featureData);

                if (!featureErros.IsValid)
                {
                    return BadRequest(new CreateFeatureResponse
                    {
                        IsValidationFailed = true,
                        ValidationErrorsGroups = new List<ValidationErrors> { featureErros }
                    });
                }

                featureData = await _featureService.CreateFeatureAsync(featureData);

                return Ok(new CreateFeatureResponse
                {
                    FeatureData = featureData,
                    Success = true,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        public async Task<IActionResult> RequestFeatures()
        {
            try
            {
                ICollection<FeatureDataDTO> features = await _featureService.GetFeaturesAsync();

                return Ok(new RequestFeaturesResponse
                {
                    Features = features
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }
    }
}
