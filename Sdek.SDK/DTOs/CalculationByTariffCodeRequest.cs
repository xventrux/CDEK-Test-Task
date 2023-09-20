using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdek.SDK.DTOs
{
    public class CalculationByTariffCodeRequest
    {
        public int type { get; set; }

        public Location from_location { get; set; }
        public Location to_location { get; set; }

        public List<Package> packages { get; set; }
    }
}
