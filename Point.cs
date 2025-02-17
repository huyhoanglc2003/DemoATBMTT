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

        public Point()
        {
            x = 1;
            y = 1;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }
}
