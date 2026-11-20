using System;
using System.Text;

namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFigure[] prototypes =
            {
                new Rectangle(10, 20),
                new Circle(15),
                new Triangle(3, 4, 5)
            };

            foreach (IFigure figure in prototypes)
            {
                IFigure clonedFigure = figure.Clone();

                Console.Write("Оригінал: ");
                figure.GetInfo();
                Console.Write("Клон:     ");
                clonedFigure.GetInfo();
                Console.WriteLine("Той самий об'єкт? {0}", ReferenceEquals(figure, clonedFigure));
                Console.WriteLine();
            }

            // Перевірка: неіснуючий трикутник
            try
            {
                IFigure wrong = new Triangle(1, 2, 10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            Console.Read();
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        private readonly int width;
        private readonly int height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} і шириною {1}", height, width);
        }
    }

    class Circle : IFigure
    {
        private readonly int radius;

        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(this.radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", radius);
        }
    }

    class Triangle : IFigure
    {
        private readonly int sideA;
        private readonly int sideB;
        private readonly int sideC;

        public Triangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Сторони трикутника мають бути додатними.");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException(
                    string.Format("Трикутник зі сторонами {0}, {1}, {2} не існує.", a, b, c));

            sideA = a;
            sideB = b;
            sideC = c;
        }

        public IFigure Clone()
        {
            return new Triangle(this.sideA, this.sideB, this.sideC);
        }

        public void GetInfo()
        {
            Console.WriteLine("Трикутник зі сторонами {0}, {1}, {2}", sideA, sideB, sideC);
        }
    }
}