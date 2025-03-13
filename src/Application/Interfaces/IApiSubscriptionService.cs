using Application.Models;
using Application.Models.Envelope;

namespace Application.Interfaces
{
    public interface IApiSubscriptionService
    {
        public Task<IResponse<ResponseModel>> RegisterUserAsync(SubscriptionRequest request);
    }
}
