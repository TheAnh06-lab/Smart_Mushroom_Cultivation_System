using System;

namespace SmartMushroom_API.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        public int UserId { get; set; }

        public int TrayId { get; set; }

        public int PackageId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Status { get; set; } = "pending";

        public DateTime? CreatedAt { get; set; }

        // Các khóa ngoại
        public User? User { get; set; }

        public CultivationTray? CultivationTray { get; set; }

        public RentalPackage? RentalPackage { get; set; }
    }
}