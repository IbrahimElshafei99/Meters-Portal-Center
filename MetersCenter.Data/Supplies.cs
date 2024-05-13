using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Data
{
    public class Supplies
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string? UploadUsername { get; set; }
        public string? status { get; set; }
        public DateTime InspectionStartDate { get; set; }
        public DateTime InspectionEndDate { get; set; }
        public string? InspectorUsername { get; set; }

        //public string? DocumentName { get; set; }
        //public byte[]? Data { get; set; }

        [Required]
        public int MeterProviderId { get; set; }
        [ForeignKey("MeterProviderId")]
        public MeterProviders? MeterProviders { get; set; }
        public virtual List<MeterData>? MeterData { get; set; }
    }
}
