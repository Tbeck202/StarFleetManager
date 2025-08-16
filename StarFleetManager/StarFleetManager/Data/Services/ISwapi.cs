using RestSharp;

namespace StarFleetManager.Data.Services
{
    public interface ISwapi
    {
        Task<RestResponse> SendGetRequestAsync(string endpoint);
    }
}