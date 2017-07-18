using System.Collections.Generic;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using Z.EntityFramework.Plus;

namespace ActiveCampaign.Domain.Concrete
{
    public class EFContactRepository : IContactRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Contact> Contacts => _context.Contacts;

        public void SaveContact(Contact contact)
        {
            Contact dbEntry = _context.Contacts.Find(contact.Id);
            if (dbEntry != null)
            {
                dbEntry.Id = contact.Id;
                dbEntry.Email = contact.Email;
                dbEntry.FirstName = contact.FirstName;
                dbEntry.LastName = contact.LastName;
                dbEntry.ListId = contact.ListId;
            }
            else
            {
                _context.Contacts.Add(contact);
            }
            _context.SaveChanges();
        }

        public void ClearContacts()
        {
            _context.Contacts.Delete();
        }

        public void DeleteContact(string contactId)
        {
            var dbEntry = _context.Contacts.Find(contactId);
            if (dbEntry != null)
            {
                _context.Contacts.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}
