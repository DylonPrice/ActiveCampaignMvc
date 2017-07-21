using System.Collections.Generic;
using ActiveCampaign.Domain.Entities;

namespace ActiveCampaign.Domain.Abstract
{
    public interface IMessageRepository
    {
        IEnumerable<Message> Messages { get; }
        void SaveMessage(Message message);
        void ClearMessages();
        void DeleteMessage(string messageId);
    }
}
