using System;

namespace Decorator.Examples
{
    // Main application
    class MainApp
    {
        static void Main()
        {
            // 1. Звичайна ялинка
            Console.WriteLine("1. Simple Christmas tree:");
            Component tree = new ChristmasTree(1.8);
            tree.Operation();
            Console.WriteLine();

            // 2. Ялинка з прикрасами
            Console.WriteLine("2. Christmas tree with ornaments:");
            OrnamentDecorator balls = new OrnamentDecorator("glass balls", 20);
            balls.SetComponent(tree);
            balls.Operation();
            Console.WriteLine();

            // 3. Ялинка з гірляндою
            Console.WriteLine("3. Christmas tree with garland:");
            GarlandDecorator garland = new GarlandDecorator("warm white");
            garland.SetComponent(tree);
            garland.Operation();
            garland.LightUp();
            garland.Operation();
            Console.WriteLine();

            // 4. Повністю прикрашена ялинка: ялинка -> кульки -> зірка -> гірлянда
            Console.WriteLine("4. Fully decorated Christmas tree:");
            OrnamentDecorator fullBalls = new OrnamentDecorator("glass balls", 30);
            fullBalls.SetComponent(tree);

            OrnamentDecorator star = new OrnamentDecorator("star on top", 1);
            star.SetComponent(fullBalls);

            GarlandDecorator fullGarland = new GarlandDecorator("multicolor");
            fullGarland.SetComponent(star);

            fullGarland.LightUp();
            fullGarland.Operation();
            fullGarland.TurnOff();
            fullGarland.Operation();

            Console.ReadKey();
        }
    }

    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ChristmasTree : Component
    {
        private readonly double height;

        public ChristmasTree(double height)
        {
            this.height = height;
        }

        public override void Operation()
        {
            Console.WriteLine("Christmas tree, height: " + height + " m");
        }
    }

    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            component?.Operation();
        }
    }

    // "ConcreteDecoratorA" - ялинкові прикраси (додає стан - поля)
    class OrnamentDecorator : Decorator
    {
        private readonly string ornamentType;
        private readonly int count;

        public OrnamentDecorator(string ornamentType, int count)
        {
            this.ornamentType = ornamentType;
            this.count = count;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("  + ornaments: " + ornamentType + " x" + count);
        }
    }

    // "ConcreteDecoratorB" - гірлянда (додає поведінку - метод LightUp)
    class GarlandDecorator : Decorator
    {
        private readonly string color;
        private bool isLighting;

        public GarlandDecorator(string color)
        {
            this.color = color;
            isLighting = false;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("  + garland: " + color + " [" + (isLighting ? "ON" : "OFF") + "]");
        }

        public void LightUp()
        {
            isLighting = true;
            Console.WriteLine("*** The tree is glowing! ***");
        }

        public void TurnOff()
        {
            isLighting = false;
            Console.WriteLine("Garland turned off.");
        }
    }
}