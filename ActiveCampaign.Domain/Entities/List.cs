using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActiveCampaign.Domain.Entities
{
    [Table("Lists")]
    public class List
    {
        [Key][MaxLength]
        public string Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a List name")]
        public string Name { get; set; }

        [Display(Name = "To Name")]
        [Required(ErrorMessage = "Please enter a To Name for the list")]
        public string ToName { get; set; }

        [Display(Name = "Subscription Notify Email")]
        [Required(ErrorMessage = "Please enter a comma separated list email addresses that will be notified when someone subscribes")]
        public string SubscriptionNotify { get; set; }

        [Display(Name = "Unsubscription Notify Email")]
        [Required(ErrorMessage = "Please enter a comma separated list email addresses that will be notified when someone unsubscribes")]
        public string UnsubscriptionNotify { get; set; }

        [Display(Name = "Carbon Copy Email")]
        [Required(ErrorMessage = "Please enter a comma separated list of email addresses to send a copy of mailings to")]
        public string CarbonCopy { get; set; }
    }
}
