using ClientOrganizer.DataAccess;
using ClientOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.Data.Lookups
{
    public class LookupDataService : IClientLookupDataService
    {
        private Func<ClientOrganizerDbContext> _contextCreator;

        public LookupDataService(Func<ClientOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetClientLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Clients.AsNoTracking()
                    .Select(c =>
                    new LookupItem
                    {
                        Id = c.PartyId,
                        DisplayMember = c.FullName
                    })
                    .ToListAsync();
            }
        }
    }
}
