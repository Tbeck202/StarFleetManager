using Mapster;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public class StarShipService : IStarShipService
    {
        private readonly ISwapiGetRequest _swapiGetRequest;
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public StarShipService(IDbContextFactory<ApplicationDbContext> contextFactory, ISwapiGetRequest swapiGetRequest)
        {
            _contextFactory = contextFactory; 
            _swapiGetRequest = swapiGetRequest;
        }

        public async Task<bool> SeedDataBaseAsync()
        {
            List<StarShip> ships = await GetAllAsync();
            if (ships != null && ships.Count > 0)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    //await context.StarShips
                }
            }

            return false;
        }

        public async Task<List<StarShip>> GetAllAsync()
        {
            List<StarShip> starships = new List<StarShip>();
            var result = await _swapiGetRequest.GetAllAsync("starships");
            starships = JsonConvert.DeserializeObject<List<StarShip>>(result.Content);
            return starships.Adapt<List<StarShip>>();
        }
    }
}
