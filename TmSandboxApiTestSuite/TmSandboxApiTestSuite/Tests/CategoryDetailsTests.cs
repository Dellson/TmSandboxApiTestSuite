using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
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
            var basePath = "https://api.tmsandbox.co.nz";
            _client = new RestClient(basePath);
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
    }
}