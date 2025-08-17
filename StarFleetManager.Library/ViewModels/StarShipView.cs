using StarFleetManager.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFleetManager.Library.ViewModels
{
    public class StarShipView : IStarShip
    {
        [Required]
        public string CargoCapacity { get; set; }

        [Required]
        public string Consumables { get; set; }

        [Required]
        public string CostInCredits { get; set; }

        
        public DateTime Created { get; set; }

        [Required]
        public string Crew { get; set; }
        
        public DateTime Edited { get; set; }
        
        public List<string> Films { get; set; }

        [Required]
        public string HyperdriveRating { get; set; }

        [Required]
        public string Length { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string MaxAtmospheringSpeed { get; set; }

        [Required]
        public string MGLT { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Passengers { get; set; }
        
        public List<string> Pilots { get; set; }

        [Required]
        public string StarshipClass { get; set; }
        public string Url { get; set; }
    }
}
