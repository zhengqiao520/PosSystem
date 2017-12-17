using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{

    [Flags]
    public enum AnimationType
    {
        AW_HOR_POSITIVE = 0x0001,//从左向右显示
        AW_HOR_NEGATIVE = 0x0002,//从右向左显示
        AW_VER_POSITIVE = 0x0004,//从上到下显示
        AW_VER_NEGATIVE = 0x0008,//从下到上显示
        AW_CENTER = 0x0010,//从中间向四周
        AW_HIDE = 0x10000,
        AW_ACTIVATE = 0x20000,//普通显示
        AW_SLIDE = 0x40000,
        AW_BLEND = 0x80000,//透明渐变显示效果
    }
}
