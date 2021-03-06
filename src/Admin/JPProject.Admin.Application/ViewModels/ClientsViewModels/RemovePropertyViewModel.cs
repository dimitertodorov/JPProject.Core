using System.ComponentModel.DataAnnotations;

namespace JPProject.Admin.Application.ViewModels.ClientsViewModels
{
    public class RemovePropertyViewModel
    {
        public RemovePropertyViewModel(int id, string clientId)
        {
            Id = id;
            ClientId = clientId;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}