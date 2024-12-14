using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Car : Vehicle
    {
        public Car(string type, double speed, int tankVolume, float distance) : base(type, speed, tankVolume, distance)
        {
            
        }

        public override float GetFuelConsumL() => (float)Math.Round(GetTankVolume() / GetDistance() * 100, 3);


        public override string Intelligence() => $"Type car = {GetTypeInfo()}, speed = {GetSpeed()}, tankVolume = {GetTankVolume()}, fuelConsum = {GetFuelConsumL()}";

        
    }
}
