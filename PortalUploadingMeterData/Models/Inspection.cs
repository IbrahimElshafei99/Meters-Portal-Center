using System.ComponentModel.DataAnnotations.Schema;

namespace PortalUploadingMeterData.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MeterId { get; set; }
        public virtual MeterData? MeterData { get; set; }
    }
}
