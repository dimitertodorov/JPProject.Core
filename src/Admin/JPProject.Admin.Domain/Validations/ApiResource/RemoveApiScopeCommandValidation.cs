using JPProject.Admin.Domain.Commands.ApiResource;

namespace JPProject.Admin.Domain.Validations.ApiResource
{
    public class RemoveApiScopeCommandValidation : ApiScopeValidation<RemoveApiScopeCommand>
    {
        public RemoveApiScopeCommandValidation()
        {
            ValidateResourceName();
            ValidateId();
        }
    }
}