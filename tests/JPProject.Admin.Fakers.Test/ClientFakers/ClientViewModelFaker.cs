using Bogus;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Application.ViewModels.ClientsViewModels;
using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Fakers.Test.ClientFakers
{
    public class ClientViewModelFaker
    {
        public static Faker<SaveClientViewModel> GenerateSaveClient(string clientUri = null, ClientType? clientType = null,
            string logoutUri = null)
        {
            return new Faker<SaveClientViewModel>()
                .RuleFor(s => s.ClientId, f => f.Random.Guid().ToString())
                .RuleFor(s => s.ClientName, f => f.Internet.DomainName())
                .RuleFor(s => s.ClientUri, f => clientUri ?? f.Internet.Url())
                .RuleFor(s => s.LogoUri, f => f.Internet.Avatar())
                .RuleFor(s => s.LogoutUri, f => logoutUri ?? f.Internet.Url())
                .RuleFor(s => s.Description, f => f.Lorem.Word())
                .RuleFor(s => s.ClientType, f => clientType ?? f.PickRandom<ClientType>());
        }

        public static Faker<SaveClientSecretViewModel> GenerateSaveClientSecret(string clientId = null)
        {
            return new Faker<SaveClientSecretViewModel>()
                .RuleFor(s => s.Description, f => f.Lorem.Word())
                .RuleFor(s => s.Value, f => f.Lorem.Word())
                .RuleFor(s => s.Hash, f => f.PickRandom<HashType>())
                .RuleFor(s => s.Type, f => f.Lorem.Word())
                .RuleFor(s => s.ClientId, f => clientId ?? f.Lorem.Word());
        }

        public static Faker<SaveClientPropertyViewModel> GenerateSaveProperty(string clientId = null)
        {
            return new Faker<SaveClientPropertyViewModel>()
                .RuleFor(s => s.Value, f => f.Lorem.Word())
                .RuleFor(s => s.Key, f => f.Lorem.Word())
                .RuleFor(s => s.ClientId, f => clientId ?? f.Lorem.Word());
        }

        public static Faker<SaveClientClaimViewModel> GenerateSaveClaim(string clientId = null)
        {
            return new Faker<SaveClientClaimViewModel>()
                .RuleFor(s => s.Value, f => f.Lorem.Word())
                .RuleFor(s => s.Type, f => f.Lorem.Word())
                .RuleFor(s => s.ClientId, f => clientId ?? f.Lorem.Word());
        }
    }
}