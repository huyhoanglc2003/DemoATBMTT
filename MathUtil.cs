using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    /// <summary>
    /// Lớp hỗ trợ xử lý thuật toán
    /// </summary>
    public class MathUtil
    {
        /// <summary>
        /// Hàm tính Mod của 2 số tự nhiên a và b
        /// </summary>
        /// <param name="a">Số bị chia</param>
        /// <param name="p">Số chia</param>
        /// <returns></returns>
        public static int Modulus(byte a, byte p)
        {

            while (a < 0)
            {
                a += p;
            }

            return Convert.ToInt32(a % p);
        }

        /// <summary>
        /// Hàm tính Mod của 2 số tự nhiên a và b
        /// </summary>
        /// <param name="a">Số bị chia</param>
        /// <param name="p">Số chia</param>
        /// <returns></returns>
        public static int Modulus(int a, int p) {

            while (a < 0)
            {
                a += p;
            }

            return a % p;
        }

        /// <summary>
        /// Hàm tính Mod của 2 số tự nhiên a và b
        /// </summary>
        /// <param name="a">Số bị chia</param>
        /// <param name="p">Số chia</param>
        /// <returns></returns>
        public static int Modulus(long a, long p)
        {
            while (a < 0)
            {
                a += p;
            }
            return Convert.ToInt32(a % p);
        }

        /// <summary>
        /// Hàm UCLN của 2 số tự nhiên a và b
        /// </summary>
        /// <param name="a">Số a</param>
        /// <param name="b">Số b</param>
        /// <returns>GCD(a,b)</returns>
        public static int GCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            return GCD(b, MathUtil.Modulus(a,b));
            
        }

        /// <summary>
        /// Hàm tính nghịch đảo của số a trên modulo p
        /// </summary>
        /// <param name="a">Số bị nghịch đảo</param>
        /// <param name="p">Modulo P</param>
        /// <returns>result = a^-1 mod p</returns>
        public static int NegativeModulus(int a, int p)
        {
            a = MathUtil.Modulus(a, p);
            int result = 1;
            while (MathUtil.Modulus((result * a), p) != 1)
            {
                result++;
                if (result >= p)
                {
                    return -1;
                };
            }
            return result;
        }

        /// <summary>
        /// Hàm tính nghịch đảo của số a trên modulo p
        /// </summary>
        /// <param name="a">Số bị nghịch đảo</param>
        /// <param name="p">Modulo P</param>
        /// <returns>result = a^-1 mod p</returns>
        public static int NegativeModulus(byte a, byte p)
        {
            a = Convert.ToByte(MathUtil.Modulus(a, p));
            int result = 1;
            while (MathUtil.Modulus((result * a), p) != 1)
            {
                result++;
                if (result >= p)
                {
                    return -1;
                };
            }
            return result;
        }

        public static bool[] ToBinary(int value)
        {
            string binaryString = Convert.ToString(value,2); // Ép kiểu từ int sang bit String

            bool[] result = new bool[binaryString.Length];

            // Ép kiểu từ bit String sang bool[]
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i].Equals('1'))
                {
                    result[i] = true;
                } else
                {
                    result[i] = false;
                }
            }
            return result;
        }

        public static bool IsPrimeNumber(int n)
        {
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    return false;
                }
                i++;
            }

            return true;
        }

        /// <summary>
        /// Hàm tính nghịch đảo của số a trên modulo p
        /// </summary>
        /// <param name="a">Số bị nghịch đảo</param>
        /// <param name="p">Modulo P</param>
        /// <returns>result = a^-1 mod p</returns>
        public static int NegativeModulus(long a, long p)
        {
            if (a == 0)
            {
                return 1;
            }

            long r0 = p;
            long r1 = a;
            long r2 = r0 % r1;

            if (r2 == 0)
            {
                return 1;
            }

            long s0 = 1, s1 = 0;
            long t0 = 0, t1 = 1;
            long q1 = r0 / r1;
            long q0 = r1 / r2;
            long step = 0;
            do {
                step++;
                r0 = r1;
                r1 = r2;
                r2 = r0 % r1;            
                if (step >= 2)
                {
                    if (step % 2 == 0)
                    {
                        s0 = s0 - s1 * q1;
                        t0 = t0 - t1 * q1;
                        q1 = r0 / r1;
                    }
                    else
                    {
                        s1 = s1 - s0 * q0;
                        t1 = t1 - t0 * q0;
                        q0 = r0 / r1;
                    }
                }
            } while (r2 != 0);

            if (step % 2 == 0)
            {
                t1 = t1 - t0 * q0;
                return Modulus(t1,p);
            } else
            {
                t0 = t0 - t1 * q1;
                return Modulus(t0, p);
            }
        }
    }
}
