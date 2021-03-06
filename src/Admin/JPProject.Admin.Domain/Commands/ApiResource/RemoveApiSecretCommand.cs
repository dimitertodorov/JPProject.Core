using JPProject.Admin.Domain.Commands.Clients;
using JPProject.Admin.Domain.Validations.ApiResource;

namespace JPProject.Admin.Domain.Commands.ApiResource
{
    public class RemoveApiSecretCommand : ApiSecretCommand
    {
        public RemoveApiSecretCommand(int id, string resourceName)
        {
            ResourceName = resourceName;
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveApiSecretCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}