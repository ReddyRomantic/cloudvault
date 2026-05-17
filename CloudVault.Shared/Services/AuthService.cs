using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Threading.Tasks;

namespace CloudVault.Shared.Services
{
    public class AuthService
    {
        private readonly AmazonCognitoIdentityProviderClient _cognitoClient;
        private readonly string _clientId;

        public AuthService(AmazonCognitoIdentityProviderClient cognitoClient, string clientId)
        {
            _cognitoClient = cognitoClient;
            _clientId = clientId;
        }

        public async Task SignUpAsync(string username, string password, string email)
        {
            var request = new SignUpRequest
            {
                ClientId = _clientId,
                Username = username,
                Password = password,
                UserAttributes = new List<AttributeType>
                {
                    new AttributeType { Name = "email", Value = email }
                }
            };

            await _cognitoClient.SignUpAsync(request);
        }

        public async Task<string> SignInAsync(string username, string password)
        {
            var request = new AdminInitiateAuthRequest
            {
                UserPoolId = "your-user-pool-id",
                ClientId = _clientId,
                AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH,
                AuthParameters = new Dictionary<string, string>
                {
                    { "USERNAME", username },
                    { "PASSWORD", password }
                }
            };

            var response = await _cognitoClient.AdminInitiateAuthAsync(request);
            return response.AuthenticationResult.IdToken;
        }
    }
}