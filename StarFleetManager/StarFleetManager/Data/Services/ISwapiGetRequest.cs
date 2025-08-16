using StarFleetManager.Library.Models;

namespace StarFleetManager.Data.Services
{
    public interface ISwapiGetRequest
    {
        Task<List<StarShip>> GetAllAsync();
    }
}