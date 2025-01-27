namespace RepairShopManagementAPIApp.Data
{
    public class ServiceEntry
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public DateTime DateTimeOfEntry { get; set; } = DateTime.Now;
        public string? Problem { get; set; }
        public string? Damages { get; set; }
        public double? EstimatedPrice { get; set; }
        public string? PartsUsed { get; set; }
        public DateTime? DateOfServiceStart { get; set; }
        public DateTime? DateOfServiceEnd { get; set; }
        public double? FinalPrice { get; set; }
        public double? Deposit { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public string? Notes { get; set; }

        //TODO:
        //public int CreatorUserId { get; set; } //get the user that created the entry
        //public int? FixUserId { get; set; } //user that fixed the device
        //public int? ReturningUserId { get; set; } //user that returned the device to the customer

        public bool IsFinished { get; set; } = false;
        public bool IsReturned { get; set; } = false;
        public virtual Device? Device { get; set; }
        //public virtual User? User { get; set; }

    }
}
