using DonationAPI.Entities;

namespace DonationAPI.Services
{
    public interface ITokenService
    {
      string CreateToken(User user);
    }
}
