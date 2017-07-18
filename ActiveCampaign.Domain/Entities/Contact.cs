using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActiveCampaign.Domain.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key][MaxLength]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter the contact's first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter the contact's last name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter the contact's email address")]
        public string Email { get; set; }

        [Display(Name = "List Id")]
        [Required(ErrorMessage = "Please enter the id of a list to subscribe the contact to.")]
        public string ListId { get; set; }
    }
}
