using DonationAPI.Requests;
using DonationAPI.Responses;

namespace DonationAPI.Services
{
    public interface IAccountService
    {
        Task<Result<RegistrationResponse>> Register(RegistrationRequest request);
        Task<Result<LoginResponse>> Login(LoginRequest request);
    }
}
