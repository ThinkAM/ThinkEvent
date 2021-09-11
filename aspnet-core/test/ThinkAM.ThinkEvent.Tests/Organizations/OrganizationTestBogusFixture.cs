using System.Collections.Generic;
using System.Linq;
using ThinkAM.ThinkEvent.Organizations.Dto;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Organizations
{
    [CollectionDefinition(nameof(OrganizationsBogusCollection))]
    public class OrganizationsBogusCollection : ICollectionFixture<OrganizationTestBogusFixture>
    { }

    public class OrganizationTestBogusFixture : ThinkEventBogustBase
    {
        public IEnumerable<CreateOrganizationTypeDto> GenerateCreateOrganizationTypeDto(int length)
        {
            var organizationTypes = GetFaker<CreateOrganizationTypeDto>()
                .CustomInstantiator(f => new CreateOrganizationTypeDto
                {
                    Name = f.Name.JobType()
                });
            return organizationTypes.Generate(length);
        }

        public CreateOrganizationTypeDto GetValidCreateOrganizationTypeDto()
        {
            return GenerateCreateOrganizationTypeDto(1).FirstOrDefault();
        }
    }
}
