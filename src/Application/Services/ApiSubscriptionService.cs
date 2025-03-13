using Application.Interfaces;
using Application.Models;
using Application.Models.Envelope;
using Application.Settings;
using System.Net.Http.Json;

namespace Application.Services
{
    public class ApiSubscriptionService : ApiServiceBase, IApiSubscriptionService
    {
        public ApiSubscriptionService(IHttpClientFactory clientFactory, BackendConfiguration backendConfiguration) :
            base(clientFactory, backendConfiguration)
        { }

        public async Task<IResponse<ResponseModel>> RegisterUserAsync(SubscriptionRequest request)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var response = await client.PostAsJsonAsync(_registrationUrl, request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<ResponseModel>();

                    return new ResponseError<ResponseModel>(error!);
                }

                var success = await response.Content!.ReadFromJsonAsync<ResponseModel>();

                return new ResponseOk<ResponseModel>(success!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(new { timestamp = DateTime.UtcNow, exception = ex });

                return new ResponseError<ResponseModel>(ResponseModel.InternalError());
            }
        }
    }
}