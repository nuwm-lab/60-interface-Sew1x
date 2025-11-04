using System;

namespace Lab6_AbstractClass
{
    abstract class FractionalFunction
    {
        protected double x0;

        public FractionalFunction()
        {
            Console.WriteLine("Конструктор базового класу викликано");
        }

        ~FractionalFunction()
        {
            Console.WriteLine("Деструктор базового класу викликано");
        }

        public abstract void InputCoefficients();
        public abstract void DisplayCoefficients();
        public abstract double CalculateValue(double x);
        
        public virtual void InputPoint()
        {
            Console.Write("x0: ");
            x0 = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void ShowValueAtPoint()
        {
            Console.WriteLine($"f({x0}) = {CalculateValue(x0):F4}");
        }
    }

    class LinearFractionalFunction : FractionalFunction
    {
        private double a1, a0, b1, b0;

        public LinearFractionalFunction() : base()
        {
            Console.WriteLine("Конструктор LinearFractionalFunction викликано");
        }

        ~LinearFractionalFunction()
        {
            Console.WriteLine("Деструктор LinearFractionalFunction викликано");
        }

        public override void InputCoefficients()
        {
            Console.Write("a1 a0 b1 b0: ");
            var input = Console.ReadLine().Split();
            a1 = Convert.ToDouble(input[0]);
            a0 = Convert.ToDouble(input[1]);
            b1 = Convert.ToDouble(input[2]);
            b0 = Convert.ToDouble(input[3]);
        }

        public override void DisplayCoefficients()
        {
            Console.WriteLine($"({a1}x + {a0}) / ({b1}x + {b0})");
        }

        public override double CalculateValue(double x)
        {
            double d = b1 * x + b0;
            return Math.Abs(d) < 1e-10 ? double.NaN : (a1 * x + a0) / d;
        }
    }

    class QuadraticFractionalFunction : FractionalFunction
    {
        private double a2, a1, a0, b2, b1, b0;

        public QuadraticFractionalFunction() : base()
        {
            Console.WriteLine("Конструктор QuadraticFractionalFunction викликано");
        }

        ~QuadraticFractionalFunction()
        {
            Console.WriteLine("Деструктор QuadraticFractionalFunction викликано");
        }

        public override void InputCoefficients()
        {
            Console.Write("a2 a1 a0 b2 b1 b0: ");
            var input = Console.ReadLine().Split();
            a2 = Convert.ToDouble(input[0]);
            a1 = Convert.ToDouble(input[1]);
            a0 = Convert.ToDouble(input[2]);
            b2 = Convert.ToDouble(input[3]);
            b1 = Convert.ToDouble(input[4]);
            b0 = Convert.ToDouble(input[5]);
        }

        public override void DisplayCoefficients()
        {
            Console.WriteLine($"({a2}x² + {a1}x + {a0}) / ({b2}x² + {b1}x + {b0})");
        }

        public override double CalculateValue(double x)
        {
            double d = b2 * x * x + b1 * x + b0;
            return Math.Abs(d) < 1e-10 ? double.NaN : (a2 * x * x + a1 * x + a0) / d;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Лабораторна №6: Абстрактні класи\n");

            FractionalFunction function = null;
            
            do
            {
                Console.WriteLine("\n1 - Дробово-лінійна (a₁x+a₀)/(b₁x+b₀)");
                Console.WriteLine("2 - Дробова (a₂x²+a₁x+a₀)/(b₂x²+b₁x+b₀)");
                Console.WriteLine("0 - Вихід");
                Console.Write("Вибір: ");
                
                string choice = Console.ReadLine();

                if (choice == "0") break;
                
                if (choice == "1")
                    function = new LinearFractionalFunction();
                else if (choice == "2")
                    function = new QuadraticFractionalFunction();
                else
                {
                    Console.WriteLine("Невірний вибір!");
                    continue;
                }

                function.InputCoefficients();
                function.InputPoint();
                function.DisplayCoefficients();
                function.ShowValueAtPoint();

            } while (true);

            Console.WriteLine("\nПрограма завершена.");
        }
    }
}
