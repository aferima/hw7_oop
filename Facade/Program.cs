using System;

namespace Facade.Examples
{
    // Main application
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();
            facade.MethodC();

            Console.Read();
        }
    }

    // Subsystem Class A
    class SubSystemOne
    {
        public void MethodOne() { Console.WriteLine(" SubSystemOne Method"); }
    }

    // Subsystem Class B
    class SubSystemTwo
    {
        public void MethodTwo() { Console.WriteLine(" SubSystemTwo Method"); }
    }

    // Subsystem Class C
    class SubSystemThree
    {
        public void MethodThree() { Console.WriteLine(" SubSystemThree Method"); }
    }

    // New Subsystem Class D
    class SubSystemFour
    {
        public void MethodFour() { Console.WriteLine(" SubSystemFour Method"); }
    }

    // Facade
    class Facade
    {
        private readonly SubSystemOne one;
        private readonly SubSystemTwo two;
        private readonly SubSystemThree three;
        private readonly SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }

        // New Facade Method
        public void MethodC()
        {
            Console.WriteLine("\nMethodC() ---- ");
            one.MethodOne();
            three.MethodThree();
            four.MethodFour();
        }
    }
}