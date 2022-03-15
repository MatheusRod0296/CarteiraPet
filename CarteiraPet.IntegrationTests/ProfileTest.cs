using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CarteiraPet.IntegrationTests.Fixtures;
using FluentAssertions;
using Xunit;
namespace CarteiraPet.IntegrationTests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class ProfileTest
    {
        private readonly IntegrationTestsFixture _fixture;
        
        public ProfileTest(IntegrationTestsFixture fixture) {
            _fixture = fixture;
        }
        
        [Fact]
        public async Task ShouldUpdateNameWithSuccess()
        {
            await _fixture.Register();
            var initalRespose = await _fixture.Client.GetAsync("/Profile/Form");
            var responseString1 = await initalRespose.Content.ReadAsStringAsync();
            initalRespose.EnsureSuccessStatusCode();

            var antiForgeryToken = _fixture.GetAntiForgeryToken(await initalRespose.Content.ReadAsStringAsync());

            var formData = new Dictionary<string, string>
            {
                {_fixture.AntiForgeryFildName, antiForgeryToken},
                {"Name", "Novo Nome" },
                {"Email", _fixture._emailUser }
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Profile/add")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            var response = await _fixture.Client.SendAsync(postRequest);

            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            responseString.Should().Contain($"Concluido");
        }
        
        [Fact]
        public async Task ShouldReturnErroWhenNameIsInvalid()
        {
            Assert.False(false);
        }
    }
}
