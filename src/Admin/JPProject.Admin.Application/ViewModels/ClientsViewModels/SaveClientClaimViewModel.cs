using System.ComponentModel.DataAnnotations;

namespace JPProject.Admin.Application.ViewModels.ClientsViewModels
{
    public class SaveClientClaimViewModel
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}