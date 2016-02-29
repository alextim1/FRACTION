using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractionOperations
{
    public interface IFraction
    {
        int Numerator { get; }
        int Denominator { get; }
        void OptimizeFraction();
    }


    public class Fraction : IFraction
    {
        private int _numerator;
        private int _denominator;

        public Fraction(string fraction)
        {
            string[] fractionParts = fraction.Split('/');
            
            if(!((fractionParts.Length==1)||(fractionParts.Length==2)))
            {
                throw new ArgumentException();
            }

            if (fractionParts.Length == 1)
            {
                try
                {
                    _numerator = int.Parse(fractionParts[0]);

                    _denominator = 1;

                }

                catch (Exception e)
                {
                    throw new ArgumentException();
                }

                _denominator = 1;
            }

            else
            {
                try
                {
                    _numerator = int.Parse(fractionParts[0]);
                    _denominator = int.Parse(fractionParts[1]);

                }

                catch (Exception e)
                {
                    throw new ArgumentException();
                }
            }
            

            if (_denominator==0)
            {
                throw new ArgumentException();
            }

            OptimizeFraction();
        }

        public Fraction(object numerator, object denomenator)
            :this (numerator.ToString()+@"/"+denomenator.ToString())
        {

        }

        public override string ToString()
        {
            return (_numerator.ToString()+"/"+_denominator.ToString());
        }

        public int Denominator
        {
            get
            {
                return _denominator;
            }
        }

        public int Numerator
        {
            get
            {
                return _numerator;
            }
        }

        private int GCD(int a, int b)
        {
            if (a == 0)
                return b;

            if (b == 0)
                return Math.Abs(a);

            return GCD(b, a % b);
        }

        public void OptimizeFraction()
        {
            int gcd = GCD(_numerator, _denominator);
            _numerator = _numerator / gcd;
            _denominator = _denominator / gcd;

            if ((_numerator<0)&&(_denominator<0))
            {
                _numerator = Math.Abs(_numerator);
                _denominator = Math.Abs(_denominator);
            }

            if (_denominator<0)
            {
                _numerator = -(_numerator);
                _denominator = Math.Abs(_denominator);
            }
        }
    }


    public static class FractionCalculator
    {
        public static Fraction Add(Fraction arg1, Fraction arg2)
        {
            Fraction result = new Fraction((arg1.Numerator * arg2.Denominator + arg2.Numerator * arg1.Denominator).ToString() + "/" + (arg1.Denominator * arg2.Denominator).ToString());
            result.OptimizeFraction();
            return result;
        }

        public static Fraction Mul(Fraction arg1, Fraction arg2)
        {
            Fraction result = new Fraction((arg1.Numerator * arg2.Numerator).ToString() + "/" + (arg1.Denominator * arg2.Denominator).ToString());
            result.OptimizeFraction();
            return result;
        }

        public static Fraction Sub(Fraction arg1, Fraction arg2)
        {
            Fraction minusOne = new Fraction("-1/1");
            Fraction result = (Add(arg1, Mul(minusOne, arg2)));
            result.OptimizeFraction();
            return result;
        }

        public static Fraction Div(Fraction arg1, Fraction arg2)
        {
            if (arg2.Numerator == 0)
                throw new DivideByZeroException();

            Fraction result = new Fraction((arg1.Numerator*arg2.Denominator).ToString()+"/"+(arg1.Denominator*arg2.Numerator).ToString());
            result.OptimizeFraction();
            return result;
        }

    }
}
