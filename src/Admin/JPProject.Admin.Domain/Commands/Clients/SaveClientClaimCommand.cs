using IdentityServer4.EntityFramework.Entities;
using JPProject.Admin.Domain.Validations.Client;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public class SaveClientClaimCommand : ClientClaimCommand
    {

        public SaveClientClaimCommand(string clientId, string type, string value)
        {
            Type = type;
            ClientId = clientId;
            Value = value;
        }
        public override bool IsValid()
        {
            ValidationResult = new SaveClientClaimCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public ClientClaim ToEntity(Client savedClient)
        {
            return new ClientClaim()
            {
                ClientId = savedClient.Id,
                Value = Value,
                Type = Type
            };
        }
    }
}