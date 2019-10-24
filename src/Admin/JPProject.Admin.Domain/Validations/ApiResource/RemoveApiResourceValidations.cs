using JPProject.Admin.Domain.Commands.ApiResource;

namespace JPProject.Admin.Domain.Validations.ApiResource
{
    public class RemoveApiResourceCommandValidation : ApiResourceValidation<RemoveApiResourceCommand>
    {
        public RemoveApiResourceCommandValidation()
        {
            ValidateName();
        }
    }
}