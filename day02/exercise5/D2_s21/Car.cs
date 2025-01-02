using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Car : Vehicle
    {
        public Car(string type, double speed, double distance) : base(type, speed, distance)
        {

        }

       

        public override string Intelligence() => $"Type car = {GetTypeInfo()}, speed = {GetSpeed()}";
        public override string GetVehicleType() => "car";
        public override double TimeRace() => Math.Round((GetDistance() / GetSpeed() * 1.07), 3);
    }
}
