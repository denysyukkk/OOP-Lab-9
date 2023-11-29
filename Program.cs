// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IShape
{
    double GetArea();
}

public abstract class ShapeBase : IShape
{
    public abstract double GetArea();
}

public class Circle : ShapeBase
{
    private readonly double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Triangle : ShapeBase
{
    private readonly double baseLength;
    private readonly double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double GetArea()
    {
        return 0.5 * baseLength * height;
    }
}

public class Square : ShapeBase
{
    private readonly double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side;
    }
}

public interface IComparableByWeight : IComparable<Animal>
{
    double Weight { get; }
}

public interface IComparerByHeight : IComparer<Animal>
{
    // Метод Compare вже є в інтерфейсі IComparer<T>
}

public interface IAnimalEnumerable : IEnumerable<Animal>
{
    // Метод GetEnumerator вже є в інтерфейсі IEnumerable<T>
}

public class Animal : IComparableByWeight
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }

    public int CompareTo(Animal other)
    {
        return Weight.CompareTo(other.Weight);
    }
}

public class HeightComparer : IComparerByHeight
{
    public int Compare(Animal x, Animal y)
    {
        return x.Height.CompareTo(y.Height);
    }
}

public class AnimalCollection : IAnimalEnumerable
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public IEnumerator<Animal> GetEnumerator()
    {
        return animals.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<Animal> OrderByWeight()
    {
        return animals.OrderBy(animal => animal.Weight);
    }

    public IEnumerable<Animal> OrderByHeight()
    {
        return animals.OrderBy(animal => animal.Height);
    }
}

class Program
{
    static void Main()
    {
        // Завдання 1: Робота з фігурами
        Circle circle = new Circle(5);
        Triangle triangle = new Triangle(3, 4);
        Square square = new Square(6);

        Console.WriteLine("Area of Circle: " + circle.GetArea());
        Console.WriteLine("Area of Triangle: " + triangle.GetArea());
        Console.WriteLine("Area of Square: " + square.GetArea());

        // Завдання 2: Робота з тваринами
        Animal dog = new Animal { Name = "Dog", Weight = 15.5, Height = 25.0 };
        Animal cat = new Animal { Name = "Cat", Weight = 10.2, Height = 20.5 };

        AnimalCollection animalCollection = new AnimalCollection();
        animalCollection.AddAnimal(dog);
        animalCollection.AddAnimal(cat);

        Console.WriteLine("\nAnimals sorted by weight:");
        foreach (var animal in animalCollection.OrderByWeight())
        {
            Console.WriteLine($"Name: {animal.Name}, Weight: {animal.Weight}");
        }

        Console.WriteLine("\nAnimals sorted by height:");
        foreach (var animal in animalCollection.OrderByHeight())
        {
            Console.WriteLine($"Name: {animal.Name}, Height: {animal.Height}");
        }
    }
}
