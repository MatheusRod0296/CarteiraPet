using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Bogus;
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
        public Faker _faker;
        public string _emailUser = string.Empty;
        public string _passwordUser = string.Empty;

        public IntegrationTestsFixture() {
            Factory = new CarteiraPetFactory();
            Client = Factory.CreateClient();
            _faker = new Faker("pt_BR");
        }

        public string GetAntiForgeryToken(string htmlBody)
        {
            var requestVerificationTokenMatch = Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFildName}"" type=""hidden"" value=""([^""]+)"" \/\>");
            
            if(requestVerificationTokenMatch.Success)
                return requestVerificationTokenMatch.Groups[1].Captures[0].Value;

            throw new ArgumentException($"Anti forgery token '{AntiForgeryFildName}' não encontrado no HTML", htmlBody);
        }

        public void GenerateUserAndPassword()
        {
            _emailUser = _faker.Internet.Email();
            _passwordUser = _faker.Internet.Password(8, false, "", "A@a");
        }

        public void Dispose()
        {
            Factory.Dispose();
            Client.Dispose();
        }
    }
}
