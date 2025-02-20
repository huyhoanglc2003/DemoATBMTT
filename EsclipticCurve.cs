using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    /// <summary>
    /// Đường cong Elliptic
    /// </summary>
    public class EllipticCurve
    {
        private int a;
        private int b;
        public int p { get; set; }


        public EllipticCurve()
        {
            Random random = new Random();
            this.a = random.Next(256);
            do
            {
                this.b = random.Next(256);
            } while (!IsEllipticCurveCoefficient());

            this.p = Generator.GeneratePrimeNumber(127,257);
        }

        public EllipticCurve(Point point, int p)
        {
            this.p = p;
            if (IsEllipticCurveCoefficient()) // 4*a^3 +27b^2 !=0
            {
                this.a = point.x;
                this.b = point.y;
            }
        }

        public EllipticCurve(int a, int b, int p)
        {
            this.p = p;
            if (IsEllipticCurveCoefficient()) // 4*a^3 +27b^2 !=0
            {
                
            }

            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Điều kiện của hệ số 
        /// </summary>
        /// <returns>4*a^3 +27b^2 !=0</returns>
        private bool IsEllipticCurveCoefficient() {
            return 4 * Math.Pow(a, 3) + 27 * Math.Pow(b, 2) != 0;
        }


        /// <summary>
        /// Điều kiện của hệ số 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>4*a^3 +27b^2 !=0</returns>
        public bool IsEllipticCurveCoefficient(int a, int b)
        {
            return 4 * Math.Pow(a, 3) + 27 * Math.Pow(b, 2) != 0;
        }

        /// <summary>
        /// Hàm xác định điểm có thuộc đường cong Elliptic trong hệ tọa độ (x,y) hay không
        /// </summary>
        /// <param name="point">Điểm thuộc đường cong</param>
        /// <returns></returns>
        public bool IsEllipticCurvePoint(Point point)
        {
            if (Math.Pow(point.y, 2) == MathUtil.Modulus(Convert.ToInt64((Math.Pow(point.x, 3) + a * point.x + b)), p)) // y^2 = x^3 + ax + b mod p
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Hàm xác định điểm có thuộc đường cong Elliptic trong hệ tọa độ (x,y) hay không
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsEllipticCurvePoint(int x, int y)
        {
            if (Math.Pow(y, 2) == MathUtil.Modulus(Convert.ToInt64((Math.Pow(x, 3) + a * x + b)), p)) // y^2 = x^3 + ax + b mod p
            {
                return true;
            }
            return false;

        }

        public int GetYByX(int x)
        {
            return (int) Math.Sqrt(MathUtil.Modulus(Convert.ToInt64((Math.Pow(x, 3) + a * x + b)), p));
        }


        /// <summary>
        /// Hàm cộng 2 điểm P và Q thuộc đường cong Elliptic trong hệ tọa độ (x,y) /n
        /// P!= Q.
        /// </summary>
        /// <param name="pointP">P(xP,yP): Điểm thứ nhất thuộc đường cong Elliptic</param>
        /// <param name="pointQ">Q(xQ, yQ): Điểm thứ hai thuộc đường cong Elliptic</param>
        /// <returns>Điểm R(xr,yr) = P(xP,yP) + Q(xQ, yQ)</returns>
        public Point PlusPoint(Point pointP, Point pointQ)
        {
            if (pointP.x == pointQ.x)
            {
                return DoublePoint(pointP);
            }
            else
            {
                int phi = MathUtil.Modulus((pointQ.y - pointP.y) * MathUtil.NegativeModulus((pointQ.x - pointP.x), p), p); // (yQ - yP) / (xQ - xP) mod p 
                int xr = MathUtil.Modulus(Convert.ToInt64(Math.Pow(phi, 2) - pointP.x - pointQ.x), p);
                int yr = MathUtil.Modulus((phi * (pointP.x - xr) - pointP.y), p);
                return new Point(xr, yr);
            }
        }

        /// <summary>
        /// Hàm nhân đôi điểm thuộc đường cong Elliptic trong hệ tọa độ (x,y) 
        /// </summary>
        /// <param name="pointP">P(xP,yP): Điểm được nhân đôi</param>
        /// <returns>Điểm R(xr,yr) = P(xP,yP) + P(xP,yP) = 2 * P(xP,yP)</returns>
        public Point DoublePoint(Point pointP)
        {        
            int phi = MathUtil.Modulus((3 * Convert.ToInt64(Math.Pow(pointP.x, 2)) + a) * MathUtil.NegativeModulus(2 * pointP.y, p), p);
            int xr = MathUtil.Modulus((Convert.ToInt64(Math.Pow(phi, 2)) - 2 * pointP.x), p);
            int yr = MathUtil.Modulus((phi * (pointP.x - xr) - pointP.y), Convert.ToInt64(p));
            return new Point(xr, yr);
        }

        /// <summary>
        /// Hàm nhân hệ số với điểm thuộc đường cong Elliptic trong hệ tọa độ (x,y) 
        /// </summary>
        /// <param name="point">P(xP,yP): Điểm được nhân với hệ số</param>
        /// <param name="count">count: Hệ số</param>
        /// <returns>result = Điểm (xP,yP) := count*P(xP,yP)</returns>
        public Point MultiplyPoint(Point point, int count)
        {

            bool[] bitArray = MathUtil.ToBinary(count);

            Point result = point;
            int i = 1;
            while (i < bitArray.Length) {
/*               Console.WriteLine("Step:" + i + " = " + bitArray[i]);*/
                result = DoublePoint(result);
                if (bitArray[i]) {
                    result = PlusPoint(result, point);
                }

                i++;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Point NegativePoint(Point point) {
            return new Point(point.x, MathUtil.Modulus(-point.y, p)) ;
        }
    }
}
