using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveCampaign.Domain.Entities;

namespace ActiveCampaign.Domain.Abstract
{
    public interface ICampaignRepository
    {
        IEnumerable<Campaign> Campaigns { get; }
        void SaveCampaign(Campaign campaign);
        void ClearCampaigns();
        void DeleteCampaign(string campaignId);
    }
}
