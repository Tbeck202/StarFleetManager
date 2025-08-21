using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public interface IStarShipService
    {
        Task<List<StarShipView>> GetAllAsync();

        Task<bool> SeedDataBaseAsync();

        Task<bool> RefillDataBaseAsync();

        Task<List<StarShip>> ApiGetAllAsync();

        Task<bool> DbAddStarShipAsync(StarShipView starShip);

        Task<bool> DbUpdateStarShipAsync(StarShipView starShip);

        Task<bool> DbDeleteStarShipAsync(StarShipView starShip);

        List<string> ApiGetFilmUrls();
    }
}