using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Data
{
    public class MeterData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? MeterSerial { get; set; }
        public string? MeterPublicKey { get; set; }
        
        public int SuppliesId { get; set; }
        [ForeignKey("SuppliesId")]
        public Supplies? Supplies { get; set; }
    }
}
