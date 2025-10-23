using Mapster;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;
using System.Runtime.CompilerServices;

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

        public async Task<List<StarShipView>> GetAllAsync()
        {
            List<StarShip> ships = await DbGetAllAsync();
            return ships.Adapt<List<StarShipView>>();
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
            }
            
            return entitiesSaved > 0;
        }

        public async Task<int> RefillDataBaseAsync()
        {
            List<StarShip> shipsFromSwapi = await ApiGetAllAsync();
            List<StarShip> shipsToAdd = new();
            int itemsToAdd = 0;

            try
            {
                List<StarShip> ships = await DbGetAllAsync();
                foreach (StarShip sh in shipsFromSwapi)
                {
                    bool exists = ships.Any(s => s.Url.Equals(sh.Url, StringComparison.OrdinalIgnoreCase));
                    if (!exists)
                    {
                        shipsToAdd.Add(sh);
                        itemsToAdd++;
                    }
                }
            }
            catch (Exception ex) { }

            int itemsSaved = 0;
            if (itemsToAdd > 0) 
            {
                itemsSaved = await DbAddStarShipsAsync(shipsToAdd);
            }
            
            return itemsSaved;
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

            return ships;
        }

        // Consider building response model that would hold the startship(s) and a response message in case no ship exists
        private async Task<StarShip> DbGetShipByIdAsync(int id)
        {
            StarShip? starShip;
            using (var context = _contextFactory.CreateDbContext())
            {
                starShip = await context.StarShips.Where(ship => ship.Id == id).FirstAsync();
            }
            return starShip;
        }

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

        private async Task<int> DbAddStarShipsAsync(List<StarShip> ships)
        {
            int entitiesSaved = 0;
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    await context.StarShips.AddRangeAsync(ships);
                    entitiesSaved = await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) { }
            
            return entitiesSaved;
        }

        public async Task<bool> DbUpdateStarShipAsync(StarShipView starShip)
        {
            int entitiesSaved = 0;
            using(var context = _contextFactory.CreateDbContext())
            {
                
                try
                {
                    StarShip updateStarShip = await DbGetShipByIdAsync(starShip.Id); 
                    context.StarShips.Update(updateStarShip);
                    entitiesSaved = await context.SaveChangesAsync();
                }
                catch(Exception ex) { } 
                return entitiesSaved > 0;
            }
        }

        public async Task<bool> DbDeleteStarShipAsync(StarShipView starShip)
        {
            int entitiesRemoved = 0;
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    context.StarShips.Remove(starShip.Adapt<StarShip>());
                    entitiesRemoved = await context.SaveChangesAsync();
                }
                catch(Exception ex) { }
            }
            return entitiesRemoved > 0;
        }

        public List<string> ApiGetFilmUrls()
        {
            return _swapiGetRequest.GetFilmUrls();
        }
    }
}
