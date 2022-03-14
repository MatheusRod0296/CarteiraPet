using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CarteiraPet.IntegrationTests.Fixtures;
using CarteiraPet.IntegrationTests.Ordering;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace CarteiraPet.IntegrationTests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    [TestCaseOrderer("CarteiraPet.IntegrationTests.Ordering.PriorityOrderer", "CarteiraPet.IntegrationTests")]
    public class UserTests
    {
        private readonly IntegrationTestsFixture _fixture;
        
        public UserTests(IntegrationTestsFixture fixture) {
            _fixture = fixture;
        }

        [Fact, TestPriority(1)]
        public async Task ShouldSignUp()
        {
            var initalRespose = await _fixture.Client.GetAsync("/Identity/Account/Register");
            initalRespose.EnsureSuccessStatusCode();

            var antiForgeryToken = _fixture.GetAntiForgeryToken(await initalRespose.Content.ReadAsStringAsync());

           _fixture.GenerateUserAndPassword();
            var formData = new Dictionary<string, string>
            {
                {_fixture.AntiForgeryFildName, antiForgeryToken},
                {"input.Email", _fixture._emailUser },
                {"Input.Password", _fixture._passwordUser},
                {"Input.ConfirmPassword",  _fixture._passwordUser},
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Identity/Account/Register")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            var response = await _fixture.Client.SendAsync(postRequest);

            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            responseString.Should().Contain($"Hello {_fixture._emailUser}");
        }
        
        [Fact, TestPriority(2)]
        public async Task ShouldSignIn()
        {
            var initalRespose = await _fixture.Client.GetAsync("/Identity/Account/Login");
            initalRespose.EnsureSuccessStatusCode();

            var antiForgeryToken = _fixture.GetAntiForgeryToken(await initalRespose.Content.ReadAsStringAsync());

            var formData = new Dictionary<string, string>
            {
                {_fixture.AntiForgeryFildName, antiForgeryToken},
                {"input.Email", _fixture._emailUser },
                {"Input.Password", _fixture._passwordUser}
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Identity/Account/Login")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            var response = await _fixture.Client.SendAsync(postRequest);

            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            responseString.Should().Contain($"Hello {_fixture._emailUser}");
        }
    }
}
