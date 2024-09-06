using Mandry.Interfaces.Services;
using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Features;
using Microsoft.AspNetCore.Mvc;
using Mandry.ApiResponses.Feature;
using Microsoft.AspNetCore.Authorization;
using Mandry.Models.Requests.Feature;
using Mandry.Models.DB;

namespace Mandry.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IDataValidator _dataValidator;
        private readonly IImageService _imageService;

        public FeatureController(IFeatureService featureService, IDataValidator dataValidator, IImageService imageService)
        {
            _featureService = featureService;
            _dataValidator = dataValidator;
            _imageService = imageService;
        }

        //[Authorize]
        [HttpPost("/f/create")]
        public async Task<IActionResult> CreateFeature([FromBody] FeatureDataDTO featureData)
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

        [HttpGet("/f/all")]
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

        [HttpPost("/f/delete-all")]
        public async Task<IActionResult> PurgeFeatures()
        {
            await _featureService.PurgeFeatures();

            return Ok();
        }

        [HttpPost("/f/safe-image")]
        public async Task<IActionResult> SaveFeatureImage([FromForm] FeatureImageModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            Image image = await _imageService.SaveImage(model.File, "images/features/");

            return Ok(new SafeFeatureImageResponse() { Image = image });
        }
    }
}
