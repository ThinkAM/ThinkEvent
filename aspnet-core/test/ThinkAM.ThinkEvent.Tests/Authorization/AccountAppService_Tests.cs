using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using ThinkAM.ThinkEvent.Authorization.Accounts;
using ThinkAM.ThinkEvent.Authorization.Accounts.Dto;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Authorization
{
    [Collection(nameof(AccountBogusCollection))]
    public class AccountAppService_Tests : ThinkEventTestBase
    {
        private readonly IAccountAppService _accountAppService;
        private readonly AccountTestBogusFixture _accountTestBogus;

        public AccountAppService_Tests(AccountTestBogusFixture accountTestBogus)
        {
            _accountTestBogus = accountTestBogus;
            _accountAppService = Resolve<IAccountAppService>();
        }

        [Fact(DisplayName = "Register")]
        [Trait("Category", "Account")]
        public async Task Should_Register()
        {
            // Arrange
            var registerInput = _accountTestBogus.GetValidRegisterInput();

            // Act
            await _accountAppService.Register(registerInput);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.UserAccounts.FirstOrDefaultAsync(u => u.UserName == registerInput.UserName);
                output.ShouldNotBeNull();
            });
        }

        [Fact(DisplayName = "Is TenantAvailable")]
        [Trait("Category", "Account")]
        public async Task Should_Is_Tenant_Available()
        {
            // Arrange
            var isTenantAvailableInput = new IsTenantAvailableInput { TenancyName = "Default" };

            // Act
            var tenant = await _accountAppService.IsTenantAvailable(isTenantAvailableInput);

            // Assert
            tenant.ShouldNotBeNull();
            tenant.State.ShouldBe(TenantAvailabilityState.Available);
        }
    }
}
