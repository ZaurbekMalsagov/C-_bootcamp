using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Bike : Vehicle
    {
        public Bike(string type, double speed, double distance) : base(type, speed, distance)
        {

        }

        public override string Intelligence() => $"Type bike = {GetTypeInfo()}, speed = {GetSpeed()}";
        public override string GetVehicleType() => "bike";
        public override double TimeRace() => Math.Round(GetDistance() / GetSpeed(), 3);
    }
}
