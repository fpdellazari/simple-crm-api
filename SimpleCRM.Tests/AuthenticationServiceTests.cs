using Moq;
using SimpleCRM.Application.Services.Authentication;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Xunit;
using System.Threading.Tasks;

namespace SimpleCRM.Tests {
    public class AuthenticationServiceTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly AuthenticationService _authenticationService;

        public AuthenticationServiceTests() {
            _configurationMock = new Mock<IConfiguration>();
            _tokenServiceMock = new Mock<ITokenService>();

            _configurationMock.Setup(c => c["Jwt:PrivateKey"]).Returns("some-secret-key");
            _configurationMock.Setup(c => c["Jwt:ExpireMinutes"]).Returns("60");

            _authenticationService = new AuthenticationService(_configurationMock.Object, _tokenServiceMock.Object);
        }

        [Fact]
        public async Task Authenticate_ValidCredentials_ReturnsToken() {

            // Arrange
            var authenticationModel = new AuthenticationModel {
                Username = "admin",
                Password = "m5sAI0jGW83bQenkzP4t"
            };

            var expectedToken = "fake-jwt-token";
            _tokenServiceMock.Setup(ts => ts.Generate(It.IsAny<string>())).Returns(expectedToken);

            // Act
            var result = await _authenticationService.Authenticate(authenticationModel);

            // Assert
            Assert.Equal(expectedToken, result);
        }

        [Fact]
        public async Task Authenticate_InvalidCredentials_ReturnsEmptyString() {

            // Arrange
            var authenticationModel = new AuthenticationModel {
                Username = "wrong-user",
                Password = "wrong-password"
            };

            // Act
            var result = await _authenticationService.Authenticate(authenticationModel);

            // Assert
            Assert.Equal("", result);
        }
    }
}