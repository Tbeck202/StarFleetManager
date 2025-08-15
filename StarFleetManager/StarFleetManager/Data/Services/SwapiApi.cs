using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using StarFleetManager.Library.Models;

namespace StarFleetManager.Data.Services
{
    public class SwapiApi
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl = string.Empty;

        public SwapiApi(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("SwapiApi").ToString() ?? string.Empty;
        }

        public async Task SendRequestAsync()
        {

        }
        //public async Task<List<object>> GetAllAsync()
        //{

        //}
    }
}
