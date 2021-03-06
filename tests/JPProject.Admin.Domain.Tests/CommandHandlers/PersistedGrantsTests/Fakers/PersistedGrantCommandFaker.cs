using Bogus;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Domain.Commands.PersistedGrant;

namespace JPProject.Admin.Domain.Tests.CommandHandlers.PersistedGrantsTests.Fakers
{
    public class PersistedGrantCommandFaker
    {
        public static Faker<RemovePersistedGrantCommand> GenerateRemoveCommand(string name = null)
        {
            return new Faker<RemovePersistedGrantCommand>().CustomInstantiator(c => new RemovePersistedGrantCommand(c.Company.CompanyName()));
        }
    }
    public class PersistedGrantFaker
    {
        public static Faker<PersistedGrantViewModel> GeneratePersstedGrant(string key = null)
        {
            return new Faker<PersistedGrantViewModel>().CustomInstantiator(
                    f => new PersistedGrantViewModel(
                        key ?? f.Random.String(10, 20),
                        f.Lorem.Word(),
                        f.Random.Guid().ToString(),
                        f.Internet.DomainName(),
                        f.Date.Recent(),
                        f.Date.Future(),
                        f.Lorem.Word()
                        )
                    );
        }
    }
}
