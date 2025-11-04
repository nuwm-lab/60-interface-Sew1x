using System;

namespace Lab6_AbstractClass
{
    // Інтерфейс для функцій - визначає контракт (тільки сигнатури методів)
    interface IFunction
    {
        double CalculateValue(double x);
        void DisplayCoefficients();
    }

    // Інтерфейс для об'єктів, які можна вивести на екран
    interface IPrintable
    {
        void Print();
        string GetInfo();
    }

    // Абстрактний клас - може містити поля, конструктори, реалізовані методи
    abstract class FractionalFunction : IFunction, IPrintable
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

        // Реалізація інтерфейсу IPrintable
        public virtual void Print()
        {
            Console.WriteLine("=== Інформація про функцію ===");
            DisplayCoefficients();
            Console.WriteLine($"Точка обчислення: x0 = {x0}");
        }

        public virtual string GetInfo()
        {
            return $"Дробово-раціональна функція, x0 = {x0}";
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

        // Перевизначення методу з IPrintable
        public override string GetInfo()
        {
            return $"Дробово-лінійна функція: ({a1}x+{a0})/({b1}x+{b0})";
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

        // Перевизначення методу з IPrintable
        public override string GetInfo()
        {
            return $"Дробова функція: ({a2}x²+{a1}x+{a0})/({b2}x²+{b1}x+{b0})";
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
                
                // Виклик через абстрактний клас
                function.DisplayCoefficients();
                function.ShowValueAtPoint();

                // Виклик через інтерфейс IFunction
                Console.WriteLine("\n--- Робота через інтерфейс IFunction ---");
                IFunction iFunc = function;
                Console.Write("Введіть x для обчислення: ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Результат: {iFunc.CalculateValue(x):F4}");

                // Виклик через інтерфейс IPrintable
                Console.WriteLine("\n--- Робота через інтерфейс IPrintable ---");
                IPrintable iPrint = function;
                iPrint.Print();
                Console.WriteLine($"Info: {iPrint.GetInfo()}");

            } while (true);

            Console.WriteLine("\n=== АНАЛІЗ ===");
            Console.WriteLine("Абстрактний клас:");
            Console.WriteLine("  ✓ Має конструктори і деструктори");
            Console.WriteLine("  ✓ Містить поля (x0)");
            Console.WriteLine("  ✓ Реалізовані методи (InputPoint, ShowValueAtPoint)");
            Console.WriteLine("  ✓ Абстрактні методи");
            Console.WriteLine("\nІнтерфейс:");
            Console.WriteLine("  ✓ Тільки сигнатури методів");
            Console.WriteLine("  ✓ Можна реалізувати багато інтерфейсів");
            Console.WriteLine("  ✓ Не містить полів і конструкторів");
            Console.WriteLine("\nПрограма завершена.");
        }
    }
}
