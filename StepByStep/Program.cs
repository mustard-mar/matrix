using System;
using System.Text;

namespace StepByStep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, it is StepByStep");
            Console.WriteLine("Do you want to say your name ?(y/n)");
            string answer = Console.ReadLine();
            if (answer == "y") Hello();
            Matrix a = new Matrix(4, 4,new int[]{1,2,2,4,5,2,7,8,9,10,10,12,13,11,17,16});
            Console.WriteLine("Детерминант: " + a.det());
        }
        static void Hello() {
            Console.WriteLine("What is your name");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");
        
        }
    }
  public  class Matrix
    {
       private int[,] nums;
       private int sizeY = 0;
       private int sizeX = 0;

        public void SetValue(int y, int x, int value)
        {
            nums[y, x] = value;
        }
        public int GetValue(int y, int x)
        {
            return nums[y, x];
        }
        public int GetSizeY()
        {
            return sizeY;
        }
        public int GetSizeX()
        {
            return sizeX;
        }

        public Matrix(int sizeY, int sizeX)
        {
            nums = new int[sizeY, sizeX];
            this.sizeY = sizeY;
            this.sizeX = sizeX;
            
        }
        public Matrix(int sizeY, int sizeX, int[] num) {
            nums = new int[sizeY, sizeX];
            this.sizeY = sizeY;
            this.sizeX = sizeX;
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    nums[y, x] = num[y * sizeX + x];
                }
            }
        }
        public static Matrix Eye(int size)//влепить try catch
        {
            Matrix result = new Matrix(size, size);
            for (int i = 0; i < size; i++)
            {
                    result.SetValue(i,i,1);
            }
            return result;
        }


        public static Matrix operator -(Matrix a)
        {
            Matrix result = new Matrix(a.GetSizeY(),a.GetSizeX());
            for (int x = 0; x < a.GetSizeX(); x++)
            {
                for (int y = 0; y <a.GetSizeY(); y++)
                {
                    result.SetValue(y, x, -a.GetValue(y, x));
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.GetSizeY(), a.GetSizeX());
            for (int x = 0; x < result.GetSizeX(); x++)
            {
                for (int y = 0; y < result.GetSizeY(); y++)
                {
                    result.SetValue(y, x, a.GetValue(y, x) + b.GetValue(y, x));
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return a + (-b);
        }
        public static Matrix operator *(int numb, Matrix b)
        {
            Matrix result = new Matrix(b.GetSizeY(), b.GetSizeX());
            for (int x = 0; x < result.GetSizeX(); x++)
            {
                for (int y = 0; y < result.GetSizeY(); y++)
                {
                    result.SetValue(y, x, b.GetValue(y, x) * numb);
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix b, int numb)
        {
            Matrix result = new Matrix(b.GetSizeY(), b.GetSizeX());
            for (int x = 0; x < result.GetSizeX(); x++)
            {
                for (int y = 0; y < result.GetSizeY(); y++)
                {
                    result.SetValue(y, x, b.GetValue(y, x) * numb);
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix a, Matrix b) {
            Matrix result = new Matrix(a.GetSizeY(), b.GetSizeX());
            for (int x = 0; x < a.GetSizeY(); x++)
            {
                for (int y = 0; y < b.GetSizeX(); y++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.GetSizeX(); k++)
                    {
                        sum = sum + a.GetValue(y, k) * b.GetValue(k, x);
                    }
                    result.SetValue(y, x, sum);
                }
            }

            return result;
        }


        public Matrix Transpose()
        {
            Matrix result = new Matrix(GetSizeY(), GetSizeX());
            for (int y = 0; y < GetSizeY(); y++)
            {
                for (int x = 0; x < GetSizeX(); x++)
                {
                    result.SetValue(x, y, GetValue(y, x));
                }
            }
            return result;
        }
        public override string ToString() {
            string str = "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    sb.Append(nums[i, j]).Append(' ');
                }
                sb.Append("\n");
            }
            str = sb.ToString();
            return str;
        }
        public double det() {
            double result = 0;
            for (int j = 0; j < GetSizeX(); j++)
            {
                result = result + Math.Pow(-1, j)*nums[0,j] * minor(0,j);
            }
            return result;
        }
        public double minor(int i, int j)
        {
            Matrix MinorMatrix = new Matrix(GetSizeX() - 1, GetSizeX() - 1);
            int ya = 0;
            int xa = 0;
            for (int y = 0; y < MinorMatrix.GetSizeY(); y++)
            {
                for (int x = 0; x < MinorMatrix.GetSizeX(); x++)
                {
                    if (ya == i) ya++;
                    if (xa == j) xa++;
                    MinorMatrix.SetValue(y, x, GetValue(ya, xa));
                                        xa++;
                }
                xa = 0;
                ya++;

            }
            if (MinorMatrix.GetSizeX() == 1) return MinorMatrix.GetValue(0, 0);
            else
            if (MinorMatrix.GetSizeX() == 2) return MinorMatrix.GetValue(0, 0) * MinorMatrix.GetValue(1, 1) - MinorMatrix.GetValue(1, 0) * MinorMatrix.GetValue(0, 1);
            else return MinorMatrix.det();
        }
    
    }
}
