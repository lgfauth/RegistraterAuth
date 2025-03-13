using Application.Models;
using Application.Models.Envelope;

namespace Application.Interfaces
{
    public interface IApiAuthenticationService
    {
        public Task<IResponse<AuthResponse>> AuthenticateUserAsync(string username, string password);
    }
}
