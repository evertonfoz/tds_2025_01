namespace MonolitoBackend.Core.Entities { 
    public class User { 
        public Guid Id { get; set; } 
        public string Username { get; set; } = string.Empty; 
        public string PasswordHash { get; set; } = string.Empty; 
        public string Role { get; set; } = "User"; // Pode ser "Admin" ou "User" 
    } 
}