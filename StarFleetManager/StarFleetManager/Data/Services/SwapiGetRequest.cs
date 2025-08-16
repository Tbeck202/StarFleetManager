using Azure;
using Newtonsoft.Json;
using RestSharp;
using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public class SwapiGetRequest : ISwapiGetRequest
    {
        private ISwapi Swapi { get; set; }
        public SwapiGetRequest(ISwapi swapi)
        {
            Swapi = swapi;
        }

        public async Task<RestResponse> GetAllAsync(string endpoint)
        {
            RestResponse response = new RestResponse();
            try
            {
                response = await Swapi.SendGetRequestAsync(endpoint);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
    }
}
