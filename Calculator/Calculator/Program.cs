using System;

namespace Calculator
{
    class Program
    {
        private enum MathOperator
        {
            Add,
            Sub,
            Mult,
            Div,
            NoOperator,
        }
        static void Main(string[] args)
        {
            double lValue = GetDoubleOperand();
            double rValue = GetDoubleOperand();
            MathOperator mathOperator = GetMathOperator();
            DoCalculation(lValue, rValue, mathOperator);
        }

        static double GetDoubleOperand()
        {
            Console.WriteLine("Enter a number: ");
            double result;
            while (!double.TryParse(Console.ReadLine(), out result)) {
                Console.WriteLine("Invalid number value. Try again:");
            }

            return result;
        }

        static MathOperator GetMathOperator()
        {
            Console.WriteLine("Enter one of the following math operator: +, -, *, /");
            switch ((char)Console.Read())
            {
                case '+': 
                    return MathOperator.Add;
                case '-':
                    return MathOperator.Sub;
                case '*':
                    return MathOperator.Mult;
                case '/':
                    return MathOperator.Div;
                default:
                    return MathOperator.NoOperator;
            }
        }

        static double CalculateOperation(double lValue, double rValue, MathOperator mathOperator, ref bool wasError)
        {
            const int NO_RESULT = 0;
            switch (mathOperator)
            {
                case MathOperator.Add:
                    return lValue + rValue;
                case MathOperator.Sub:
                    return lValue - rValue;
                case MathOperator.Div:
                    {
                        if (rValue == 0)
                        {
                            Console.WriteLine("Division by 0 was found");
                            wasError = true;

                            return NO_RESULT;
                        }

                        return lValue / rValue;
                    }
                case MathOperator.Mult:
                    return lValue * rValue;
                case MathOperator.NoOperator:
                    {
                        Console.WriteLine("Invalid math operator was found");
                        wasError = true;

                        return NO_RESULT;
                    }
                default:
                    {
                        Console.WriteLine("Internal error was found");
                        wasError = true;

                        return NO_RESULT;
                    }
            }
        }

        static void PrintOperationResult(double result, bool wasError)
        {
            if (wasError)
            {
                Console.WriteLine("Can't print operation result");
            }
            else
            {
                Console.WriteLine("Result equal to " + result);
            }
        }

        static void DoCalculation(double lValue, double rValue, MathOperator mathOperator)
        {
            bool wasError = false;
            double result = CalculateOperation(lValue, rValue, mathOperator, ref wasError);
            PrintOperationResult(result, wasError);
        }
    }
}
