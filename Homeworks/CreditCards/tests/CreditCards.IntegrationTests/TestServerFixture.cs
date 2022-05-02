
namespace CreditCards.IntegrationTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.DotNet.PlatformAbstractions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Primitives;
    using Microsoft.Net.Http.Headers;

    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        public static readonly string AntiForgeryFieldName = "__AFTField";
        public static readonly StringSegment AntiForgeryCookieName = new StringSegment("AFTCookie");

        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(GetContentRootPath())
                .UseEnvironment("Development")
                .UseStartup<CreditCards.Startup>()
                .ConfigureServices(x =>
                {
                    x.AddAntiforgery(t =>
                    {
                        t.Cookie.Name = AntiForgeryCookieName.ToString();
                        t.FormFieldName = AntiForgeryFieldName;
                    });
                });

            _testServer = new TestServer(builder);

            Client = _testServer.CreateClient();
        }

        public static async Task<(string fieldValue, string cookieValue)> ExtractAntiForgeryValues(HttpResponseMessage response)
        {
            return (ExtractAntiForgeryToken(await response.Content.ReadAsStringAsync().ConfigureAwait(false)),
                                            ExtractAntiForgeryCookieValueFrom(response));
        }

        private static string GetContentRootPath()
        {
            string testProjectPath = ApplicationEnvironment.ApplicationBasePath;

            var relativePathToWebProject = @"..\..\..\..\..\src\CreditCards";

            return Path.Combine(testProjectPath, relativePathToWebProject);
        }

        private static string ExtractAntiForgeryCookieValueFrom(HttpResponseMessage response)
        {
            string antiForgeryCookie =
                        response.Headers
                                .GetValues("Set-Cookie")
                                .FirstOrDefault(x => x.Contains(AntiForgeryCookieName.ToString()));

            if (antiForgeryCookie is null)
            {
                throw new ArgumentException(
                    $"Cookie '{AntiForgeryCookieName}' not found in HTTP response",
                    nameof(response));
            }

            var antiForgeryCookieValue =
                SetCookieHeaderValue.Parse(new StringSegment(antiForgeryCookie)).ToString();

            return antiForgeryCookieValue;
        }

        private static string ExtractAntiForgeryToken(string htmlBody)
        {
            var requestVerificationTokenMatch =
                Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFieldName}"" type=""hidden"" value=""([^""]+)"" \/\>");

            if (requestVerificationTokenMatch.Success)
            {
                return requestVerificationTokenMatch.Groups[1].Captures[0].Value;
            }

            throw new ArgumentException($"Anti forgery token '{AntiForgeryFieldName}' not found in HTML", nameof(htmlBody));
        }
        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}
