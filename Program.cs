using System;

using System;

// Абстрактний клас для дробово-лінійної функції
public abstract class FractionalLinearFunction
{
	// Коефіцієнти чисельника та знаменника
	protected double a1, a0, b1, b0;

	// Конструктор для ініціалізації коефіцієнтів
	public FractionalLinearFunction(double a1, double a0, double b1, double b0)
	{
		this.a1 = a1;
		this.a0 = a0;
		this.b1 = b1;
		this.b0 = b0;
		Console.WriteLine("FractionalLinearFunction created");
	}

	// Деструктор для демонстрації знищення об'єкта

	~FractionalLinearFunction()
	{
		Console.WriteLine("FractionalLinearFunction destroyed");
	}

	// Абстрактний метод для встановлення коефіцієнтів
	public abstract void SetCoefficients(double a1, double a0, double b1, double b0);
	// Абстрактний метод для виведення коефіцієнтів
	public abstract void PrintCoefficients();
	// Абстрактний метод для обчислення значення функції
	public abstract double Calculate(double x);
}

// Клас-нащадок для дробово-лінійної функції
public class SimpleFractionalLinearFunction : FractionalLinearFunction
{
	// Конструктор, викликає базовий конструктор
	public SimpleFractionalLinearFunction(double a1, double a0, double b1, double b0)
		: base(a1, a0, b1, b0) { }

	// Деструктор
	~SimpleFractionalLinearFunction()
	{
		Console.WriteLine("SimpleFractionalLinearFunction destroyed");
	}

	// Реалізація встановлення коефіцієнтів
	public override void SetCoefficients(double a1, double a0, double b1, double b0)
	{
		this.a1 = a1;
		this.a0 = a0;
		this.b1 = b1;
		this.b0 = b0;
	}

	// Реалізація виведення коефіцієнтів
	public override void PrintCoefficients()
	{
		Console.WriteLine($"Numerator: {a1}*x + {a0}, Denominator: {b1}*x + {b0}");
	}

	// Реалізація обчислення значення функції
	public override double Calculate(double x)
	{
		return (a1 * x + a0) / (b1 * x + b0);
	}
}

// Інтерфейс для дробово-лінійної функції
public interface IFractionalFunction
{
	// Встановлення коефіцієнтів
	void SetCoefficients(double a1, double a0, double b1, double b0);
	// Виведення коефіцієнтів
	void PrintCoefficients();
	// Обчислення значення функції
	double Calculate(double x);
}

// Клас, що реалізує інтерфейс дробово-лінійної функції
public class InterfaceFractionalFunction : IFractionalFunction
{
	// Коефіцієнти чисельника та знаменника
	private double a1, a0, b1, b0;

	// Конструктор для ініціалізації коефіцієнтів
	public InterfaceFractionalFunction(double a1, double a0, double b1, double b0)
	{
		this.a1 = a1;
		this.a0 = a0;
		this.b1 = b1;
		this.b0 = b0;
		Console.WriteLine("InterfaceFractionalFunction created");
	}

	// Деструктор

	~InterfaceFractionalFunction()
	{
		Console.WriteLine("InterfaceFractionalFunction destroyed");
	}

	// Реалізація встановлення коефіцієнтів
	public void SetCoefficients(double a1, double a0, double b1, double b0)
	{
		this.a1 = a1;
		this.a0 = a0;
		this.b1 = b1;
		this.b0 = b0;
	}

	// Реалізація виведення коефіцієнтів
	public void PrintCoefficients()
	{
		Console.WriteLine($"Numerator: {a1}*x + {a0}, Denominator: {b1}*x + {b0}");
	}

	// Реалізація обчислення значення функції
	public double Calculate(double x)
	{
		return (a1 * x + a0) / (b1 * x + b0);
	}
}

// Головний клас для демонстрації роботи
public class Program
{
	// Точка входу програми
	public static void Main(string[] args)
	{
	// Створення та демонстрація роботи класу-нащадка абстрактного класу
	SimpleFractionalLinearFunction f1 = new SimpleFractionalLinearFunction(1, 2, 3, 4);
	f1.PrintCoefficients();
	Console.WriteLine("Value at x=2: " + f1.Calculate(2));

	// Створення та демонстрація роботи класу, що реалізує інтерфейс
	InterfaceFractionalFunction f2 = new InterfaceFractionalFunction(5, 6, 7, 8);
	f2.PrintCoefficients();
	Console.WriteLine("Value at x=2: " + f2.Calculate(2));

	// Спроба створити екземпляр абстрактного класу (буде помилка компіляції)
	// FractionalLinearFunction f3 = new FractionalLinearFunction(1,2,3,4); // Error! Абстрактний клас не можна створити напряму
	}
}
