using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using ThinkAM.ThinkEvent.Authorization;

namespace ThinkAM.ThinkEvent.Tests
{
    public abstract class ThinkEventBogustBase
    {
        private const string Locale = "pt_BR";
        protected Faker Faker { get; }

        protected ThinkEventBogustBase(string locale = Locale)
        {
            Faker = new Faker(locale);
        }

        protected virtual Faker<T> GetFaker<T>(string locale = Locale) where T : class
        {
            return new Faker<T>(locale);
        }

        protected Name.Gender GetGender()
        {
            return Faker.PickRandom<Name.Gender>();
        }

        public string NewPassword()
        {
            return Faker.Internet.Password(length: 8, prefix: "Te1@");
        }

        protected List<string> GetPermissions() =>
            new()
            {
                PermissionNames.Pages_Roles,
                PermissionNames.Pages_Users,
                PermissionNames.Pages_Users_Activation,
            };
    }
}