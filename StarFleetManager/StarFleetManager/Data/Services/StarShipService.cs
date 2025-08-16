using Newtonsoft.Json;
using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public class StarShipService : IStarShipService
    {
        private readonly ISwapiGetRequest _swapiGetRequest;
        public StarShipService(ISwapiGetRequest swapiGetRequest)
        {
            _swapiGetRequest = swapiGetRequest;
        }

        public async Task<List<StarShipView>> GetAllAsync()
        {
            List<StarShipView> starships = new List<StarShipView>();
            var result = await _swapiGetRequest.GetAllAsync("starships");
            starships = JsonConvert.DeserializeObject<List<StarShipView>>(result.Content);
            return starships;
        }
    }
}
