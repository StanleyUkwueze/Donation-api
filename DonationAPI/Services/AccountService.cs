using DonationAPI.Entities;
using DonationAPI.Requests;
using DonationAPI.Responses;
using Microsoft.AspNetCore.Identity;

namespace DonationAPI.Services
{
    public class AccountService(UserManager<User> _mgr, SignInManager<User> _signMgr, ITokenService tokenService) : IAccountService
    {
        private readonly UserManager<User> mgr = _mgr;
        private readonly SignInManager<User> signMgr = _signMgr;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            var user = await mgr.FindByNameAsync(request.UserName);
            if (user is null) return new Result<LoginResponse> { IsSuccess = false, Message = "Invalid password or user name" };

            var result = await mgr.CheckPasswordAsync(user, request.Password);

            if(!result) return new Result<LoginResponse> { IsSuccess = false, Message = "Invalid password or user name" };

            var response = new LoginResponse
            {
                UserName = user.UserName!,
                Email = user.Email!,
                UserId = user.Id,
                AccessToken = _tokenService.CreateToken(user)
            };

            return new Result<LoginResponse> { IsSuccess = true, Message = "Login Successful", Value = response };
        }

        public async Task<Result<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var existingUser = await mgr.FindByEmailAsync(request.Email);
            if (existingUser is not null) return new Result<RegistrationResponse> { IsSuccess = false, Message = "User with the provided email already exist" };

            existingUser = await mgr.FindByNameAsync(request.UserName);
            if (existingUser is not null) return new Result<RegistrationResponse> { IsSuccess = false, Message = "User with the provided user name already exist" };

            var user = new User
            {
                Email = request.Email,
                UserName = request.UserName,
            };

           var result =  await mgr.CreateAsync(user, request.Password);

           if(!result.Succeeded) return new Result<RegistrationResponse> { IsSuccess = false, Message = "User registration failed" };

            var userToReturn = new RegistrationResponse
            {
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName
            };

            return new Result<RegistrationResponse> { IsSuccess = true, Message = "User created successfully", Value = userToReturn};
        }
    }
}
