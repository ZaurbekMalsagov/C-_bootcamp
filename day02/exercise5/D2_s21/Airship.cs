using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Airship : Vehicle
    {
        public Airship(string type, double speed, double distance) : base(type, speed, distance)
        {

        }

        public override string Intelligence()=> $"Type airship = {GetTypeInfo()}, speed = {GetSpeed()}, year = {GetDistance()}";
        public override string GetVehicleType() => "airship";
        public override double TimeRace()
        {
            throw new NotImplementedException();
        }
    }
}
