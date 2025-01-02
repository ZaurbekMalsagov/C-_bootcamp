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
        private double Distance { get; set; }


        public Vehicle(string type, double speed, double distance)
        {
            Type = type;
            Speed = speed;
            Distance = distance;
        }

        public abstract string Intelligence();
        public abstract double TimeRace(); 
        public string GetTypeInfo() => Type;
        public double GetSpeed() => Speed;
        public double GetDistance() => Distance;
        public abstract string GetVehicleType();

    }
}
