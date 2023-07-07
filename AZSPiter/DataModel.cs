using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSPiter
{
    internal class DataModel
    {
        public int? Id { get; set; }

        public int StationId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int AmountOfFuel { get; set; }
    }
}
