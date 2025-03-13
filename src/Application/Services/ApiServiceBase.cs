using Application.Settings;

namespace Application.Services
{
    public class ApiServiceBase
    {
        protected readonly IHttpClientFactory _clientFactory;
        protected readonly string _registrationUrl;
        protected readonly string _authenticationUrl;

        public ApiServiceBase(IHttpClientFactory clientFactory, BackendConfiguration backendConfiguration)
        {
            _clientFactory = clientFactory;
            _authenticationUrl = string.Concat(backendConfiguration.BaseUrl, backendConfiguration.LoginPath);
            _registrationUrl = string.Concat(backendConfiguration.BaseUrl, backendConfiguration.RegisterPath);
        }
    }
}
