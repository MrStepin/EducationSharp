using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{

    class Complex
    {

        private double RealPart;
        private double ImaginaryPart;
        private double a;
        private double b;
        private double ModuleNumber;
        private double ArgumentNumber; 

        public Complex() { RealPart = 1; ImaginaryPart = 1; }
        public Complex(double a) { RealPart = a; ImaginaryPart = 0; }
        public Complex(double a, double b) { RealPart = a; ImaginaryPart = b; }

        static Complex CreatingOfComplex(double CalculatedModule, double CalculateArgument)
        {
            Complex ComplexNumber = new Complex();
            double RealPart = Math.Abs(CalculatedModule) * Math.Cos(CalculateArgument);
            double ImaginaryPart = Math.Abs(CalculatedModule) * Math.Sin(CalculateArgument);

            return ComplexNumber;
        }

        public double Real { get; set; }
        public double Imaginary { get; set; }
        

        public double CalculatedModule
        {
            get { return ModuleNumber = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)); }
        }

        public double CalculateArgument
        {
            get { return ArgumentNumber = Math.Atan(b / a); }
        }

        public static Complex operator + (Complex RealPart, Complex ImaginaryPart )
        {
            Complex complexNumber = new Complex();
            complexNumber.Real = RealPart.Real + ImaginaryPart.Real;
            complexNumber.Imaginary = RealPart.Imaginary + ImaginaryPart.Imaginary;
            return complexNumber;
        } 

        public static Complex operator - (Complex RealPart, Complex ImaginaryPart )
        {
            Complex complexNumber = new Complex();
            complexNumber.Real = RealPart.Real - ImaginaryPart.Real;
            complexNumber.Imaginary = RealPart.Imaginary - ImaginaryPart.Imaginary;
            return complexNumber;
        } 

        public static Complex operator * (Complex RealPart, Complex ImaginaryPart )
        {
            Complex complexNumber = new Complex();
            complexNumber.Real = RealPart.Real * ImaginaryPart.Real - RealPart.Imaginary * ImaginaryPart.Imaginary;
            complexNumber.Imaginary = RealPart.Imaginary * ImaginaryPart.Real + RealPart.Real * ImaginaryPart.Imaginary;
            return complexNumber;
        } 

        public override string ToString()

            {
            return $" {Real} + {Imaginary} ";
            }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Complex firstComplex = new Complex(1, 1);
            Complex secondComplex = new Complex(1, 1);
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
