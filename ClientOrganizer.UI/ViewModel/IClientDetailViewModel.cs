using System.Threading.Tasks;

namespace ClientOrganizer.UI.ViewModel
{
    public interface IClientDetailViewModel
    {
        Task LoadAsync(int? partyId);
        bool HasChanges { get; }
    }
}