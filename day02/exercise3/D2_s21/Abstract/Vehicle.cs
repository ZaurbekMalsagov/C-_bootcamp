using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21.Abstract
{
    public abstract class Vehicle
    {
        private string Type { get; set; }
        private double Speed { get; set; }


        public Vehicle(string type, double speed)
        {
            Type = type;
            Speed = speed;

        }

        public abstract string Intelligence();


        public string GetTypeInfo() => Type;
        public double GetSpeed() => Speed;

    }
}
