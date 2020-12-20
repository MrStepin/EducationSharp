using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{

    class Complex
    {

        private double ValidPart;
        private double AllegedPart;
        private double a;
        private double b;
        private double ModuleNumber;
        private double ArgumentNumber; 

        public Complex() { ValidPart = 1; AllegedPart = 1; }
        public Complex(double Valid) { ValidPart = Valid; AllegedPart = 0; }
        public Complex(double Valid, double Alleged) { ValidPart = Valid; AllegedPart = Alleged; }

        static Complex CreatingOfComplex(double CalculatedModule, double CalculateArgument)
        {
            Complex ComplexNumber = new Complex();
            double ValidPart = Math.Abs(CalculatedModule) * Math.Cos(CalculateArgument);
            double AllegedPart = Math.Abs(CalculatedModule) * Math.Sin(CalculateArgument);

            return ComplexNumber;
        }

        public double PropertyValidPart
        {
            get { return ValidPart; }
            set { ValidPart = value; }
        }

        public double PropertyAllegedPart
        {
            get { return AllegedPart; }
            set { AllegedPart = value; }
        }

        public double CalculatedModule
        {
            get { return ModuleNumber = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)); }
        }

        public double CalculateArgument
        {
            get { return ArgumentNumber = Math.Atan(b / a); }
        }

        public static Complex operator + (Complex ValidPart, Complex AllegedPart )
        {
            Complex complexNumber = new Complex();
            complexNumber.PropertyValidPart = ValidPart.PropertyValidPart + AllegedPart.PropertyValidPart;
            complexNumber.PropertyAllegedPart = ValidPart.PropertyAllegedPart + AllegedPart.PropertyAllegedPart;
            return complexNumber;
        } 

        public static Complex operator - (Complex ValidPart, Complex AllegedPart )
        {
            Complex complexNumber = new Complex();
            complexNumber.PropertyValidPart = ValidPart.PropertyValidPart - AllegedPart.PropertyValidPart;
            complexNumber.PropertyAllegedPart = ValidPart.PropertyAllegedPart - AllegedPart.PropertyAllegedPart;
            return complexNumber;
        } 

        public static Complex operator * (Complex ValidPart, Complex AllegedPart )
        {
            Complex complexNumber = new Complex();
            complexNumber.PropertyValidPart = ValidPart.PropertyValidPart * AllegedPart.PropertyValidPart - ValidPart.PropertyAllegedPart * AllegedPart.PropertyAllegedPart;
            complexNumber.PropertyAllegedPart = ValidPart.PropertyAllegedPart * AllegedPart.PropertyValidPart + ValidPart.PropertyValidPart * AllegedPart.PropertyAllegedPart;
            return complexNumber;
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {

            Complex firstComplex = new Complex(5, 8);
            Complex secondComplex = new Complex(2, -3);
            Complex sumComplex = firstComplex + secondComplex;
            Complex subtractionComplex = firstComplex - secondComplex;
            Complex multiplicationComplex = firstComplex * secondComplex;
            Console.WriteLine(sumComplex);
            Console.WriteLine(subtractionComplex);
            Console.WriteLine(multiplicationComplex);
            Console.ReadLine(); 
        }

        
    }
}
