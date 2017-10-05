using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    public class MyComparer : IEqualityComparer<BorderPointStruct>
    {
        public bool Equals(BorderPointStruct x1, BorderPointStruct x2)
        {
            return (x1.x == x2.x) && (x1.y == x2.y) && (x1.flag == x2.flag);
        }

        public int GetHashCode(BorderPointStruct obj)
        {
            return obj.x ^ obj.y ^ obj.flag;
        }

    }
}
