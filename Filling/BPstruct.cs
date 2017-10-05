using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    public class BorderPointStruct
    {
        public int x, y, flag;

        public BorderPointStruct()
        {
            x = 0;
            y = 0;
            flag = 0;
        }

        public BorderPointStruct(int x, int y, int flag)
        {
            this.x = x;
            this.y = y;
            this.flag = flag;
        }

        public int Compare(BorderPointStruct arg2)
        {
            BorderPointStruct arg1 = this;
            int i = arg1.y - arg2.y;
            if (i != 0)
                return ((i < 0) ? -1 : 1);
            i = arg1.x - arg2.x;
            if (i != 0)
                return ((i < 0) ? -1 : 1);

            i = arg1.flag - arg2.flag;
            return ((i < 0) ? -1 : 1);
        }
    }
}
