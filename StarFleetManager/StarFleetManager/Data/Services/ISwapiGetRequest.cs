using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public interface ISwapiGetRequest
    {
        Task<List<StarShipView>> GetAllAsync();
    }
}