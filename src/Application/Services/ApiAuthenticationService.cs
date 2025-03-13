using Application.Interfaces;
using Application.Models;
using Application.Models.Envelope;
using Application.Settings;
using System.Net.Http.Json;

namespace Application.Services
{
    public class ApiAuthenticationService : ApiServiceBase, IApiAuthenticationService
    {
        public ApiAuthenticationService(IHttpClientFactory clientFactory, BackendConfiguration backendConfiguration) : 
            base(clientFactory, backendConfiguration)
        { }

        public async Task<IResponse<AuthResponse>> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var response = await client.PostAsJsonAsync(_authenticationUrl, new { username, password });

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<ResponseModel>();

                    return new ResponseError<AuthResponse>(error!);
                }

                var success = await response.Content!.ReadFromJsonAsync<AuthResponse>();

                return new ResponseOk<AuthResponse>(success!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(new { timestamp = DateTime.UtcNow, exception = ex });

                return new ResponseError<AuthResponse>(ResponseModel.InternalError());
            }
        }
    }
}