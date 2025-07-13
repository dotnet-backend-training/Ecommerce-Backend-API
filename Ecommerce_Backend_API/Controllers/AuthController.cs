using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecommerce_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
                this._authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterRequestDto registerRequestDto,
            [FromServices] IValidator<RegisterRequestDto> validator) 
        {
            var validationResult = validator.Validate(registerRequestDto);
            if (!validationResult.IsValid)
            {
                var modelState = new ModelStateDictionary();
                validationResult.Errors.ForEach(
                    (error) =>
                    modelState.AddModelError(
                        error.PropertyName, error.ErrorMessage
                    )
                );
                return ValidationProblem(modelState);
            }
            var userModel = new User { 
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Email,
                ZoneId = registerRequestDto.ZoneCode,
                CityId = registerRequestDto.CityCode,
                GovernmentId = registerRequestDto.GovermentCode,
                ClassificationId = registerRequestDto.CustomerClassificationId,
            };
            var result = await _authRepository.RegisterAsync(userModel, registerRequestDto.Password);
            if (result is FailResponse fail)
            {
                return Problem(
                    statusCode: (int)result.StatusCode,
                    title: result.Message,
                    detail: string.Join(", ", fail.Errors ?? [])
                );
            }
            return CreatedAtAction(null, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginRequestDto loginRequestDto,
            [FromServices] IValidator<LoginRequestDto> validator
        )
        {
            var validationResult = validator.Validate(loginRequestDto);
            if (!validationResult.IsValid)
            {
                var modelState = new ModelStateDictionary();
                validationResult.Errors.ForEach(
                    (error) =>
                    modelState.AddModelError(
                        error.PropertyName, error.ErrorMessage
                    )
                );
                return ValidationProblem(modelState);
            }
            var loginResult = await _authRepository.LoginAsync(
                loginRequestDto.Username,
                loginRequestDto.Password
             );
            if (loginResult is FailResponse fail)
            {
                return StatusCode(
                    statusCode: (int) loginResult.StatusCode,
                    new{
                        title = loginResult.Message,
                        detail =  fail.Errors
                    }
                );
            }
            if ((loginResult as SuccessResponse<LoginResponseDto>)?.Data?.AccessToken is null)
            {
                return Unauthorized(
                "Unauthorized"
                );
            }
            return Ok(loginResult);
        }
    }
}
