using RepairShopManagementAPIApp.Models;

namespace RepairShopManagementAPIApp.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        
        public override string ToString()
        {
            return $"{Firstname} {Lastname} {Email}";
        }
    }
}
