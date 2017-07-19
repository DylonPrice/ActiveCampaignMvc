using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaign.Domain.Entities
{
    public class Message
    {
        [Key][MaxLength]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter a format (html, text, mime)")]
        public string Format { get; set; }

        [Required(ErrorMessage = "Please enter a subject for your email message")]
        public string Subject { get; set; }

        [Display(Name = "From Email")]
        [Required(ErrorMessage = "Please enter a from email for your message")]
        public string FromEmail { get; set; }

        [Display(Name = "From Name")]
        [Required(ErrorMessage = "Please enter a from name for your message")]
        public string FromName { get; set; }

        [Display(Name = "Reply To")]
        [Required(ErrorMessage = "Please enter a reply to email for your message")]
        public string ReplyTo { get; set; }

        [Required(ErrorMessage = "Please enter a priority number (1 - High, 3 - Medium, 5 - Low) for your message")]
        public string Priority { get; set; }

        [Display(Name = "Message Body")]
        [Required(ErrorMessage = "Please enter the body of your email. Must be either HTML or plain text")]
        public string Body { get; set; }

        [Display(Name = "List Id")]
        [Required(ErrorMessage = "Please enter a list id to assign this message to.")]
        public string ListId { get; set; }
    }
}
