using FluentValidation.Results;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using JPProject.Admin.Domain.Validations.ApiResource;

namespace JPProject.Admin.Domain.Commands.ApiResource
{
    public class RegisterApiResourceCommand : ApiResourceCommand
    {

        public RegisterApiResourceCommand(IdentityServer4.Models.ApiResource apiResource)
        {
            Resource = apiResource;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterApiResourceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public IdentityServer4.EntityFramework.Entities.ApiResource ToEntity()
        {
            Resource.Scopes.Add(new Scope(Resource.Name, Resource.DisplayName));
            return Resource.ToEntity();
        }
    }
}