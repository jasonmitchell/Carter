namespace Carter.Tests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;

    public class RequestRouteTests
    {
        public RequestRouteTests()
        {
            this.server = new TestServer(new WebHostBuilder()
                .ConfigureServices(x => { x.AddCarter(); })
                .Configure(x => x.UseCarter())
            );
            this.httpClient = this.server.CreateClient();
        }

        private readonly TestServer server;

        private readonly HttpClient httpClient;
        
        [Fact]
        public async Task Should_return_GET_requests()
        {
            var response = await this.httpClient.GetAsync("/requestroute");

            Assert.Equal(200, (int)response.StatusCode);
        }
    }
}
