using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using ThinkAM.ThinkEvent.Organizations;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Organizations
{
    [Collection(nameof(OrganizationsBogusCollection))]
    public class OrganizationTypeAppService_Tests : ThinkEventTestBase
    {
        private readonly IOrganizationTypeAppService _organizationTypeAppService;
        private readonly OrganizationTestBogusFixture _organizationTestFixture;

        public OrganizationTypeAppService_Tests(OrganizationTestBogusFixture organizationTestFixture)
        {
            _organizationTestFixture = organizationTestFixture;
            _organizationTypeAppService = Resolve<IOrganizationTypeAppService>(); ;
        }

        [Fact]
        public async Task GetOrganizationTypes_Test()
        {
            // Arrange
            var createOrganizationTypeDto = _organizationTestFixture.GetValidCreateOrganizationTypeDto();
            await _organizationTypeAppService.CreateAsync(createOrganizationTypeDto);

            // Act
            var output = await _organizationTypeAppService.GetAllAsync(new PagedResultRequestDto { MaxResultCount = 1 });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateOrganizationType_Test()
        {
            // Arrange
            var createOrganizationTypeDto = _organizationTestFixture.GetValidCreateOrganizationTypeDto();

            // Act
            await _organizationTypeAppService.CreateAsync(createOrganizationTypeDto);

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var organizationType = await context.OrganizationTypes.FirstOrDefaultAsync(u => u.Name == createOrganizationTypeDto.Name);
                organizationType.ShouldNotBeNull();
            });
        }



    }
}
