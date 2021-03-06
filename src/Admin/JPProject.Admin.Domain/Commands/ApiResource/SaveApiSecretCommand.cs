using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Admin.Domain.Commands.Clients;
using JPProject.Admin.Domain.Validations.ApiResource;
using System;
using FluentValidation.Results;

namespace JPProject.Admin.Domain.Commands.ApiResource
{
    public class SaveApiSecretCommand : ApiSecretCommand
    {

        public SaveApiSecretCommand(string resourceName, string description, string value, string type, DateTime? expiration,
            int hashType)
        {
            ResourceName = resourceName;
            Description = description;
            Value = value;
            Type = type;
            Expiration = expiration;
            Hash = hashType;
        }
        public override bool IsValid()
        {
            ValidationResult = new SaveApiSecretCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public string GetValue()
        {
            switch (Hash)
            {
                case 0:
                    return Value.ToSha256();
                case 1:
                    return Value.ToSha512();
                default:
                    throw new ArgumentException(nameof(Hash));
            }
        }

        public ApiSecret ToEntity(IdentityServer4.EntityFramework.Entities.ApiResource savedApi)
        {
            return new ApiSecret
            {
                ApiResourceId = savedApi.Id,
                Description = Description,
                Expiration = Expiration,
                Type = Type,
                Value = GetValue()
            };
        }
    }
}