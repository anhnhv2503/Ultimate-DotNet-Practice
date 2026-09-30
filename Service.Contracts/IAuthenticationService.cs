using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);
        Task<bool> ValidateUser(AuthentiationRequest authRequest);
        Task<string> CreateToken(); //Deprecated
        Task<TokenDto> CreateToken(bool populateExp);
        Task<User> GetAuthenticatedUser();
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
