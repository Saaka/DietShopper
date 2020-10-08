using Microsoft.Extensions.Configuration;

namespace DietShopper.Integration.IdentityIssuer
{
    public interface IIdentityIssuerConfiguration
    {
        public string AppCode { get; }
        public string ApiUrl { get; }
    }
    
    public class IdentityIssuerConfiguration : IIdentityIssuerConfiguration
    {
        private readonly IConfiguration _configuration;
        private const string AppCodeConfigName = "Auth:AppCode";
        private const string ApiUrlConfigName = "Auth:IdentityIssuerUrl";

        public IdentityIssuerConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AppCode => _configuration[AppCodeConfigName];
        public string ApiUrl => _configuration[ApiUrlConfigName];
    }
}