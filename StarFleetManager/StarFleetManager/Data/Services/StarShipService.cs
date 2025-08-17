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
        private List<StarShip> _starShips = new();

        public List<StarShip> StarShips 
        { 
            get => _starShips; 
            private set => _starShips = value; 
        }

        public StarShipService(IDbContextFactory<ApplicationDbContext> contextFactory, ISwapiGetRequest swapiGetRequest)
        {
            _contextFactory = contextFactory; 
            _swapiGetRequest = swapiGetRequest;
        }

        public async Task<List<StarShipView>> GetAllAsync()
        {
            if(StarShips.Count == 0)
            {
                StarShips = await DbGetAllAsync();
            }
            return StarShips.Adapt<List<StarShipView>>();
        }

        public async Task<bool> SeedDataBaseAsync()
        {
            List<StarShip> ships = await ApiGetAllAsync();
            int entitiesSaved = 0;
            if (ships != null && ships.Count > 0)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    await context.StarShips.AddRangeAsync(ships);
                    entitiesSaved = await context.SaveChangesAsync();
                }

                StarShips = ships;
            }
            //NEED TO RUN UPDATE DATABASE
            return entitiesSaved > 0;
        }

        public async Task<List<StarShip>> ApiGetAllAsync()
        {
            List<StarShip> starships = new List<StarShip>();
            var result = await _swapiGetRequest.GetAllAsync("starships");

            if (result.IsSuccessful && result.Content.Length > 0) 
            {
                starships = JsonConvert.DeserializeObject<List<StarShip>>(result.Content);
                return starships.Adapt<List<StarShip>>();
            }

            return new List<StarShip>();
        }

        private async Task<List<StarShip>> DbGetAllAsync()
        {
            List<StarShip> ships = new List<StarShip>();

            using (var context = _contextFactory.CreateDbContext())
            {
                ships = await context.StarShips.ToListAsync();
            }

            return ships.Adapt<List<StarShip>>();
        }

        //public async Task<List<StarShipView>> DbGetAllAsync()
        //{
        //    List<StarShip> ships = new List<StarShip>();

        //    using(var context = _contextFactory.CreateDbContext())
        //    {
        //        ships = await context.StarShips.ToListAsync();
        //    }

        //    return ships.Adapt<List<StarShipView>>();
        //}

        public async Task<bool> DbAddStarShipAsync(StarShipView starShip)
        {
            int entitiesSaved = 0;
            using (var context = _contextFactory.CreateDbContext())
            {
                StarShip newStarShip = starShip.Adapt<StarShip>();
                try
                {
                    await context.StarShips.AddAsync(newStarShip);
                    entitiesSaved = await context.SaveChangesAsync();
                }
                catch (Exception ex) { }
                
            }

            return entitiesSaved > 0;
        }
    }
}
