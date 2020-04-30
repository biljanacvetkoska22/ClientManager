using ClientOrganizer.DataAccess;
using ClientOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ClientOrganizerDbContext _context;

        public ClientRepository(ClientOrganizerDbContext context)
        {
            _context = context;
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        // retrieve from db
        public async Task<Client> GetByIdAsync(int partyId)
        {
            return await _context.Clients.SingleAsync(c => c.PartyId == partyId);
        }

        // retrieve all from db
        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(Client model)
        {
            _context.Clients.Remove(model);           
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
