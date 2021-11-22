using System.Threading.Tasks;
using ABPCommerce.Models.TokenAuth;
using ABPCommerce.Web.Controllers;
using Shouldly;
using Xunit;

namespace ABPCommerce.Web.Tests.Controllers
{
    public class HomeController_Tests: ABPCommerceWebTestBase
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