using IdentityServer4.EntityFramework.Entities;
using JPProject.Admin.Domain.Validations.Client;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public class SaveClientPropertyCommand : ClientPropertyCommand
    {

        public SaveClientPropertyCommand(string clientId, string key, string value)
        {
            Key = key;
            ClientId = clientId;
            Value = value;
        }
        public override bool IsValid()
        {
            ValidationResult = new SaveClientPropertyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public ClientProperty ToEntiyTy(Client savedClient)
        {
            return new ClientProperty()
            {
                Client = savedClient,
                Value = Value,
                Key = Key
            };
        }
    }
}