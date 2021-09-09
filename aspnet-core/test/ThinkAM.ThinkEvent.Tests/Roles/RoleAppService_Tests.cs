using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using ThinkAM.ThinkEvent.Authorization;
using ThinkAM.ThinkEvent.Roles;
using ThinkAM.ThinkEvent.Roles.Dto;
using ThinkAM.ThinkEvent.Tests.Users;
using ThinkAM.ThinkEvent.Users;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Roles
{
    [Collection(nameof(RolesBogusCollection))]
    public class RoleAppService_Tests : ThinkEventTestBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly RoleTestBogusFixture _roleTestFixture;

        private readonly IUserAppService _userAppService;
        private readonly UserTestBogusFixture _userTestFixture;

        public RoleAppService_Tests(RoleTestBogusFixture roleTestFixture)
        {
            _roleTestFixture = roleTestFixture;
            _userTestFixture = new UserTestBogusFixture();
            _roleAppService = Resolve<IRoleAppService>();
            _userAppService = Resolve<IUserAppService>();
        }

        [Theory(DisplayName = "Get Roles")]
        [Trait("Category", "Role")]
        [InlineData(4)]
        [InlineData(2)]
        [InlineData(1)]
        public async Task Should_Get_Roles(int length)
        {
            // Arrange
            var roles = _roleTestFixture.GenerateCreateRoleDtos(length);
            var tasks = roles.Select(role => _roleAppService.CreateAsync(role)).ToArray();
            Task.WaitAll(tasks);


            // Act
            var output = await _roleAppService.GetRolesAsync(new GetRolesInput { Permission = PermissionNames.Pages_Users });

            // Assert
            output.Items.Count.ShouldBe(length + 1);
        }

        [Fact(DisplayName = "Create Role")]
        [Trait("Category", "Role")]
        public async Task Should_Create_Role()
        {
            // Arrange
            var role = _roleTestFixture.GetValidCreateRoleDto();

            // Act
            await _roleAppService.CreateAsync(role);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Roles.FirstOrDefaultAsync(u => u.Name == role.Name);
                output.ShouldNotBeNull();
            });
        }

        [Fact(DisplayName = "GetA ll Permissions")]
        [Trait("Category", "Role")]
        public async Task Should_Get_All_Permissions()
        {
            // Arrange && Act 
            var output = await _roleAppService.GetAllPermissions();

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);

        }


        [Fact(DisplayName = "Delete")]
        [Trait("Category", "Role")]
        public async Task Should_Delete_Role()
        {
            // Arrange
            var role = _roleTestFixture.GetValidCreateRoleDto();
            var roleCreated = await _roleAppService.CreateAsync(role);

            // Act
            await _roleAppService.DeleteAsync(roleCreated);


            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Roles.FindAsync(roleCreated.Id);
                output.IsDeleted.ShouldBe(true);
            });

        }


        [Fact(DisplayName = "Delete With Users")]
        [Trait("Category", "Role")]
        public async Task Should_Delete_Role_With_Users()
        {
            // Arrange
            var role = _roleTestFixture.GetValidCreateRoleDto();
            var roleCreated = await _roleAppService.CreateAsync(role);

            var user = _userTestFixture.GetValidCreateUserDto();
            user.RoleNames = new[] { role.Name };
            await _userAppService.CreateAsync(user);

            // Act
            await _roleAppService.DeleteAsync(roleCreated);


            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Roles.FindAsync(roleCreated.Id);
                output.IsDeleted.ShouldBe(true);
            });

        }


        [Fact(DisplayName = "Update")]
        [Trait("Category", "Role")]
        public async Task Should_Update_Role()
        {
            // Arrange
            const string newName = "edited";
            var role = _roleTestFixture.GetValidCreateRoleDto();
            var roleCreated = await _roleAppService.CreateAsync(role);
            roleCreated.Name = newName;

            // Act
            await _roleAppService.UpdateAsync(roleCreated);


            // Assert
            await UsingDbContextAsync(async context =>
            {
                var output = await context.Roles.FindAsync(roleCreated.Id);
                output.Name.ShouldBe(newName);
            });
        }

        [Fact(DisplayName = "Get Role For Edit")]
        [Trait("Category", "Role")]
        public async Task Should_Get_Role_For_Edit()
        {
            // Arrange
            var role = _roleTestFixture.GetValidCreateRoleDto();
            var roleCreated = await _roleAppService.CreateAsync(role);

            // Act
            var output = await _roleAppService.GetRoleForEdit(new EntityDto(roleCreated.Id));

            // Assert
            output.Role.Name.ShouldBe(role.Name);
            output.GrantedPermissionNames.Count.ShouldBe(role.GrantedPermissions.Count);
        }




    }
}
