using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Domain;
using Handlers;
using Xunit;

namespace Tests
{
    public class HandlerTests
    {
        [Fact]
        public void TestToUpperFunction()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var handler = new Handler();
            var context = new TestLambdaContext();
            var upperCase = handler.ToUpper("hello world", context);

            Assert.Equal("HELLO WORLD", upperCase);
        }
    
        [Fact]
        public void TestHealthCheck()
        {
            var handler = new Handler();

            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();

            var response = handler.HealthCheck(request, context);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal("OK", response.Body);
        }

        [Fact]
        public void TestHello()
        {
            var handler = new Handler();

            var context = new TestLambdaContext();

            var response = handler.Hello(new Request(), context);

            Assert.NotNull(response);
        }
    }
}
