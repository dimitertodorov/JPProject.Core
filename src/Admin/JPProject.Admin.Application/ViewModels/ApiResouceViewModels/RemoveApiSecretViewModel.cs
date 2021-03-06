using System.ComponentModel.DataAnnotations;

namespace JPProject.Admin.Application.ViewModels.ApiResouceViewModels
{

    public class RemoveApiSecretViewModel
    {
        public RemoveApiSecretViewModel(string resourceName, in int id)
        {
            ResourceName = resourceName;
            Id = id;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string ResourceName { get; set; }
    }
}
