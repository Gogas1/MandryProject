using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Mandry.ApiResponses.Account;
using Mandry.Interfaces.Validation;
using Mandry.Interfaces.Helpers;
using Microsoft.AspNetCore.Identity;
using Mandry.Models.Requests.Account;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Mandry.Models.Requests;
using Mandry.Services;
using Mandry.Extensions;

namespace Mandry.Controllers
{
    [Route("a")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICredentialValidator _credentialValidator;
        private readonly IStringObfuscator _stringObfuscator;
        private readonly IAuthenticationService _authenticationService;
        private readonly IImageService _imageService;

        public AccountController(
            IUserService userService,
            ICredentialValidator credentialValidator,
            IStringObfuscator stringObfuscator,
            IAuthenticationService authenticationService,
            IImageService imageryService)
        {
            _userService = userService;
            _credentialValidator = credentialValidator;
            _stringObfuscator = stringObfuscator;
            _authenticationService = authenticationService;
            _imageService = imageryService;
        }

        [HttpPost("auth/signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel model)
        {
            string name = model.Name;
            string surname = model.Surname;
            string phone = model.Phone;
            string email = model.Email;
            string password = model.Password;
            DateTime birthDate = model.BirthDate;

            try
            {
                ValidationErrors nameErrors = _credentialValidator.ValidateNotNull(name, "name");
                ValidationErrors surnameErrors = _credentialValidator.ValidateNotNull(surname, "surname");
                ValidationErrors birthDateErrors = _credentialValidator.ValidateBirthDate(birthDate);

                if(!nameErrors.IsValid || !surnameErrors.IsValid)
                {
                    ICollection<ValidationErrors> errorsGroups = [nameErrors, surnameErrors, birthDateErrors];
                    
                    return BadRequest(new SignUpResponse()
                    {
                        IsValidationFailed = true,
                        ValidationErrorsGrous = errorsGroups
                    });
                }

                if ((string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email)) && string.IsNullOrEmpty(phone))
                {
                    ValidationErrors passwordErrors = _credentialValidator.ValidatePassword(password);
                    ValidationErrors emailErrors = _credentialValidator.ValidateEmail(email);
                    ValidationErrors phoneErrors = _credentialValidator.ValidatePhone(phone);

                    ICollection<ValidationErrors> errorsGroups = [passwordErrors, emailErrors, phoneErrors];

                    return BadRequest(new SignUpResponse()
                    {
                        IsValidationFailed = true,
                        ValidationErrorsGrous = errorsGroups
                    });
                }

                User? user = await _userService.GetBasicUserByPhoneOrEmailAsync(phone, email);

                if (user != null)
                {
                    return Conflict(new SignUpResponse()
                    {
                        IsAccountExisting = true,
                        ObfuscatedUserData = new SignUpObfuscatedUserData()
                        {
                            Email = _stringObfuscator.ObfuscateEmail(user.Email ?? string.Empty),
                            Name = user.Name,
                            Phone = _stringObfuscator.ObfuscatePhone(user.Phone ?? string.Empty),
                        }
                    });
                }

                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

                User newUser = new User()
                {
                    Name = name,
                    Surname = surname,
                    Email =  email,
                    Phone = phone,
                    BirthDate = DateOnly.FromDateTime(birthDate),
                };

                if(!string.IsNullOrEmpty(password))
                {
                    newUser.PasswordHash = passwordHasher.HashPassword(newUser, password);
                }

                newUser = await _userService.CreateUserAsync(newUser);
                string jwt = _authenticationService.GetJwtFor(newUser);

                return Ok(new SignUpResponse()
                {
                    Success = true,
                    Token = jwt,
                    UserData = new Models.DTOs.UserDataDTO()
                    {
                        Email = !string.IsNullOrEmpty(newUser.Email) ? newUser.Email : string.Empty,
                        Name = newUser.Name,
                        Surname = newUser.Surname,
                        Phone = !string.IsNullOrEmpty(newUser.Phone) ? newUser.Phone : string.Empty,
                    }
                });

            } catch (Exception ex) 
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("data")]
        public async Task<IActionResult> GetUserData()
        {
            var user = HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId != null) 
            {
                var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                if(targetUser == null) 
                {
                    GetUserDataResponse response = new GetUserDataResponse();
                    response.UserDoesNoExist = true;
                    return NotFound(response);
                }
                else
                {
                    GetUserDataResponse response = new GetUserDataResponse();
                    response.UserData = new Models.DTOs.UserDataDTO();

                    response.UserData.Id = targetUser.Id.ToString();
                    response.UserData.Name = targetUser.Name;
                    response.UserData.Surname = targetUser.Surname;
                    response.UserData.Phone = targetUser.Phone ?? string.Empty;
                    response.UserData.Email = targetUser.Email ?? string.Empty;
                    
                    return Ok(response);
                }         
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpGet("agreement")]
        public async Task<IActionResult> GetUserAgreementAcceptance()
        {
            var user = HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId != null) 
            {
                var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                if(targetUser == null)
                {
                    GetUserAgreementAcceptanceResponse response = new GetUserAgreementAcceptanceResponse();
                    response.IsAgreementAccepted = false;
                    return NotFound(response);
                }
                else
                {
                    GetUserAgreementAcceptanceResponse response = new GetUserAgreementAcceptanceResponse();
                    response.IsAgreementAccepted = targetUser.IsAgreementAccepted;
                    return Ok(response);
                }
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpPost("avatar/my/change")]
        public async Task<IActionResult> ChangeMyAvatar([FromForm] ImageModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var user = HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                if (targetUser == null)
                {
                    return NotFound();
                }
                else
                {
                    Image image = await _imageService.SaveImage(model.File, "images/users/");
                    await _userService.UpdateUserAvatar(targetUser, image);
                    return Ok(image.ToDTO());
                }
            }

            return Unauthorized();     
        }
    }
}
