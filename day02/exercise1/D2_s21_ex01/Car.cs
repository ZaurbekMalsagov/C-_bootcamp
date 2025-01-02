using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_s21_ex01
{
    internal class Car : Vehicle
    {
        public Car(string type, double speed) : base(type, speed)
        {
        }

        public override string Intelligence()=> $"Type car = {GetTypeInfo()}, speed = {GetSpeed()}";
        
    }
}
