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

        public EllipticCurve(int a, int b, int p)
        {
            this.p = p;
            if (IsEllipticCurveCoefficient(a,b)) // 4*a^3 +27b^2 !=0
            {
                this.a = a;
                this.b = b;
            }
        }

        public List<Point> GetAllPoints()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point()); // Điểm vô cực (𝒪)

            for (int x = 0; x < p; x++)
            {
                int rhs = MathUtil.Modulus(x * x * x + a * x + b, p);
                for (int y = 0; y < p; y++)
                {
                    if (MathUtil.Modulus(y * y, p) == rhs)
                    {
                        points.Add(new Point(x,y));
                    }
                }
            }
            return points;
        }

        public bool EstimatePointsByHasseTheorem(int n)
        {
            return (int)(p + 1 + 2 * Math.Sqrt(p)) < n && n < (int)(p + 1 + 2 * Math.Sqrt(p));
        }


        public int CountPointsOnCurve()
        {
            int count = 1; // Bắt đầu với điểm vô cực 𝒪
            for (int x = 0; x < p; x++)
            {
                int rhs = MathUtil.Modulus(x * x * x + a * x + b, p); // Tính x^3 + ax + b mod p
                if (MathUtil.HasSquareRoot(rhs, p))
                {
                    count += 2; // Có 2 giá trị y đối xứng (trừ khi y = 0)
                }
                else if (rhs == 0)
                {
                    count += 1; // Trường hợp đặc biệt khi y = 0
                }
            }
            return count;
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
            return MathUtil.Modulus(point.y * point.y, p) == MathUtil.Modulus(point.x * point.x * point.x + a * point.x + b, p); // y^2 = x^3 + ax + b mod p
        }

        public int GetYByX(int x)
        {
            int fx = MathUtil.Modulus(x * x * x + a * x + b, p);
            if (MathUtil.HasSquareRoot(fx, p)) return (int)Math.Sqrt(fx);
            return -1;
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
            if (pointP == null || pointP.isInfinity) return pointQ;

            if (pointQ == null || pointQ.isInfinity) return pointP;

            if (pointP.Equals(pointQ))
            {
                return DoublePoint(pointP);
            }
            else
            {
                int phi = MathUtil.Modulus((pointQ.y - pointP.y) * MathUtil.NegativeModulus((pointQ.x - pointP.x), p), p); // (yQ - yP) / (xQ - xP) mod p 
                int xr = MathUtil.Modulus(Convert.ToInt64(phi * phi - pointP.x - pointQ.x), p);
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
                result = DoublePoint(result);
                if (bitArray[i]) {
                    result = PlusPoint(result, point);
                }

                i++;
            }
            return result;
        }

        /// <summary>
        /// Hàm trả về một điểm thế hiện cho phép trừ trong đường cong Elliptic
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Point NegativePoint(Point point) {
            return new Point(point.x, MathUtil.Modulus(-point.y, p)) ;
        }
    }
}
