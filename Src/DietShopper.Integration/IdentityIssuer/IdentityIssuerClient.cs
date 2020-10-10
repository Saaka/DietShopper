using System.Threading.Tasks;
using DietShopper.Application.Auth.Models;
using DietShopper.Application.Auth.Services;
using DietShopper.Shared.Exceptions;
using DietShopper.Shared.Http;
using RestSharp;

namespace DietShopper.Integration.IdentityIssuer
{
    public class IdentityIssuerClient : IGoogleAuthorizationClient
    {
        private readonly IRestsharpClientFactory _restsharpClientFactory;
        private readonly IIdentityIssuerConfiguration _configuration;

        public IdentityIssuerClient(
            IRestsharpClientFactory restsharpClientFactory,
            IIdentityIssuerConfiguration configuration)
        {
            _restsharpClientFactory = restsharpClientFactory;
            _configuration = configuration;
        }

        public async Task<AuthorizationData> AuthorizeWithGoogleToken(string googleToken)
        {
            var client = CreateClient();
            var request = _restsharpClientFactory.CreateRequest("api/auth/google", Method.POST)
                .AddJsonBody(new {GoogleToken = googleToken});

            var response = await client.ExecuteAsync<AuthorizationData>(request);

            return response.IsSuccessful
                ? response.Data
                : throw new ExternalCommunicationException(response.ErrorMessage ?? response.StatusCode.ToString());
        }

        private IRestClient CreateClient()
        {
            var client = _restsharpClientFactory.CreateClient(_configuration.ApiUrl);
            client.AddDefaultHeader("X-Tenant-Code", _configuration.AppCode);

            return client;
        }
    }
}