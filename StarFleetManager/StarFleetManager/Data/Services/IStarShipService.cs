using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public interface IStarShipService
    {
        List<StarShipView> GetAll();

        Task<bool> SeedDataBaseAsync();

        Task<List<StarShip>> ApiGetAllAsync();

        Task<List<StarShipView>> DbGetAllAsync();
    }
}