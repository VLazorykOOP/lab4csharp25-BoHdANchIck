namespace Lab_4_Daneliuk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        static void Task1()
        {
            Console.WriteLine("#Task_1\n");

            Trapeze t1 = new Trapeze(5, 7, 3, 1);
            Console.WriteLine("Initial Trapeze:");
            t1.PrintInfo();
            Console.WriteLine($"Perimeter: {t1.Perimeter()}");
            Console.WriteLine($"Area: {t1.Area()}");
            Console.WriteLine($"Is Square: {t1.IsSquare}\n");

            Console.WriteLine("Indexer Test:");
            Console.WriteLine($"t1[0] (a) = {t1[0]}");
            Console.WriteLine($"t1[1] (b) = {t1[1]}");
            Console.WriteLine($"t1[2] (h) = {t1[2]}");
            Console.WriteLine($"t1[3] (color) = {t1[3]}\n");

            t1[0] = 6;
            Console.WriteLine("After changing a via indexer:");
            t1.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("Operator Overloading Test:");
            t1++;
            Console.WriteLine("After ++ :");
            t1.PrintInfo();

            t1--;
            Console.WriteLine("After -- :");
            t1.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("Multiplication Test:");
            Trapeze t2 = t1 * 2;
            t2.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("Boolean Operators Test:");
            Trapeze t3 = new Trapeze(0, 5, 3, 2); 
            if (t1)
                Console.WriteLine("t1 is a valid trapeze.");
            else
                Console.WriteLine("t1 is not valid.");

            if (!t3)
                Console.WriteLine("t3 is an invalid trapeze.");
            else
                Console.WriteLine("t3 is valid.");
            Console.WriteLine();

            Console.WriteLine("String Conversion Test:");
            string str = t1;
            Console.WriteLine($"String representation: {str}");

            Console.WriteLine("\nParsing from string:");
            try
            {
                Trapeze t4 = (Trapeze)"10,15,5,3";
                t4.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing Trapeze: {ex.Message}");
            }

            Console.WriteLine("\nTesting incorrect string conversion:");
            try
            {
                Trapeze t5 = (Trapeze)"10,15";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }

        static public void Task2() 
        {
            Console.WriteLine("#Task_2\n");
            VectorFloat v1 = new VectorFloat(5); 
            VectorFloat v2 = new VectorFloat(3, 2.5f); 

            Console.WriteLine("Enter elements for v1:");
            v1.InputElements();

            Console.WriteLine("Vector v1:");
            v1.OutputElements();

            Console.WriteLine("Vector v2:");
            v2.OutputElements();

            Console.WriteLine("\nTesting operations:");

            VectorFloat v3 = v1 + v2;
            Console.WriteLine("v1 + v2:");
            v3.OutputElements();

            VectorFloat v4 = v1 - 1.0f;
            Console.WriteLine("v1 - 1.0f:");
            v4.OutputElements();

            VectorFloat v5 = v1 * 2.0f;
            Console.WriteLine("v1 * 2.0f:");
            v5.OutputElements();

            Console.WriteLine("\nv1 == v2? " + (v1 == v2));
            Console.WriteLine("v1 != v2? " + (v1 != v2));

            Console.WriteLine("v1 > v2? " + (v1 > v2));
            Console.WriteLine("v1 < v2? " + (v1 < v2));

            Console.WriteLine("\nTotal number of vectors created: " + VectorFloat.CountVectors());

            Console.WriteLine("\nv1[0]: " + v1[0]);
            Console.WriteLine("v1[10]: " + v1[10]);  

            v1++;
            Console.WriteLine("\nv1 after increment:");
            v1.OutputElements();

            v1--;
            Console.WriteLine("v1 after decrement:");
            v1.OutputElements();

            Console.WriteLine("\nError code (should be 0 if no errors): " + v1.CodeError);
            Console.ReadKey();
        }

    }
}
