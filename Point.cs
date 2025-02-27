using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{

    /// <summary>
    /// Điểm trong hệ tọa độ (x,y)
    /// </summary>
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public bool isInfinity;
        public Point()
        {
            isInfinity = true;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            isInfinity = false;
        }
        public override bool Equals(object obj)
        {
            Point point = obj as Point;
            if (point != null) { 
                if (x == point.x && y == point.y) return true;
            } 
            return false;
        }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }

        public override int GetHashCode()
        {
            int hashCode = 1313472948;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + isInfinity.GetHashCode();
            return hashCode;
        }
    }
}
