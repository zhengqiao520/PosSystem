using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ingpal.BusinessStore.Presentation.KeyBoard
{
    /// <summary>
    /// 带数字键盘的下拉控件
    /// </summary>
    public class PopupNumberKeyBoardEdit : PopupContainerEdit
    {
        //下拉框容器
        private PopupContainerControl _popupContainer = new PopupContainerControl();

        /// <summary>
        /// 带数字键盘的下拉控件
        /// </summary>
        public PopupNumberKeyBoardEdit()
        {
            NumberKeyboard keyboard = new NumberKeyboard();
            keyboard.Dock = DockStyle.Fill;
            _popupContainer.Controls.Add(keyboard);
           
            this.Properties.PopupControl = _popupContainer;

           // _popupContainer.Controls.Add(new NumberKeyboard() { Name = "numberKeyboard" });
        }

        private void InitializeComponent()
        {
            
        }
    }
}
