using System.Collections.Generic;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Entities;
using Z.EntityFramework.Plus;

namespace ActiveCampaign.Domain.Concrete
{
    public class EFMessageRepository : IMessageRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Message> Messages => _context.Messages;

        public void SaveMessage(Message message)
        {
            Message dbEntry = _context.Messages.Find(message.Id);
            if (dbEntry != null)
            {
                dbEntry.Id = message.Id;
                dbEntry.Format = message.Format;
                dbEntry.Subject = message.Subject;
                dbEntry.Priority = message.Priority;
                dbEntry.ReplyTo = message.ReplyTo;
                dbEntry.FromEmail = message.FromEmail;
                dbEntry.FromName = message.FromName;
                dbEntry.Body = message.Body;
                dbEntry.ListId = message.ListId;
            }
            else
            {
                _context.Messages.Add(message);
            }
            _context.SaveChanges();
        }

        public void ClearMessages()
        {
            _context.Messages.Delete();
        }

        public void DeleteMessage(string messageId)
        {
            var dbEntry = _context.Messages.Find(messageId);

            if (dbEntry != null)
            {
                _context.Messages.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}
