using System.Collections.Generic;
using ThinkAM.ThinkEvent.Authorization.Accounts.Dto;
using Xunit;

namespace ThinkAM.ThinkEvent.Tests.Authorization
{

    [CollectionDefinition(nameof(AccountBogusCollection))]
    public class AccountBogusCollection : ICollectionFixture<AccountTestBogusFixture>
    { }
    public class AccountTestBogusFixture : ThinkEventBogustBase
    {
        public List<RegisterInput> GenerateRegisterInput(int length)
        {
            var gender = GetGender();

            var users = GetFaker<RegisterInput>()
                .CustomInstantiator(f => new RegisterInput
                {
                    Name = f.Name.FirstName(gender),
                    Surname = f.Name.LastName(gender),
                    Password = NewPassword(),
                })
                .RuleFor(c => c.EmailAddress,
                    (f, u) => f.Internet.Email(firstName: u.Name.ToLower(), lastName: u.Surname.ToLower()))
                .RuleFor(c => c.UserName,
                    (f, u) => f.Internet.UserName(firstName: u.Name.ToLower(), lastName: u.Surname.ToLower()));

            return users.Generate(length);
        }

        public RegisterInput GetValidRegisterInput()
        {
            return GenerateRegisterInput(1)[0];
        }


    }
}