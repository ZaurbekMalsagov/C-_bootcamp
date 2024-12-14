using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Plane : Vehicle, IFlyable
    {
        public float MaxFlightAltitude {  get; set; }
        public Plane(string type, double speed, float maxFlightAltitude) : base(type, speed)
        {
            if (maxFlightAltitude <= 0)
                throw new ArgumentException("Max flight altitude must be greater than zero.");
            MaxFlightAltitude = maxFlightAltitude;
        }

        
        public override string Intelligence() => $"Type plane = {GetTypeInfo()}, speed = {GetSpeed()}, maxFlightAltitude = {MaxFlightAltitude}";
    }
}
