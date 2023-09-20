using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdek.SDK.DTOs
{
    public class Tariff
    {
        public int tariff_code { get; set; }

        public string tariff_name { get; set; }

        public float delivery_sum { get; set; }
    }
}
