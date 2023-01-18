using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace SchoolWeb.API.Models
{
	[Index(nameof(RegistrationNumber), IsUnique = true)]
	public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [StringLength(125)]
        public string RegistrationNumber { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ManufacturedYear { get; set; }
        public string FuelType { get; set; }
        public bool IsPersonal { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsSold { get; set; }
        public DateTime? SaleDate { get; set; }

    }
}