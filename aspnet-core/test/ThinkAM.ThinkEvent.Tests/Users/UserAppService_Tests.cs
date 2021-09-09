using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using ThinkAM.ThinkEvent.Users;
using ThinkAM.ThinkEvent.Users.Dto;

namespace ThinkAM.ThinkEvent.Tests.Users
{
    [Collection(nameof(UserBogusCollection))]
    public class UserAppService_Tests : ThinkEventTestBase
    {
        private readonly IUserAppService _userAppService;
        private readonly UserTestBogusFixture _userTestFixture;

        public UserAppService_Tests(UserTestBogusFixture userTestFixture)
        {
            _userTestFixture = userTestFixture;
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact(DisplayName = "Get All")]
        [Trait("Category", "User")]
        public async Task Should_Get_All_Users()
        {
            // Act
            var output = await _userAppService.GetAllAsync(new PagedUserResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact(DisplayName = "Create")]
        [Trait("Category", "User")]
        public async Task Should_Create_User()
        {
            // Arrange
            var user = _userTestFixture.GetValidCreateUserDto();

            // Act
            await _userAppService.CreateAsync(user);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
                output.ShouldNotBeNull();
            });
        }

        [Fact(DisplayName = "Update")]
        [Trait("Category", "User")]
        public async Task Should_Update_User()
        {
            // Arrange
            var user = _userTestFixture.GetValidCreateUserDto();
            var userCreated = await _userAppService.CreateAsync(user);
            userCreated.Name = "Edited";
            // Act

            await _userAppService.UpdateAsync(userCreated);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Users.FindAsync(userCreated.Id);
                output.Name.ShouldBe(userCreated.Name);
            });
        }

        [Fact(DisplayName = "Delete")]
        [Trait("Category", "User")]
        public async Task Should_Delete_User()
        {
            // Arrange
            var user = _userTestFixture.GetValidCreateUserDto();
            var userCreated = await _userAppService.CreateAsync(user);

            // Act
            await _userAppService.DeleteAsync(userCreated);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Users.FindAsync(userCreated.Id);
                output.IsDeleted.ShouldBeTrue();
            });
        }

        [Fact(DisplayName = "De Activate")]
        [Trait("Category", "User")]
        public async Task Should_De_Activate_User()
        {
            // Arrange
            var user = _userTestFixture.GetValidCreateUserDto();
            var userCreated = await _userAppService.CreateAsync(user);

            // Act
            await _userAppService.DeActivate(userCreated);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Users.FindAsync(userCreated.Id);
                output.IsActive.ShouldBeFalse();
            });
        }

       
        [Fact(DisplayName = "Activate")]
        [Trait("Category", "User")]
        public async Task Should_Activate_User()
        {
            // Arrange
            var user = _userTestFixture.GetValidCreateUserDto(false);

            var userCreated = await _userAppService.CreateAsync(user);

            // Act
            await _userAppService.Activate(userCreated);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Users.FindAsync(userCreated.Id);
                output.IsActive.ShouldBeTrue();
            });
        }

        [Fact(DisplayName = "Get Roles")]
        [Trait("Category", "User")]
        public async Task Should_Get_Roles()
        {
            // Arrange

            // Act
            var roles = await _userAppService.GetRoles();

            // Assert
            roles.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
