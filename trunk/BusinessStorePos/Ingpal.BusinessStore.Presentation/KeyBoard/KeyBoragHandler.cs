using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingpal.BusinessStore.Presentation.KeyBoard
{
    /// <summary>
    /// 按键委托
    /// </summary>
    /// <param name="key">按下了那个键</param>
    /// <param name="KeysString">按下的字符</param>
    public delegate void KeyPressHandler(Keys key, string KeysString);
}
