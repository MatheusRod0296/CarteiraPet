using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
namespace CarteiraPet.IntegrationTests.Fixtures
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture> {}

    public class IntegrationTestsFixture : IDisposable
    {
        public string AntiForgeryFildName = "__RequestVerificationToken";

        public readonly CarteiraPetFactory Factory;
        public HttpClient Client;
        public Faker _faker;
        public string _emailUser = string.Empty;
        public string _passwordUser = string.Empty;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions()
            {
                HandleCookies = true,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };
            
            Factory = new CarteiraPetFactory();
            Client = Factory.CreateClient(clientOptions);
            _faker = new Faker("pt_BR");
        }

        public async Task Register()
        {
            var initalRespose = await Client.GetAsync("/Identity/Account/Register");
            initalRespose.EnsureSuccessStatusCode();

            var antiForgeryToken = GetAntiForgeryToken(await initalRespose.Content.ReadAsStringAsync());

            GenerateUserAndPassword();
            var formData = new Dictionary<string, string>
            {
                {AntiForgeryFildName, antiForgeryToken},
                {"input.Email", _emailUser },
                {"Input.Password", _passwordUser},
                {"Input.ConfirmPassword",  _passwordUser},
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Identity/Account/Register")
            {
                Content = new FormUrlEncodedContent(formData)
            };

             await Client.SendAsync(postRequest);
        }
        
        public string GetAntiForgeryToken(string htmlBody)
        {
            var requestVerificationTokenMatch = Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFildName}"" type=""hidden"" value=""([^""]+)"" \/\>");

            if ( requestVerificationTokenMatch.Success )
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
