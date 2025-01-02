using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    public abstract class Vehicle
    {
        private string Type { get; set; }
        private double Speed { get; set; }
        private int TankVolume { get; set; }
        public float Distance { get; set; }

        public Vehicle(string type, double speed, int tankVolume, float distance = 0) { 
            this.Type = type;
            this.Speed = speed;
            this.TankVolume = tankVolume;
            this.Distance = distance;
        }

        public abstract string Intelligence();
        public abstract float GetFuelConsumL();
        public string GetTypeInfo() => Type;
        public double GetSpeed() => Speed;
        public int GetTankVolume() => TankVolume;
        public float GetDistance() => Distance;
    }
}
