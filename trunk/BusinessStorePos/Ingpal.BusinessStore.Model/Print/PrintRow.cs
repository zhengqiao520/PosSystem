using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model.Print
{
    /// <summary>
    /// PrintRow
    /// </summary>
    public class PrintRow
    {
        private Font _rowFont = new Font("宋体", 9F, FontStyle.Regular);
        private int _textAlign = 0;

        /// <summary>
        /// 表格
        /// </summary>
        public List<PrintCell> Cells { get; set; }

        /// <summary>
        /// 字体
        /// </summary>
        public Font RowFont
        {
            get
            {
                return _rowFont;
            }
            set
            {
                _rowFont = value;
            }
        }

        /// <summary>
        /// 文本对齐方式 0-左对齐 1-居中 2-右对齐 
        /// </summary>
        public int TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                _textAlign = 0;
            }
        }

    }

    /// <summary>
    /// PrintCell
    /// </summary>
    public class PrintCell
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 在显示行中所占的百分比
        /// </summary>
        public int Percent { get; set; }

        /// <summary>
        /// 单元格中的文本
        /// </summary>
        public string Text { get; set; }
    }
}
