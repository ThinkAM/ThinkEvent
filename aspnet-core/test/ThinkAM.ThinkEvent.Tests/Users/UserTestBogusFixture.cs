using System.Collections.Generic;
using System.Linq;
using ThinkAM.ThinkEvent.Users.Dto;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Users
{
    [CollectionDefinition(nameof(UserBogusCollection))]
    public class UserBogusCollection : ICollectionFixture<UserTestBogusFixture>
    { }

    public class UserTestBogusFixture : ThinkEventBogustBase
    {
        public IEnumerable<CreateUserDto> GenerateCreateUserDto(int length, bool isActive = true)
        {
            var gender = GetGender();

            var users = GetFaker<CreateUserDto>()
                .CustomInstantiator(f => new CreateUserDto
                {
                    IsActive = isActive,
                    Name = f.Name.FirstName(gender),
                    Surname = f.Name.LastName(gender),
                    Password = NewPassword(),
                })
                .RuleFor(c => c.EmailAddress,
                    (f, u) => f.Internet.Email(u.Name.ToLower(), u.Surname.ToLower()))
                .RuleFor(c => c.UserName,
                    (f, u) => f.Internet.UserName(u.Name.ToLower(), u.Surname.ToLower()));

            return users.Generate(length);
        }
        
        public CreateUserDto GetValidCreateUserDto(bool isActive = true)
        {
            return GenerateCreateUserDto(1, isActive).FirstOrDefault();
        }
    }
}
