using System.Collections.Generic;
using System.Threading.Tasks;
using ClientOrganizer.Model;

namespace ClientOrganizer.UI.Data.Repositories
{
    public interface IClientRepository
    {         
        Task<Client> GetByIdAsync(int partyId);
        Task SaveAsync();
        bool HasChanges();
        void Add(Client client);
        void Remove(Client model);
    }
}