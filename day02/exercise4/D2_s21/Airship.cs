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
        public Airship(string type, double speed, int year) : base(type, speed, year)
        {

        }

        public override string Intelligence()=> $"Type airship = {GetTypeInfo()}, speed = {GetSpeed()}, year = {GetYear()}";
    }
}
