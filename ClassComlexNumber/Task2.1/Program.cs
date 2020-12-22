using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{

    class Complex
    {

        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex() :this (0, 0) {}
        public Complex(double Real) : this(Real, 0) { }

        public Complex(double Real, double Imaginary)
        {
            this.Real = Real;
            this.Imaginary = Imaginary;
        }

        public static Complex operator +(Complex firstNumber, Complex secondNumber)
        {
            Complex complexNumber = new Complex();
            complexNumber.Real = firstNumber.Real + secondNumber.Real;
            complexNumber.Imaginary = firstNumber.Imaginary + secondNumber.Imaginary;
            return complexNumber;
        }

        public static Complex operator -(Complex firstNumber, Complex secondNumber)
        {
            Complex complexNumber = new Complex();
            complexNumber.Real = firstNumber.Real - secondNumber.Real;
            complexNumber.Imaginary = firstNumber.Imaginary - secondNumber.Imaginary;
            return complexNumber;
        }

        public static Complex operator *(Complex firstNumber, Complex secondNumber)
        {
            Complex complexNumber = new Complex();
            complexNumber.Real = firstNumber.Real * secondNumber.Real - firstNumber.Imaginary * secondNumber.Imaginary;
            complexNumber.Imaginary = firstNumber.Imaginary * secondNumber.Real + firstNumber.Real * secondNumber.Imaginary;
            return complexNumber;
        }

        public override string ToString()

            {
            return $" {Real} + {Imaginary}*i";
            }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Complex firstComplex = new Complex(5, 7);
            Complex secondComplex = new Complex(2, 3);
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
