using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new Vector2(11, 7);
            var B = new Vector2(24, 15);
            var C = new Vector2(14, 20);
            var dA = 8f;
            var dB = 5f;
            var dC = 5f;

            var W = Pow(dA) - Pow(dB) - Pow(A.X) - Pow(A.Y) + Pow(B.X) + Pow(B.Y);
            var Z = Pow(dB) - Pow(dC) - Pow(B.X) - Pow(B.Y) + Pow(C.X) + Pow(C.Y);

            var x = (W * (C.Y - B.Y) - Z * (B.Y - A.Y)) / (2 * ((B.X - A.X) * (C.Y - B.Y) - (C.X - B.X) * (B.Y - A.Y)));
            var y = (W - 2 * x * (B.X - A.X)) / (2 * (B.Y - A.Y));
            var y2 = (Z - 2 * x * (C.X - B.X)) / (2 * (C.Y - B.Y));


            y = (y + y2) / 2;

            var P = new Vector2(x, y);
            Console.WriteLine(P.ToString());
            Console.ReadLine();
        }

        public static float Pow(float i) { return i * i; }

        public static Vector2 GetLocation(Dictionary<string, Circle>)
        {

        }
    }


    public class Vector2
    {
        public readonly float X;
        public readonly float Y;
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "X: " + Math.Round(X, 0).ToString() + "\nY: " + Math.Round(Y, 0).ToString();
        }
    }

    public class Circle
    {
        public readonly Vector2 Center;
        public readonly float Radius;

        public Circle(Vector2 c, float r)
        {
            Center = c;
            Radius = r;
        }
    }
}
