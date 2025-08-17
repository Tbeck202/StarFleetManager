using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using StarFleetManager.Library.Models;
using RestSharp;

namespace StarFleetManager.Data.Services
{
    public class Swapi : ISwapi
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl = string.Empty;
        private readonly List<string> _filmUrls = new List<string>();
        private readonly List<string> _peopleUrls = new List<string>();

        public Swapi(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["SwapiApiBase"] ?? string.Empty;
        }

        public async Task<RestResponse> SendGetRequestAsync(string endpoint)
        {
            var options = new RestClientOptions(_baseUrl);
            var client = new RestClient(options);
            var request = new RestRequest($"api/{endpoint}");
            request.AddHeader("accept", "application/json");

            try
            {
                RestResponse response = await client.GetAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse();
            }
        }

        public List<string> GetFilmUrls()
        {
            return _filmUrls;
        }
    }
}
