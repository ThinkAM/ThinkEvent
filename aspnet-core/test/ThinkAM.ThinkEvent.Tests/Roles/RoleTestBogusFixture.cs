using System.Collections.Generic;
using System.Linq;
using ThinkAM.ThinkEvent.Roles.Dto;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Roles
{

    [CollectionDefinition(nameof(RolesBogusCollection))]
    public class RolesBogusCollection : ICollectionFixture<RoleTestBogusFixture>
    { }
    public class RoleTestBogusFixture : ThinkEventBogustBase
    {
        public IEnumerable<CreateRoleDto> GenerateCreateRoleDtos(int length)
        {
            var roles = GetFaker<CreateRoleDto>().CustomInstantiator(f =>
                new CreateRoleDto
                {
                    Name = f.Lorem.Word() + f.UniqueIndex,
                    Description = f.Lorem.Sentence(),
                    DisplayName = f.Lorem.Word(),
                    GrantedPermissions = GetPermissions()
                });
            return roles.Generate(length);
        }

        public CreateRoleDto GetValidCreateRoleDto()
        {
            return GenerateCreateRoleDtos(1).FirstOrDefault();
        }

       
    }
}