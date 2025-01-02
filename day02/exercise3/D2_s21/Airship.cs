using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Airship : Vehicle, IFlyable
    {
        public float MaxFlightAltitude { get; set; }
        public Airship(string type, double speed, float maxFlightAltitude) : base(type, speed)
        {
            if (maxFlightAltitude <= 0)
                throw new ArgumentException("Max flight altitude must be greater than zero.");
            this.MaxFlightAltitude = maxFlightAltitude;
        }

        public override string Intelligence()=> $"Type airship = {GetTypeInfo()}, speed = {GetSpeed()}, maxFlightAltitude = {MaxFlightAltitude}";
    }
}
