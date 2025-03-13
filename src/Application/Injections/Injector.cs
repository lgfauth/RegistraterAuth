using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Injections
{
    public class Injector
    {
        public static void DependenceInjection(IServiceCollection services)
        {
            services.AddHttpClient<ApiServiceBase>();

            services.AddSingleton<IApiSubscriptionService, ApiSubscriptionService>();
            services.AddSingleton<IApiAuthenticationService, ApiAuthenticationService>();
        }
    }
}
