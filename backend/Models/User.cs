using System;

namespace SmartMushroom_API.Models
{
    public class User
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public DateTime? CreatedAt { get; set; }

        // Lien ket voi Role
        public Role? Role { get; set; }
    }
}