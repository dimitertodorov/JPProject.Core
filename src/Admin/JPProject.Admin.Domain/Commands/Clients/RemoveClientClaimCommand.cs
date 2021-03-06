using JPProject.Admin.Domain.Validations.Client;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public class RemoveClientClaimCommand : ClientClaimCommand
    {

        public RemoveClientClaimCommand(int id, string clientId)
        {
            Id = id;
            ClientId = clientId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveClientClaimCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}