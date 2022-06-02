using System.Collections.Generic;
using System.Linq;

namespace GodelTourAgensy.Models
{
    public class PackageDetailsViewModel
    {
        public IEnumerable<(string Name, int Price)> Services = new List<(string Name, int Price)>();

        public int Discount { get; set; }

        public int RawPrice => Services.Sum(x => x.Price);

        public double Price => ((RawPrice / 100) * Discount) + RawPrice;
    }
}
