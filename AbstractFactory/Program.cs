using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();

        public void Interact(Engine engine)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info() => Console.WriteLine("Ford");
    }

    // ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info() => Console.WriteLine("Toyota");
    }

    // ConcreteProductA3
    public class Mersedes : Car
    {
        public override void Info() => Console.WriteLine("Mersedes");
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower() { }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower() => Console.WriteLine("Ford Engine 4.4");
    }

    // ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower() => Console.WriteLine("Toyota Engine 3.2");
    }

    // ConcreteProductB3
    public class MersedesEngine : Engine
    {
        public override void GetPower() => Console.WriteLine("Mersedes Engine 5.0");
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        Car ICarFactory.CreateCar() => new Ford();
        Engine ICarFactory.CreateEngine() => new FordEngine();
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        Car ICarFactory.CreateCar() => new Toyota();
        Engine ICarFactory.CreateEngine() => new ToyotaEngine();
    }

    // ConcreteFactory3
    public class MersedesFactory : ICarFactory
    {
        Car ICarFactory.CreateCar() => new Mersedes();
        Engine ICarFactory.CreateEngine() => new MersedesEngine();
    }

    // Client
    public class ClientFactory
    {
        private readonly Car car;
        private readonly Engine engine;

        public ClientFactory(ICarFactory factory)
        {
            car = factory.CreateCar();
            engine = factory.CreateEngine();
        }

        public void Run() => car.Interact(engine);
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory[] factories =
            {
                new ToyotaFactory(),
                new FordFactory(),
                new MersedesFactory()
            };

            foreach (ICarFactory factory in factories)
            {
                new ClientFactory(factory).Run();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}