using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation{
    class Program{
        //static function which returns the triangulated position in a vector2
        public static Vector2 GetPosition(Vector2 posA, Vector2 posB, Vector2 posC, float distToA, float distToB, float distToC){
            //set the variables from the parameters
            var A = posA;
            var B = posB;
            var C = posC;
            var dA = distToA;
            var dB = distToB;
            var dC = distToC;
            
            //calculate some stuff cant explain and not necesary to know what this does
            var W = Pow(dA) - Pow(dB) - Pow(A.X) - Pow(A.Y) + Pow(B.X) + Pow(B.Y);
            var Z = Pow(dB) - Pow(dC) - Pow(B.X) - Pow(B.Y) + Pow(C.X) + Pow(C.Y);
            
            //calculate the x coordinate of the target
            var x = (W * (C.Y - B.Y) - Z * (B.Y - A.Y)) / (2 * ((B.X - A.X) * (C.Y - B.Y) - (C.X - B.X) * (B.Y - A.Y)));
            
            //calculate the y coordinate of the target y2 is for possible errors and redundency
            var y = (W - 2 * x * (B.X - A.X)) / (2 * (B.Y - A.Y));
            var y2 = (Z - 2 * x * (C.X - B.X)) / (2 * (C.Y - B.Y));
            y = (y + y2) / 2;
            
            //create a new vector2 with the coordinates of the target and return it
            var P = new Vector2(x, y);
            Console.WriteLine(P.ToString());
            return P;
        }
        
        static void Main(string[] args){
            var posA = new Vector2(11, 7);
            var posB = new Vector2(24, 15);
            var posC = new Vector2(14, 20);
            var distToA = 8f;
            var distToB = 5f;
            var distToC = 5f;
            getPosition(posA, posB, posC, distToA, distToB, distToC);
            Console.ReadLine();
        }

        public static float Pow(float i) { return i * i; }
    }
    
    // home made Vector2 class, this way we dont have to import Monogame 
    public class Vector2{
        public readonly float X;
        public readonly float Y;
        public Vector2(float x, float y){
            X = x;
            Y = y;
        }

        public override string ToString(){
            return "X: " + Math.Round(X, 0).ToString() + "\nY: " + Math.Round(Y, 0).ToString();
        }
    }
}
