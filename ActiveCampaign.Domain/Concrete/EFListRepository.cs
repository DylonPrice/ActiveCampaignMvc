using System.Collections.Generic;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using Z.EntityFramework.Plus;

namespace ActiveCampaign.Domain.Concrete
{
    public class EFListRepository : IListRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<List> Lists => _context.Lists;

        public void SaveList(List list)
        {
            List dbEntry = _context.Lists.Find(list.Id);
            if (dbEntry != null)
            {
                dbEntry.Id = list.Id;
                dbEntry.Name = list.Name;
                dbEntry.ToName = list.ToName;
                dbEntry.SubscriptionNotify = list.SubscriptionNotify;
                dbEntry.UnsubscriptionNotify = list.UnsubscriptionNotify;
                dbEntry.CarbonCopy = list.CarbonCopy;
            }
            else
            {
                _context.Lists.Add(list);
            }
            _context.SaveChanges();
        }

        public void ClearLists()
        {
            _context.Lists.Delete();
        }

        public void DeleteList(string listId)
        {
            var dbEntry = _context.Lists.Find(listId);
            if (dbEntry != null)
            {
                _context.Lists.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}
