namespace PortalUploadingMeterData.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<MeterData>? MeterData { get; set; }
    }
}
