using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBox
{
    class Tierra
    {
        private int x, y;
        public Tierra(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void setxy(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
    }
}
