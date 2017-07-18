using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaign.Domain.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string Format { get; set; }
        public string Subject { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ReplyTo { get; set; }
        public string Priority { get; set; }
    }
}
