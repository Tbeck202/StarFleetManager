
namespace StarFleetManager.Library.Models
{
    public interface IStarShip
    {
        string CargoCapacity { get; set; }
        string Consumables { get; set; }
        string CostInCredits { get; set; }
        DateTime Created { get; set; }
        string Crew { get; set; }
        DateTime Edited { get; set; }
        List<string> Films { get; set; }
        string HyperdriveRating { get; set; }
        string Length { get; set; }
        string Manufacturer { get; set; }
        string MaxAtmospheringSpeed { get; set; }
        string MGLT { get; set; }
        string Model { get; set; }
        string Name { get; set; }
        string Passengers { get; set; }
        List<string> Pilots { get; set; }
        string StarshipClass { get; set; }
        string Url { get; set; }
    }
}