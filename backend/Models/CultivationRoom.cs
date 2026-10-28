namespace SmartMushroom_API.Models
{
    public class CultivationRoom
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Status { get; set; } = "active";
    }
}