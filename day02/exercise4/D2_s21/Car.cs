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
        public Car(string type, double speed, int year) : base(type, speed, year)
        {

        }

       

        public override string Intelligence() => $"Type car = {GetTypeInfo()}, speed = {GetSpeed()}, year = {GetYear()}";

        
    }
}
