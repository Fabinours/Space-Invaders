using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SpaceInvaders.Resources
{
    class Vecteur2D
    {
        private double x = 0;
        private double y = 0;
        private double norme;
        public double Norme { get => norme; }
        public double X { get => x; }
        public double Y { get => y; }

        public Vecteur2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vecteur2D operator +(Vecteur2D v1, Vecteur2D v2)
        { return new Vecteur2D(v1.X + v2.X, v1.Y + v2.Y); }

        public static Vecteur2D operator -(Vecteur2D v1, Vecteur2D v2)
        { return new Vecteur2D(v1.X - v2.X, v1.Y - v2.Y); }

        public static Vecteur2D operator -(Vecteur2D v1)
        { return new Vecteur2D(-v1.X, -v1.Y); }

        public static Vecteur2D operator *(Vecteur2D v1, double d)
        { return new Vecteur2D(v1.X * d, v1.Y * d); }

        public static Vecteur2D operator *(double d, Vecteur2D v1)
        { 
            return new Vecteur2D(v1.X * d, v1.Y * d);
        }
        public static Vecteur2D operator /(Vecteur2D v1, double d)
        {
            if (d == 0)
            {
                throw new ArgumentException("Division par un scalaire à zéro");
            }
            return new Vecteur2D(v1.X / d, v1.Y / d); 
        }

        public override String ToString()
        {
            return "x = " + x + ", y = " + y + ";";
        }
    }
}
