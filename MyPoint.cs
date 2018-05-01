using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0
{
    [Serializable]
    class MyPoint
    {
        private int x;
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public MyPoint(MyPoint point)
        {
            this.x = point.x;
            this.y = point.y;

        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is MyPoint)
            {
                MyPoint point = (MyPoint)obj;
                if (this.x == point.x && this.y == point.y)
                    return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return x + 1314 * y;
        }
    }
}
