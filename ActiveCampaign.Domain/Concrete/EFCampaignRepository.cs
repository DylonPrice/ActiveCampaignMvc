using System.Collections.Generic;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using Z.EntityFramework.Plus;

namespace ActiveCampaign.Domain.Concrete
{
    public class EFCampaignRepository : ICampaignRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Campaign> Campaigns => _context.Campaigns;

        public void SaveCampaign(Campaign campaign)
        {
            Campaign dbEntry = _context.Campaigns.Find(campaign.Id);
            if (dbEntry != null)
            {
                dbEntry.Id = campaign.Id;
                dbEntry.Name = campaign.Name;
                dbEntry.Type = campaign.Type;
                dbEntry.IsPublic = campaign.IsPublic;
                dbEntry.SendDate = campaign.SendDate;
                dbEntry.Status = campaign.Status;
            }
            else
            {
                _context.Campaigns.Add(campaign);
            }
            _context.SaveChanges();
        }

        public void ClearCampaigns()
        {
            _context.Campaigns.Delete();
        }

        public void DeleteCampaign(string campaignId)
        {
            var dbEntry = _context.Campaigns.Find(campaignId);

            if (dbEntry != null)
            {
                _context.Campaigns.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}
