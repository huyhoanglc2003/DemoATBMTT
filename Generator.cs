using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{

    /// <summary>
    /// Lớp sinh điểm
    /// </summary>
    public class Generator
    {
        public static Point GenerateCurveGPoint(EllipticCurve curve)
        {
            int x = GeneratePrimeNumber(2, curve.p-1);

            int y = curve.GetYByX(x);

            if (y >= 0)
            {
                return new Point(x, y);
            }

            return new Point();
        }

        public static int GeneratePrimeNumber(int min, int max)
        {
            Random rnd = new Random();

            int n = rnd.Next(min,max);
            while (!MathUtil.IsPrimeNumber(n))
            {
                n = rnd.Next(min,max);
            }
            return n;
        }

        public static int GeneratePrimeX(int min, int max)
        {
            int[] primeValue = new int[max];
            int tmp = min;
            int i = 0;
            while (i < max)
            {
                if (MathUtil.IsPrimeNumber(tmp))
                {
                    primeValue[i] = tmp;
                    i++;
                }
            }
            Random random = new Random();
            primeValue.CopyTo(primeValue, 0);
            tmp = primeValue[random.Next(primeValue.Length)];
            return tmp;
        }
    }
}
