namespace RepairShopManagementAPIApp.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PrimaryPhone { get; set; }
        public string? Secondary { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }


        //public int TechnicianId { get; set; } //todo created by technicianid 
        public virtual ICollection<Device> Devices { get; } = new HashSet<Device>();

    }
}
