using ActiveCampaign.Domain.Entities;
using System.Data.Entity;

namespace ActiveCampaign.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
