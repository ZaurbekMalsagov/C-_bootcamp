using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21_ex01
{
    internal class Plane : Vehicle
    {
        public Plane(string type, double speed) : base(type, speed)
        {
        }

        public override string Intelligence() => $"Type plane = {GetTypeInfo()}, speed = {GetSpeed()}";
    }
}
