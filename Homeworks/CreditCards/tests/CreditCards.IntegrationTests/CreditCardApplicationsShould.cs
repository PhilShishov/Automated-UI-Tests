
namespace CreditCards.IntegrationTests
{
    using System.Threading.Tasks;

    using Xunit;

    public class CreditCardApplicationsShould : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public CreditCardApplicationsShould(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task RenderApplicationForm()
        {
            var response = await _fixture.Client.GetAsync("/Apply");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("New Credit Card Application", responseString);
        }
    }
}
