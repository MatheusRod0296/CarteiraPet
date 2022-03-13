using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xunit;
namespace CarteiraPet.IntegrationTests.Fixtures
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection: ICollectionFixture<IntegrationTestsFixture>{}

    public class IntegrationTestsFixture : IDisposable
    {
        public string AntiForgeryFildName = "__RequestVerificationToken"; 
        
        public readonly CarteiraPetFactory Factory;
        public HttpClient Client;
        
        public IntegrationTestsFixture() {
            Factory = new CarteiraPetFactory();
            Client = Factory.CreateClient();
        }

        public string GetAntiForgeryToken(string htmlBody)
        {
            var requestVerificationTokenMatch = Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFildName}"" type=""hidden"" value=""([^""]+)"" \/\>");
            
            if(requestVerificationTokenMatch.Success)
                return requestVerificationTokenMatch.Groups[1].Captures[0].Value;

            throw new ArgumentException($"Anti forgery token '{AntiForgeryFildName}' não encontrado no HTML", htmlBody);
        }

        public void Dispose()
        {
            Factory.Dispose();
            Client.Dispose();
        }
    }
}
