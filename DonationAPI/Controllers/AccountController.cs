using DonationAPI.Requests;
using DonationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService accountService = accountService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await accountService.Login(request);

            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            var result = await accountService.Register(request);

            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
