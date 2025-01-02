using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21_ex01
{
    public abstract class Vehicle
    {
        private string Type { get; set; }
        private double Speed { get; set; }

        public Vehicle(string type, double speed) { 
            this.Type = type;
            this.Speed = speed;
        }

        public abstract string Intelligence();
        public string GetTypeInfo() => Type;
        public double GetSpeed() => Speed;
    }
}
