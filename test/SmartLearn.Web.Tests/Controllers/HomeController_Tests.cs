using System.Threading.Tasks;
using SmartLearn.Models.TokenAuth;
using SmartLearn.Web.Controllers;
using Shouldly;
using Xunit;

namespace SmartLearn.Web.Tests.Controllers
{
    public class HomeController_Tests: SmartLearnWebTestBase
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