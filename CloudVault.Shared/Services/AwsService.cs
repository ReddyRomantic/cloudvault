using Amazon;
using Amazon.S3;
using Amazon.DynamoDBv2;
using Amazon.CognitoIdentityProvider;

namespace CloudVault.Shared.Services
{
    public class AwsService
    {
        // S3 Client
        public AmazonS3Client S3Client { get; set; }

        // DynamoDB Client
        public AmazonDynamoDBClient DynamoDbClient { get; set; }

        // Cognito Client
        public AmazonCognitoIdentityProviderClient CognitoClient { get; set; }

        public AwsService(string region)
        {
            var awsRegion = RegionEndpoint.GetBySystemName(region);

            S3Client = new AmazonS3Client(awsRegion);
            DynamoDbClient = new AmazonDynamoDBClient(awsRegion);
            CognitoClient = new AmazonCognitoIdentityProviderClient(awsRegion);
        }
    }
}