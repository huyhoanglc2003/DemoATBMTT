using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Demo
{
    public class ECC
    {                   
        private const int a = 1;
        private const int b = 6;
        private static int p = 9973;

        private static EllipticCurve curve = new EllipticCurve(a,b,p);

        private static Point alpha = Generator.GenerateCurveGPoint(curve);
        private static PrivateKey privateKey = new PrivateKey(5);
        private PublicKey publicKey = new PublicKey(curve.MultiplyPoint(alpha, privateKey.KeyValue));
        private byte r_Multiply = 3;



        /// <summary>
        /// Hàm mã hóa bản rõ
        /// </summary>
        /// <param name="plainText">plainText: Bản rõ</param>
        /// <returns>cipherText: Bản mã</returns>
        public string ECCEncoding(string plainText)
        {
            Console.WriteLine("=======================ENCODING==============================");


            Point[] pointEncode = PointConverter.IntToPoint(PointConverter.StringToInt(StandardizeMessage(plainText)));

            foreach (var item in pointEncode)
            {
                Console.WriteLine("Point" + item);
            }


            CipherPoint[] cipherPoints = new CipherPoint[pointEncode.Length];

            for (int i = 0; i < pointEncode.Length; i++)
            {
                cipherPoints[i] = ECCEncoding(pointEncode[i]);
            }

            foreach (var item in cipherPoints)
            {
                Console.WriteLine("Cipherpoint"+item);
            }

            string cipherText = PointConverter.IntToString(PointConverter.CipherToInt(cipherPoints));

            return cipherText;
        }

        public CipherPoint ECCEncoding(Point message)
        {
            Point y1 = curve.MultiplyPoint(alpha, r_Multiply);
            Point y2 = curve.PlusPoint(message, curve.MultiplyPoint(publicKey.point, r_Multiply));
            return new CipherPoint(y1, y2); ;
        }

        public string ECCDecoding(string cipherText, PrivateKey privateKey)
        {
            Console.WriteLine("=======================DECODING==============================");
            CipherPoint[] cipherPoints = PointConverter.IntToCipher(PointConverter.StringToInt(StandardizeMessage(cipherText)));

            foreach (var item in cipherPoints)
            {
                Console.WriteLine("Cipherpoint" + item);
            }

            Point[] pointEncode = new Point[cipherPoints.Length];

            for (int i = 0; i < cipherPoints.Length; i++)
            {
                pointEncode[i] = ECCDecoding(cipherPoints[i]);

            }

            foreach (var item in pointEncode)
            {
                Console.WriteLine("Point" + item);
            }

            string plainText = PointConverter.IntToString(PointConverter.PointToInt(pointEncode));
            return plainText;
        }

        public Point ECCDecoding(CipherPoint encodeMessage)
        {
            Point result = curve.PlusPoint(encodeMessage.point2, curve.NegativePoint(curve.MultiplyPoint(encodeMessage.point1, privateKey.KeyValue)));
            return result;
        }

        /// <summary>
        /// Chuẩn hóa chuỗi kí tự để đủ kí tự hợp lệ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string StandardizeMessage(string message)
        {

            string standardMessage;
            if (message.Length % 2 == 0)
            {
                standardMessage = message;
            }
            else
            {
                standardMessage = message + " ";
            }

            return standardMessage;
        }

    }

    public class PointConverter
    {
        /// <summary>
        /// Hàm cắt các Byte dữ liệu thành 1 mảng các điểm; 8 bytes = 1 Point
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Point[] IntToPoint(int[] data)
        {
            Point[] result = new Point[data.Length / 2];
            int resultIndex = 0;
            for (int i = 0; i < data.Length; i += 2)
            {
                result[resultIndex] = new Point(data[i], data[i+1]);
                resultIndex++;
            }
            return result;
        }

        /// <summary>
        /// Hàm cắt các Byte dữ liệu thành 1 mảng các điểm; 1 Point = 8 bytes
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int[] PointToInt(Point[] data)
        {
            int[] result = new int[data.Length * 2];
            int index = 0;
            foreach (Point point in data)
            {
                result[index] = point.x;
                result[index + 1] = point.y;
                index += 2;
            }
            return result;
        }

        public static Point[] CipherToPoint(CipherPoint[] data)
        {
            Point[] result = new Point[data.Length * 2];
            int index = 0;
            foreach (CipherPoint cipherPoint in data)
            {
                result[index] = cipherPoint.point1;
                result[index + 1] = cipherPoint.point2;
                index += 2;
            }
            return result;
        }

        public static CipherPoint[] PointToCipher(Point[] data)
        {
            CipherPoint[] result = new CipherPoint[data.Length / 2];
            int resultIndex = 0;
            for (int i = 0; i < data.Length; i += 2)
            {
                result[resultIndex] = new CipherPoint(data[i], data[i + 1]);
                resultIndex++;
            }
            return result;
        }

        public static int[] CipherToInt(CipherPoint[] data) {
            return PointToInt(CipherToPoint(data));
        }
        public static CipherPoint[] IntToCipher(int[] data)
        {
            return PointToCipher(IntToPoint(data));
        }

        public static int[] StringToInt(string text)
        {

            byte[] utf32Bytes = Encoding.UTF32.GetBytes(text);

            int[] result = new int[utf32Bytes.Length / 4];

            for (int i = 0; i < result.Length; i ++)
            {
                result[i] = BitConverter.ToInt32(utf32Bytes, i*4);
            }

            return result;
        }

        public static string IntToString(int[] data)
        {
            byte[] utf32Bytes = data.SelectMany(u => BitConverter.GetBytes(u)).ToArray();

            return Encoding.UTF32.GetString(utf32Bytes);
        }
    }
}
