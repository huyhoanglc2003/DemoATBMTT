using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public abstract class Key
    {
       
    }

    public class CipherPoint
    {
        public Point point1 { get; }
        public Point point2 { get; }

        public CipherPoint(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public override string ToString()
        {
            return "("+point1.ToString()+";"+point2.ToString()+")";
        }
    }


    /// <summary>
    /// Khóa bí mật
    /// </summary>
    public class PrivateKey : Key
    {
        public int KeyValue { get; set; }

        public PrivateKey(int value)
        {
            this.KeyValue = value;
        }

    }

    /// <summary>
    /// Khóa công khai
    /// </summary>
    public class PublicKey : Key {
        public Point point { get; set; }

        public PublicKey(Point point)
        {
            this.point = point;
        }

        public override string ToString()
        {
            return point.ToString();
        }
    }


    public class PublicMessage
    {
        public string Message { get; }
        public int a { get; }
        public int b { get; }
        public int p { get; }

        public PublicMessage(int a, int b , int p, string Message)
        {
            
        }

        public override string ToString()
        {
            return "{" + a + ";" + b + ";" + p + ";"+ Message +" }";
        }
    }
}
