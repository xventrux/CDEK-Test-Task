using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdek.SDK.DTOs
{
    public class Package
    {
        /// <summary>
        /// Вес в граммах
        /// </summary>
        public float weight { get; set; }

        /// <summary>
        /// Ширина в милиметрах
        /// </summary>
        public float width { get; set; }

        /// <summary>
        /// Высота в милиметрах
        /// </summary>
        public float height { get; set; }

        /// <summary>
        /// Длина в милиметрах
        /// </summary>
        public float length { get; set; }
    }
}
