using Newtonsoft.Json;
using StarFleetManager.Library.Models;

namespace StarFleetManager.Data.Services
{
    public class StarshipRequest : ISwapiGetRequest
    {
        private ISwapi Swapi { get; set; }
        public StarshipRequest(ISwapi swapi)
        {
            Swapi = swapi;
        }

        public async Task<List<StarShip>> GetAllAsync()
        {
            List<StarShip> starShips = new List<StarShip>();

            try
            {
                var response = await Swapi.SendGetRequestAsync("starships");
                if (response != null && response.Content != null)
                {
                    starShips = JsonConvert.DeserializeObject<List<StarShip>>(response.Content);
                }

            }
            catch (Exception ex)
            {

            }
            return starShips;
        }
    }
}
