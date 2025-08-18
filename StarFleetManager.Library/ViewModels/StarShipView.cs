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
        public bool DisplayAdditionalDetails { get; set; }

        public bool DisplayDeleteButton { get; set; }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Model", Order = 2)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Manufacturer", Order = 3)]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Class", Order = 4)]
        public string StarshipClass { get; set; }

        [Required]
        [Display(Name = "Length", Order = 5)]
        public string Length { get; set; }

        [Required]
        [Display(Name = "Max Atmosphering Speed", Order = 6)]
        public string MaxAtmospheringSpeed { get; set; }

        [Required]
        [Display(Name = "Cost (in Credits)", Order = 7)]
        public string CostInCredits { get; set; }

        [Required]
        [Display(Name = "Crew", Order = 8)]
        public string Crew { get; set; }

        [Required]
        [Display(Name = "Passengers", Order = 9)]
        public string Passengers { get; set; }


        [Required]
        [Display(Name = "Cargo Capacity", Order = 10)]
        public string CargoCapacity { get; set; }

        [Required]
        [Display(Name = "Consumables", Order = 11)]
        public string Consumables { get; set; }

        [Required]
        [Display(Name = "Hyperdrive Rating", Order = 12)]
        public string HyperdriveRating { get; set; }

        [Required]
        [Display(Name = "MGLT", Order = 13)]
        public string MGLT { get; set; }

        [Display(Name = "Films", Order = 14)]
        public List<string> Films { get; set; }

        [Display(Name = "Pilots", Order = 15)]
        public List<string> Pilots { get; set; }

        [Display(Name = "Url", Order = 16)]
        public string Url { get; set; }

        [Display(Name = "Created", Order = 17)]
        public DateTime Created { get; set; }

        [Display(Name = "Edited", Order = 18)]
        public DateTime Edited { get; set; }  
    }
}
