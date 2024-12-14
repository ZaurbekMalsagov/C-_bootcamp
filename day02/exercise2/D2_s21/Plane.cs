using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Plane : Vehicle
    {
        public Plane(string type, double speed, int tankVolume, float distance) : base(type, speed, tankVolume, distance)
        {
        }

        public override float GetFuelConsumL() => (float)Math.Round(GetTankVolume() / GetDistance() * 100 * 3, 3);

        public override string Intelligence() => $"Type plane = {GetTypeInfo()}, speed = {GetSpeed()}, tankVolume = {GetTankVolume()}, fuelConsum = {GetFuelConsumL()}";
    }
}
