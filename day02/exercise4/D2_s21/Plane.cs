using D2_s21.Abstract;
using D2_s21.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21
{
    internal class Plane : Vehicle
    {
        public Plane(string type, double speed, int year) : base(type, speed, year)
        {


        }

        
        public override string Intelligence() => $"Type plane = {GetTypeInfo()}, speed = {GetSpeed()}, year = {GetYear()}";
    }
}
