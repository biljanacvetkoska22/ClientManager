using System.Collections.Generic;
using System.Threading.Tasks;
using ClientOrganizer.Model;

namespace ClientOrganizer.UI.Data.Lookups
{
    public interface IClientLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetClientLookupAsync();
    }
}