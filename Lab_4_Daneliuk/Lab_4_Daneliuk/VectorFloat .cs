using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Daneliuk
{
    class VectorFloat
    {
        protected float[] FArray;
        protected uint num;
        protected int codeError;
        protected static uint num_vec;

        public VectorFloat()
        {
            FArray = new float[1];
            num = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorFloat(uint size)
        {
            FArray = new float[size];
            num = size;
            codeError = 0;
            num_vec++;
        }

        public VectorFloat(uint size, float initValue)
        {
            FArray = new float[size];
            num = size;
            codeError = 0;
            for (int i = 0; i < size; i++)
                FArray[i] = initValue;
            num_vec++;
        }

        ~VectorFloat()
        {
            Console.WriteLine("Vector is being destroyed.");
        }

        public void InputElements()
        {
            Console.WriteLine("Enter elements of the vector:");
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Element {i}: ");
                FArray[i] = float.Parse(Console.ReadLine());
            }
        }

        public void OutputElements()
        {
            Console.WriteLine("Vector elements:");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(FArray[i]);
            }
        }

        public void SetElements(float value)
        {
            for (int i = 0; i < num; i++)
            {
                FArray[i] = value;
            }
        }

        public static uint CountVectors()
        {
            return num_vec;
        }

        public uint Size
        {
            get { return num; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= num)
                {
                    codeError = -1;
                    return 0;
                }
                return FArray[index];
            }
            set
            {
                if (index < 0 || index >= num)
                {
                    codeError = -1;
                }
                else
                {
                    FArray[index] = value;
                }
            }
        }


        public static VectorFloat operator ++(VectorFloat v)
        {
            for (int i = 0; i < v.num; i++)
            {
                v.FArray[i]++;
            }
            return v;
        }

        public static VectorFloat operator --(VectorFloat v)
        {
            for (int i = 0; i < v.num; i++)
            {
                v.FArray[i]--;
            }
            return v;
        }

        public static VectorFloat operator +(VectorFloat v1, VectorFloat v2)
        {
            uint size = Math.Max(v1.num, v2.num);
            VectorFloat result = new VectorFloat(size);

            for (int i = 0; i < size; i++)
            {
                if (i < v1.num && i < v2.num)
                {
                    result.FArray[i] = v1.FArray[i] + v2.FArray[i];
                }
                else if (i < v1.num)
                {
                    result.FArray[i] = v1.FArray[i];
                }
                else
                {
                    result.FArray[i] = v2.FArray[i];
                }
            }

            return result;
        }

        public static VectorFloat operator +(VectorFloat v, float scalar)
        {
            VectorFloat result = new VectorFloat(v.num);
            for (int i = 0; i < v.num; i++)
            {
                result.FArray[i] = v.FArray[i] + scalar;
            }
            return result;
        }

        public static VectorFloat operator -(VectorFloat v1, VectorFloat v2)
        {
            uint size = Math.Max(v1.num, v2.num);
            VectorFloat result = new VectorFloat(size);

            for (int i = 0; i < size; i++)
            {
                if (i < v1.num && i < v2.num)
                {
                    result.FArray[i] = v1.FArray[i] - v2.FArray[i];
                }
                else if (i < v1.num)
                {
                    result.FArray[i] = v1.FArray[i];
                }
                else
                {
                    result.FArray[i] = -v2.FArray[i];
                }
            }

            return result;
        }

        public static VectorFloat operator -(VectorFloat v, float scalar)
        {
            VectorFloat result = new VectorFloat(v.num);
            for (int i = 0; i < v.num; i++)
            {
                result.FArray[i] = v.FArray[i] - scalar;
            }
            return result;
        }

        public static VectorFloat operator *(VectorFloat v1, VectorFloat v2)
        {
            uint size = Math.Max(v1.num, v2.num);
            VectorFloat result = new VectorFloat(size);

            for (int i = 0; i < size; i++)
            {
                if (i < v1.num && i < v2.num)
                {
                    result.FArray[i] = v1.FArray[i] * v2.FArray[i];
                }
                else if (i < v1.num)
                {
                    result.FArray[i] = v1.FArray[i];
                }
                else
                {
                    result.FArray[i] = v2.FArray[i];
                }
            }

            return result;
        }

        public static VectorFloat operator *(VectorFloat v, float scalar)
        {
            VectorFloat result = new VectorFloat(v.num);
            for (int i = 0; i < v.num; i++)
            {
                result.FArray[i] = v.FArray[i] * scalar;
            }
            return result;
        }

        public static bool operator ==(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num) return false;

            for (int i = 0; i < v1.num; i++)
            {
                if (v1.FArray[i] != v2.FArray[i]) return false;
            }
            return true;
        }

        public static bool operator !=(VectorFloat v1, VectorFloat v2)
        {
            return !(v1 == v2);
        }

        public static bool operator >(VectorFloat v1, VectorFloat v2)
        {
            for (int i = 0; i < Math.Min(v1.num, v2.num); i++)
            {
                if (v1.FArray[i] <= v2.FArray[i]) return false;
            }
            return true;
        }

        public static bool operator >=(VectorFloat v1, VectorFloat v2)
        {
            for (int i = 0; i < Math.Min(v1.num, v2.num); i++)
            {
                if (v1.FArray[i] < v2.FArray[i]) return false;
            }
            return true;
        }

        public static bool operator <(VectorFloat v1, VectorFloat v2)
        {
            for (int i = 0; i < Math.Min(v1.num, v2.num); i++)
            {
                if (v1.FArray[i] >= v2.FArray[i]) return false;
            }
            return true;
        }

        public static bool operator <=(VectorFloat v1, VectorFloat v2)
        {
            for (int i = 0; i < Math.Min(v1.num, v2.num); i++)
            {
                if (v1.FArray[i] > v2.FArray[i]) return false;
            }
            return true;
        }

    }
}
