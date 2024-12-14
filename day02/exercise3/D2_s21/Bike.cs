using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Bike : Vehicle, IDrivable
    {
        public int NumberOfWheels { get; set; }
        public Bike(string type, double speed, int numberOfWheels) : base(type, speed)
        {
            if (numberOfWheels <= 0)
                throw new ArgumentException("Number of wheels must be greater than zero.");
            NumberOfWheels = numberOfWheels;
        }

        public override string Intelligence() => $"Type bike = {GetTypeInfo()}, speed = {GetSpeed()}, numberOfWheels = {NumberOfWheels}";
    }
}
