using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
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
                result[resultIndex] = new Point(data[i], data[i + 1]);
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

        public static int[] CipherToInt(CipherPoint[] data)
        {
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

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = BitConverter.ToInt32(utf32Bytes, i * 4);
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
