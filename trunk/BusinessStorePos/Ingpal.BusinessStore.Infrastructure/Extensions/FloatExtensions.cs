using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Infrastructure
{
    public static class FloatExtensions
    {
        public static float ToAbsolute(this float value)
        {
            var res = value;
            if (value < 0)
            {
                res = -value;
            }

            return res;
        }
    }
}
