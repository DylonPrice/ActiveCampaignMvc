using System.Collections.Generic;
using ActiveCampaign.Domain.Entities;

namespace ActiveCampaign.Domain.Abstract
{
    public interface IListRepository
    {
        IEnumerable<List> Lists { get; }
        void SaveList(List list);
        void ClearLists();
        void DeleteList(string listId);
    }
}
