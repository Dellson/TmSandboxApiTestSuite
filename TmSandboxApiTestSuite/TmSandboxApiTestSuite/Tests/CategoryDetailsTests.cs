using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using TmSandboxApiTestSuite.Configuration;
using TmSandboxApiTestSuite.Model;

namespace TmSandboxApiTestSuite.Tests
{
    [TestClass]
    public class CategoryDetailsTests
    {
        private const string _path = "v1/Categories/6327/Details.json?catalogue=false";
        private RestClient _client;

        [TestInitialize]
        public void SetUp()
        {
            var config = new AppConfiguration();
            _client = new RestClient(config.BaseUrl);
        }

        [TestMethod]
        async public Task GetCategory6327Details_WhenCatalogueIsFalse_ReturnsCorrectName()
        {
            // Arrange
            RestRequest request = new RestRequest(_path);

            // Act
            RestResponse<CategoryDetails> response = await _client.ExecuteGetAsync<CategoryDetails>(request);

            // Assert
            response.Data.Name
                .Should().Be("Carbon credits");
        }

        [TestMethod]
        async public Task GetCategory6327Details_WhenCatalogueIsFalse_ReturnsCorrectCanRelistValue()
        {
            // Arrange
            RestRequest request = new RestRequest(_path);

            // Act
            RestResponse<CategoryDetails> response = await _client.ExecuteGetAsync<CategoryDetails>(request);

            // Assert
            response.Data.CanRelist
               .Should().BeTrue();
        }

        [TestMethod]
        async public Task GetCategory6327Details_WhenCatalogueIsFalse_ReturnsCorrectDescriptionForDistinctPromotionsGallery()
        {
            // Arrange
            RestRequest request = new RestRequest(_path);

            // Act
            RestResponse<CategoryDetails> response = await _client.ExecuteGetAsync<CategoryDetails>(request);

            // Assert
            response.Data.Promotions.Where(p => p.Name == "Gallery").Should().HaveCount(1);
            response.Data.Promotions.Single(p => p.Name == "Gallery").Description
                .Should().Contain("Good position in category");
        }
    }
}