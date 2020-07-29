using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Picoage.MediatR.WebApi.AcceptanceTests.Controllers
{

    public class AuthenticationControllerTests : AcceptanceTestStartup
    {
        public AuthenticationControllerTests() : base(false)
        {

        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "password")]
        [InlineData("username", null)]
        [InlineData("", "")]
        public async Task When_Invalid_Request_Provided_Then_Return_BadRequest(string username, string password)
        {
            //Arrange
            Username = username;
            Password = password;

            //Act
            string result = await GetBearerToken(Client);

            //Assert
            Assert.Null(result);
            Assert.Equal(HttpStatusCode.BadRequest, StatusCode);
        }

        [Fact]
        public async Task Given_Valid_Request_When_Resource_NotExsists_Then_Return_No_Token_And_StatusCode_NoContent()
        {
            //Arrange
            Username = "testuser";
            Password = "password"; 

            //Act
            string token = await GetBearerToken(Client);

            //Assert
            Assert.Null(token);
            Assert.Equal(HttpStatusCode.NoContent, StatusCode);
        }


        [Fact]
        public async Task When_Valid_UserName_Or_Password_Provided_Then_Return_Token()
        {
            //Arrange and act
            string token = await GetBearerToken(Client);

            //Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
    }
}
