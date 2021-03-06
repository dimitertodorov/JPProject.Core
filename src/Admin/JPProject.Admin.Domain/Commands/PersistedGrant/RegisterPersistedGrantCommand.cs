using JPProject.Admin.Domain.Validations.PersistedGrant;

namespace JPProject.Admin.Domain.Commands.PersistedGrant
{
    public class RegisterPersistedGrantCommand : PersistedGrantCommand
    {
        public RegisterPersistedGrantCommand()
        {
           
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterPersistedGrantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}