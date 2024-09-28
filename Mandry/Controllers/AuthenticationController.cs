using Mandry.ApiResponses.Authentication;
using Mandry.Interfaces.Services;
using Mandry.Interfaces.Validation;
using Mandry.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Mandry.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Mandry.Models.Requests.Authentication;
using Mandry.Extensions;

namespace Mandry.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IUserService _userService;
        private IAuthenticationService _authenticationService;
        private ICredentialValidator _credentialValidator;

        public AuthenticationController(IUserService userService, IAuthenticationService authenticationService, ICredentialValidator credentialValidator)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _credentialValidator = credentialValidator;
        }

        [HttpPost("phone")]
        public async Task<IActionResult> LoginUserUsingPhone([FromBody] PhoneModel model)
        {
            try
            {
                string phone = model.Phone;

                ValidationErrors phoneErrors = _credentialValidator.ValidateNotNull(phone, "phone");

                if (!phoneErrors.IsValid)
                {
                    List<ValidationErrors> validationErrors = new List<ValidationErrors>();
                    if (!phoneErrors.IsValid) validationErrors.Add(phoneErrors);

                    return BadRequest(new LoginUserUsingPhoneResponse()
                    {
                        IsValidationFailed = true,
                        ValidationErrorGroups = validationErrors
                    });
                }

                User? user = await _userService.GetBasicUserByPhoneAsync(phone);
                if (user == null)
                {
                    return Unauthorized(new LoginUserUsingPhoneResponse()
                    {
                        IsAccountExisting = false,
                    });
                }

                string token = _authenticationService.GetJwtFor(user);

                return Ok(new LoginUserUsingPhoneResponse()
                {
                    IsSuccess = true,
                    IsAccountExisting = true,
                    Token = token,
                    UserData = new UserDataDTO()
                    {
                        Name = user.Name,
                        Email = user.Email ?? string.Empty,
                        Id = user.Id.ToString(),
                        Surname = user.Surname,
                        Avatar = user.ProfileImage.ToDTO()
                    }
                });

            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
      
        [HttpPost("email")]
        public async Task<IActionResult> LoginUserUsingEmailAndPassword([FromBody] EmailPasswordModel model)
        {
            try
            {
                string email = model.Email;
                string password = model.Password;
                ValidationErrors emailErrors = _credentialValidator.ValidateNotNull(email, "email");
                ValidationErrors passwordErrors = _credentialValidator.ValidateNotNull(password, "password");

                if(!emailErrors.IsValid || !passwordErrors.IsValid) 
                {
                    List<ValidationErrors> validationErrors = [emailErrors, passwordErrors];
                    return BadRequest(new LoginUserUsingEmailAndPasswordResponse()
                    {
                        IsValidationFailed = true,
                        ValidationErrorGroups = validationErrors
                    });
                }

                User? user = await _userService.GetBasicUserByEmailAsync(email);
                if(user == null)
                {
                    return Unauthorized(new LoginUserUsingEmailAndPasswordResponse()
                    {
                        IsAccountNotExisted = true,
                    });
                }

                bool passwordCheck = _authenticationService.VerifyPassword(user, password);

                if(!passwordCheck)
                {
                    return Unauthorized(new LoginUserUsingEmailAndPasswordResponse());
                }

                string token = _authenticationService.GetJwtFor(user);

                return Ok(new LoginUserUsingEmailAndPasswordResponse()
                {
                    IsSuccess = true,
                    Token = token,
                    Email = user.Email ?? string.Empty,
                    UserData = new UserDataDTO()
                    {
                        Name = user.Name,
                        Email = user.Email ?? string.Empty,
                        Id = user.Id.ToString(),
                        Surname = user.Surname,
                        Avatar = user.ProfileImage.ToDTO()
                    }
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPost("verify-token")]
        public IActionResult VerifyToken()
        {
            return Ok(new { verified = true });
        }

        [HttpGet("verify-google")]
        public async Task<IActionResult> VerifyGoogleToken(string accessToken)
        {
            try
            {
                var googleUserData = await _authenticationService.VerifyGoogleAccessToken(accessToken);
                if(googleUserData != null)
                {
                    return Ok(new VerifyGoogleTokenResponse { UserInfo = googleUserData, AccessToken = accessToken });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("signin/google")]
        public async Task<IActionResult> SignInGoogle(string accessToken)
        {
            try
            {
                var googleUserData = await _authenticationService.VerifyGoogleAccessToken(accessToken);
                if (googleUserData != null)
                {
                    User? user = await _userService.GetUserByGoogleIdAsync(googleUserData.Id);

                    if(user == null)
                    {
                        SignInGoogleResponse result = new SignInGoogleResponse()
                        {
                            IsAccountExisting = false,
                            UserInfo = googleUserData,
                        };
                        result.UserInfo.AccessToken = accessToken;

                        return Unauthorized(result);
                    }

                    string token = _authenticationService.GetJwtFor(user);

                    return Ok(new SignInGoogleResponse()
                    {
                        Token = token,  
                        UserData = new UserDataDTO()
                        {
                            Name = user.Name,
                            Email = user.Email ?? string.Empty,
                            Id = user.Id.ToString(),
                            Surname = user.Surname,
                            Avatar = user.ProfileImage.ToDTO()
                        }
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
