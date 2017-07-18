using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaign.Domain.Entities
{
    public class Campaign
    {
        [Key][MaxLength]
        public string Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name for the campaign")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please enter a type for the campaign")]
        public string Type { get; set; }

        [Display(Name = "Send Date")]
        [Required(ErrorMessage = "Please enter a send date for the campaign")]
        public DateTime SendDate { get; set; }

        [Display(Name = "Visible to Public - 1 yes, 0 No")]
        [Required(ErrorMessage = "Please enter 1 for visible or 0 for not visible")]
        public string IsPublic { get; set; }

        [Display(Name = "Link Tracking")]
        [Required(ErrorMessage = "Please enter the type of links to track, or all to track all links")]
        public string LinkTracking { get; set; }

        [Display(Name = "List Ids")]
        [Required(ErrorMessage = "Please enter a comma separated list of list Ids to send this campagin to")]
        public string ListIds { get; set; }

        [Display(Name = "Message Id")]
        [Required(ErrorMessage = "Enter the id of the message you'd like to send with this campaign")]
        public string MessageId { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter a status code for the message. Options include: " + 
            "0 - Draft, 1 - Scheduled, 2 - Sending, 3 - Paused, 4 - Stopped, " + 
            "5 - Completed, 6 - Disabled, 7 - Pending Approval")]
        public string Status { get; set; }
    }
}
