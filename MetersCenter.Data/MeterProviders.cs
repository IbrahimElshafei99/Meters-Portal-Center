using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Data
{
    public class MeterProviders
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<Supplies>? Supplies { get; set; }
    }
}
