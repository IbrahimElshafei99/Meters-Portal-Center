using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalUploadingMeterData.Models
{
    public class MeterData
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string? MeterSerial { get; set; }
        public string? MeterPublicKey { get; set; }
        public string? status { get; set; }

        public virtual Inspection? MeterInspection { get; set; }


        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        
        public int MasterRecordId { get; set; }
        [ForeignKey("MasterRecordId")]
        public MasterRecord? MasterRecord { get; set; }
    }
}
