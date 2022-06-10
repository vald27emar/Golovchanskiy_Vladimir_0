using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

// z=a1+b1i

namespace LabOP1
{

    class ComplexNumber
    {
        private double a;
        private double b;

        public ComplexNumber(double a, double b) // конструктор
        {
            this.a = a;
            this.b = b;
        }

        public double A { get { return a; } set { a = value; } }
        public double B { get { return b; } set { b = value; } }

        public void ComplexSum(ComplexNumber number2)
        {
            double x = this.a + number2.a;
            double y = this.b + number2.b;


            Console.WriteLine("Сумма двух комплексных чисел:");
            Console.WriteLine($"z={x} + ({y})i");
        }
        public void ComplexDifference(ComplexNumber number2)
        {
            double x = this.a - number2.a;
            double y = this.b - number2.b;


            Console.WriteLine("Разница двух комплексных чисел:");
            Console.WriteLine($"z={x} + ({y})i");
        }
        public void ComplexMultiplication(ComplexNumber number2)
        {
            double x = this.a * number2.a;
            double y = this.a * number2.b;
            double z = this.b * number2.a;
            double f = this.b * number2.b;
            double k = x + (f * -1);
            double l = y + z;

            Console.WriteLine("Произвдение двух комплексных чисел:");
            Console.WriteLine($"z={k} + ({l})i");
        }
        public void First(string filename)
        {
            string toWrite = JsonConvert.SerializeObject(this);
            File.WriteAllText(filename, toWrite);
        }
        public static ComplexNumber Second(string filename)
        {
            StreamReader r = new StreamReader(filename);
            string jsonString = r.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            double a = json.A;
            double b = json.B;

            return new ComplexNumber(a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*ComplexNumber number1 = new ComplexNumber(3, 5);*/
            ComplexNumber number2 = new ComplexNumber(1, -2);

            ComplexNumber number = ComplexNumber.Second("C:\\Users\\golov\\Desktop\\LABOP1\\Laba.json");
            
            number2.First("C:\\Users\\golov\\Desktop\\LABOP1\\Labanumber2.json");

            // Console.WriteLine("Действительная часть первого комплексного числа");
            Console.WriteLine($"Действительная часть: {number.A} , мнимая часть: {number.B } первого комплексного числа.");
            Console.WriteLine($"Действительная часть: 1 , мнимая часть: -2 второго комплексного числа.");

            number.ComplexSum(number2);
            number.ComplexDifference(number2);
            number.ComplexMultiplication(number2);
        }
    }
}