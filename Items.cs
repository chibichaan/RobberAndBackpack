using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobberAndBackpack
{
    public class Items
    {
        //св-ва
        public string Name { get; set; }

        public double Weight { get; set; }

        public double Price { get; set; }

        //конструктор
        public Items(string _name, double _weight, double _price)
        {
            Name = _name;
            Weight = _weight;
            Price = _price;
        }


    }
}
