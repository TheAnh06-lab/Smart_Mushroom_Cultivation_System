using System;

namespace SmartMushroom_API.Models
{
    public class CultivationTray
    {
        public int TrayId { get; set; }

        public int RoomId { get; set; }

        public string TrayCode { get; set; } = string.Empty;

        public string? MushroomType { get; set; }

        public string? CultivationStage { get; set; }

        public string? Status { get; set; } = "available";

        public DateTime? ExpectedHarvestDate { get; set; }

        // Lien ket voi phong trong
        public CultivationRoom? CultivationRoom { get; set; }
    }
}