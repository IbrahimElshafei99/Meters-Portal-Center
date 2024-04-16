namespace PortalUploadingMeterData.Models
{
    public class MasterRecord
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string? UploadUsername { get; set; }
        public virtual List<MeterData>? MeterData { get; set; }
    }
}
