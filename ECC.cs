using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Demo
{
    public class ECC
    {                   
        private EllipticCurve curve;
        private Point basePoint;
        public PublicKey publicKey { get; }
        private PrivateKey privateKey;
        private int r_Multiply;
        public ECC(EllipticCurve curve, PrivateKey privateKey)
        {
            this.curve = curve;
            Point basePoint = Generator.GenerateCurveGPoint(curve);
            do 
            {
                basePoint = Generator.GenerateCurveGPoint(curve);
            }
            while (basePoint == null || basePoint.isInfinity);
            this.basePoint = basePoint;
            this.publicKey = new PublicKey(curve.MultiplyPoint(basePoint, privateKey.KeyValue));

            Random random = new Random();
            r_Multiply = random.Next(curve.p);
        }

        public ECC(PublicMessage publicMessage)
        {
            this.curve = new EllipticCurve(publicMessage.a, publicMessage.b, publicMessage.p);
            Point basePoint = Generator.GenerateCurveGPoint(curve);
            do
            {
                basePoint = Generator.GenerateCurveGPoint(curve);
            }
            while (basePoint == null || basePoint.isInfinity);
            this.basePoint = basePoint;
            this.publicKey = new PublicKey(curve.MultiplyPoint(basePoint, this.privateKey.KeyValue));

            Random random = new Random();
            r_Multiply = random.Next();
        }

        /// <summary>
        /// Hàm mã hóa bản rõ
        /// </summary>
        /// <param name="plainText">plainText: Bản rõ</param>
        /// <returns>cipherText: Bản mã</returns>
        public string ECCEncoding(string plainText)
        {

            Point[] pointEncode = PointConverter.StringToPoint(StandardizeMessage(plainText));         

            CipherPoint[] cipherPoints = new CipherPoint[pointEncode.Length];

            for (int i = 0; i < pointEncode.Length; i++)
            {
                cipherPoints[i] = ECCEncoding(pointEncode[i]);
            }
            string cipherText = PointConverter.CipherToString(cipherPoints);
       
            return cipherText;
        }

        public CipherPoint ECCEncoding(Point message)
        {
            Point y1 = curve.MultiplyPoint(basePoint, r_Multiply);
            Point y2 = curve.PlusPoint(message, curve.MultiplyPoint(publicKey.point, r_Multiply));
            return new CipherPoint(y1, y2);
        }

        public string ECCDecoding(string cipherText, PrivateKey privateKey)
        {
            CipherPoint[] cipherPoints = PointConverter.StringToCipher(StandardizeMessage(cipherText));
                
               
            Point[] pointEncode = new Point[cipherPoints.Length];
            for (int i = 0; i < cipherPoints.Length; i++)
            {
                pointEncode[i] = ECCDecoding(cipherPoints[i], privateKey);
            }
            string plainText = PointConverter.PointToString(pointEncode);
            
            return plainText;
        }

        public Point ECCDecoding(CipherPoint encodeMessage, PrivateKey privateKey)
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
}
