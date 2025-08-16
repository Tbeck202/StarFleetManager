using RestSharp;
using StarFleetManager.Library.Models;
using StarFleetManager.Library.ViewModels;

namespace StarFleetManager.Data.Services
{
    public interface ISwapiGetRequest
    {
        Task<RestResponse> GetAllAsync(string endpoint);
    }
}