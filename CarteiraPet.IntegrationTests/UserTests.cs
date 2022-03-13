using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CarteiraPet.IntegrationTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace CarteiraPet.IntegrationTests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class UserTests
    {
        private readonly IntegrationTestsFixture _fixture;
        
        public UserTests(IntegrationTestsFixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public async Task RealizarCadastroComSucesso()
        {
            var initalRespose = await _fixture.Client.GetAsync("/Identity/Account/Register");
            initalRespose.EnsureSuccessStatusCode();

            var antiForgeryToken = _fixture.GetAntiForgeryToken(await initalRespose.Content.ReadAsStringAsync());

            var email = "email@email.com.br";
            var password = "abc123456";
            var formData = new Dictionary<string, string>
            {
                {_fixture.AntiForgeryFildName, antiForgeryToken},
                {"input.Email", email },
                {"Input.Password", password},
                {"Input.ConfirmPassword", password},
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Identity/Account/Register")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            var response = await _fixture.Client.SendAsync(postRequest);

            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            responseString.Should().Contain($"Hello {email}");
        }
    }
}
