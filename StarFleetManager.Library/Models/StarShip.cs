using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFleetManager.Library.Models
{
    public class StarShip : IStarShip
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; } = string.Empty;

        [JsonProperty("length")]
        public string Length { get; set; } = string.Empty;

        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; } = string.Empty;

        [JsonProperty("crew")]
        public string Crew { get; set; } = string.Empty;

        [JsonProperty("passengers")]
        public string Passengers { get; set; } = string.Empty;

        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; } = string.Empty;

        [JsonProperty("consumables")]
        public string Consumables { get; set; } = string.Empty;

        [JsonProperty("hyperdrive_rating")]
        public string HyperdriveRating { get; set; } = string.Empty;

        [JsonProperty("MGLT")]
        public string MGLT { get; set; } = string.Empty;

        [JsonProperty("starship_class")]
        public string StarshipClass { get; set; } = string.Empty;

        [JsonProperty("pilots")]
        public List<string> Pilots { get; set; } = new();

        [JsonProperty("films")]
        public List<string> Films { get; set; } = new();

        [JsonProperty("created")]
        public DateTime Created { get; set; } 

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
