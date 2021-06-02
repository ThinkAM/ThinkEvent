using System.Threading.Tasks;
using ThinkAM.ThinkEvent.Models.TokenAuth;
using ThinkAM.ThinkEvent.Web.Controllers;
using Shouldly;
using Xunit;

namespace ThinkAM.ThinkEvent.Web.Tests.Controllers
{
    public class HomeController_Tests: ThinkEventWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}