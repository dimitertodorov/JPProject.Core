﻿using Bogus;
using IdentityServer4.Models;
using JPProject.Admin.Application.ViewModels.ApiResouceViewModels;
using System.Linq;

namespace JPProject.Admin.Fakers.Test.ApiResourceFakers
{
    public class ApiResourceFaker
    {
        public static Faker<ApiResource> GenerateApiResource()
        {
            return new Faker<ApiResource>()
                .RuleFor(a => a.ApiSecrets, f => GenerateSecret().Generate(f.Random.Int(0, 2)))
                .RuleFor(a => a.Enabled, f => f.Random.Bool())
                .RuleFor(a => a.Name, f => f.Internet.DomainName())
                .RuleFor(a => a.DisplayName, f => f.Lorem.Word())
                .RuleFor(a => a.Description, f => f.Lorem.Word())
                .RuleFor(a => a.UserClaims, f => f.PickRandom(IdentityHelpers.Claims, f.Random.Int(0, 3)).ToList());
        }

        public static Faker<Secret> GenerateSecret()
        {
            return new Faker<Secret>()
                .RuleFor(s => s.Description, f => f.Lorem.Word())
                .RuleFor(s => s.Value, f => f.Lorem.Word())
                .RuleFor(s => s.Type, f => f.PickRandom(IdentityHelpers.SecretTypes));
        }
        public static Faker<Scope> GenerateScope()
        {
            return new Faker<Scope>()
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.DisplayName, f => f.Lorem.Word())
                .RuleFor(s => s.Description, f => f.Lorem.Word())
                .RuleFor(s => s.Required, f => f.Random.Bool())
                .RuleFor(s => s.Emphasize, f => f.Random.Bool())
                .RuleFor(s => s.ShowInDiscoveryDocument, f => f.Random.Bool())
                .RuleFor(s => s.UserClaims, f => f.PickRandom(IdentityHelpers.Claims, f.Random.Int(0, 3)).ToList());
        }

        public static Faker<SaveApiSecretViewModel> GenerateSaveClientSecret(string name)
        {
            return new Faker<SaveApiSecretViewModel>()
                .RuleFor(s => s.Description, f => f.Lorem.Word())
                .RuleFor(s => s.Value, f => f.Lorem.Word())
                .RuleFor(s => s.Expiration, f => default)
                .RuleFor(s => s.Hash, f => default)
                .RuleFor(s => s.Type, f => f.Lorem.Word())
                .RuleFor(s => s.ResourceName, f => name ?? f.Lorem.Word());
        }

        public static Faker<SaveApiScopeViewModel> GenerateSaveScopeViewModer(string name)
        {
            return new Faker<SaveApiScopeViewModel>()
                .RuleFor(s => s.ResourceName, f => name ?? f.Lorem.Word())
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.DisplayName, f => f.Lorem.Word())
                .RuleFor(s => s.Description, f => f.Lorem.Word())
                .RuleFor(s => s.Required, f => f.Random.Bool())
                .RuleFor(s => s.Emphasize, f => f.Random.Bool())
                .RuleFor(s => s.ShowInDiscoveryDocument, f => f.Random.Bool());
        }
    }
}
