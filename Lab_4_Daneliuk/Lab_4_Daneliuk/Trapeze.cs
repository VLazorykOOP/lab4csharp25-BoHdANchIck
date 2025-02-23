using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Daneliuk
{
    class Trapeze
    {
        private int a, b, h;
        private int c;

        public Trapeze(int a, int b, int h, int c)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = c;
        }

        //indexer
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return h;
                    case 3: return c;
                    default: throw new Exception("Invalid index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: h = value; break;
                    case 3: c = value; break;
                    default: throw new Exception("Invalid index!");
                }
            }
        }
        // overload operator
        public static Trapeze operator ++(Trapeze t1)
        {
            return new Trapeze(t1.a + 1, t1.b + 1, t1.h, t1.c);
        }
        public static Trapeze operator --(Trapeze t1)
        {
            return new Trapeze(t1.a - 1, t1.b - 1, t1.h, t1.c);
        }

        public static Trapeze operator *(Trapeze t1, int n)
        {
            return new Trapeze(t1.a * n, t1.b, t1.h * n, t1.c);
        }

        // Overload true and false operators
        public static bool operator true(Trapeze t)
        {
            return t.a > 0 && t.b > 0 && t.h > 0;
        }

        public static bool operator false(Trapeze t)
        {
            return t.a <= 0 || t.b <= 0 || t.h <= 0;
        }
        public static bool operator !(Trapeze t)
        {
            return !(t.a > 0 && t.b > 0 && t.h > 0);
        }
        // explicit and implicit operators
        public static implicit operator string(Trapeze t)
        {
            return $"{t.a},{t.b},{t.h},{t.c}";
        }
        public static explicit operator Trapeze(string str)
        {   try
            {
                string[] parts = str.Split(',');
                if (parts.Length != 4)
                    throw new ArgumentException("Invalid string format for Trapeze conversion.");

                int a = int.Parse(parts[0]);
                int b = int.Parse(parts[1]);
                int h = int.Parse(parts[2]);
                int c = int.Parse(parts[3]);

                return new Trapeze(a, b, h, c);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            
        }


        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public int H
        {
            get { return h; }
            set { h = value; }
        }

        public int Color
        {
            get { return c; }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Trapeze: a = {a}, b = {b}, h = {h}, color = {c}");
        }

        public double Perimeter()
        {
            double side = Math.Sqrt(Math.Pow((a - b) / 2.0, 2) + Math.Pow(h, 2));
            return a + b + 2 * side;
        }

        public double Area()
        {
            return ((a + b) / 2.0) * h;
        }

        public bool IsSquare
        {
            get { return a == b && a == h; }
        }
    }
}
