using System;

namespace FactoryMethodExample
{
    // Abstract Product
    public abstract class Product
    {
        public abstract string Info();
    }

    // Concrete Products
    public class ConcreteProductA : Product
    {
        public override string Info() { return "ConcreteProductA"; }
    }

    public class ConcreteProductB : Product
    {
        public override string Info() { return "ConcreteProductB"; }
    }

    // New Concrete Product
    public class ConcreteProductC : Product
    {
        public override string Info() { return "ConcreteProductC"; }
    }

    // Abstract Creator
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    // Concrete Creator
    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                case 1: return new ConcreteProductA();
                case 2: return new ConcreteProductB();
                case 3: return new ConcreteProductC();
                default: throw new ArgumentException("Invalid type: " + type, "type");
            }
        }
    }

    class MainApp
    {
        static void Main()
        {
            Creator creator = new ConcreteCreator();

            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    Product product = creator.FactoryMethod(i);
                    Console.WriteLine("Where id = {0}, Created {1}", i, product.Info());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Where id = {0}, Error: {1}", i, ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}