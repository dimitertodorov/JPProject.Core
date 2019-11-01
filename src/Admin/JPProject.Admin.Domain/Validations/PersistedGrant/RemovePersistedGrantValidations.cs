using JPProject.Admin.Domain.Commands.PersistedGrant;

namespace JPProject.Admin.Domain.Validations.PersistedGrant
{
    public class RemovePersistedGrantCommandValidation : PersistedGrantValidation<RemovePersistedGrantCommand>
    {
        public RemovePersistedGrantCommandValidation()
        {
            this.ValidateKey();
        }
    }
}