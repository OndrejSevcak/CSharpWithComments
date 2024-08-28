using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes.ReferenceTypes
{
    public class Car
    {
        public string MakerBrand { get; set; }
        public int ModelYear { get; set; }

        public Car(string maker, int year)
        {
            MakerBrand = maker;
            ModelYear = year;
        }

        public override string ToString()
        {
            return $"{MakerBrand} model year {ModelYear}";
        }
    }
}
