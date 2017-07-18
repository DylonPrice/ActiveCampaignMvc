using System.Collections.Generic;
using ActiveCampaign.Domain.Entities;

namespace ActiveCampaign.Domain.Abstract
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Contacts { get; }
        void SaveContact(Contact contact);
        void ClearContacts();
        void DeleteContact(string contactId);
    }
}
