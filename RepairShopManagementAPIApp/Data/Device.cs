using RepairShopManagementAPIApp.Models;

namespace RepairShopManagementAPIApp.Data
{
    public class Device
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string? Maker { get; set; }
        public string? Model { get; set; }
        public DeviceType DeviceType { get; set; }
        public DateOnly? DateOfPurchase { get; set; }

        public virtual ICollection<ServiceEntry> DeviceEntries { get; } = new HashSet<ServiceEntry>();
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }

    }
}
