using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Ingpal.BusinessStore.Model.Print;
using System.IO;
using System.Net;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Presentation.Common;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class CustomerInfo : Panel
    {
        private System.Data.DataSet posResultSet = null;
        private PosCustom posInfo;
        private List<MDMTypeSubEntity> MDMSubList = MdmBLL.Instance.MDMSubList;

        public CustomerInfo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.FromArgb(100, 150, 150, 150);
            Messager<PosCustom>.OnDataChanged += Messager_OnDataChanged;
        }

        private void Messager_OnDataChanged(PosCustom model, string msgCode)
        {
            posInfo = model;
            this.Refresh();
        }

        private void Messager_OnDataChanged(DataSet dataset, string msgCode)
        {
            posResultSet = dataset;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (posInfo != null)
            {
                var g = e.Graphics;
                this.DrawProductInfo(g);
                g.Dispose();
            }
            else
            {
                base.OnPaint(e);
            }
        }

        private void DrawProductInfo(Graphics g)
        {
            var posEntity = posInfo;
            var posDetailEntity = posInfo.PosDetail;
            //var ticketProperties = MdmBLL.Instance.GetMDMByNameOrCode(new MDMEntity() { MDMName = "TiketProperties" });
            var ticketProperties = MDMSubList.Where(item => item.MDMTypeName == "小票属性");
            if (ticketProperties != null && ticketProperties.Count() == 5)
            {


            }


            var height = this.DrawTiketTableRow(20, g, new PrintRow()
            {
                Cells = new List<PrintCell> {
                    new PrintCell() { Index=0, Percent=38, Text="商品名称"  },
                    new PrintCell() { Index=0, Percent=19, Text="数量"  },
                    new PrintCell() { Index=0, Percent=19, Text="单价"  },
                    new PrintCell() { Index=0, Percent=22, Text="小计"  },
                },
                RowFont = new Font("微软雅黑", 15)

            });
            height = this.DrawTicketLine(height, g, false);  //绘制虚线

            foreach (var item in posDetailEntity)
            {
                height = this.DrawTiketTableRow(height, g, new PrintRow()
                {
                    Cells = new List<PrintCell> {
                    new PrintCell() { Index=0, Percent=38, Text=item.GoodsName  },
                    new PrintCell() { Index=0, Percent=19, Text=item.GoodsCount.ToString() },
                    new PrintCell() { Index=0, Percent=19, Text=item.RetailPrice.ToString("0.00")  },
                    new PrintCell() { Index=0, Percent=22, Text=item.GoodsAmount.ToString("0.00")  },
                    },
                    RowFont = new Font("微软雅黑", 15)
                });
            }
            int totalCount = posEntity.TotalCount;
            decimal totalAmount = posEntity.TotalAmount;
            height = this.DrawTicketLine(height, g, false);  //绘制虚线
            height = this.DrawTicketItem(height, g, string.Format("合计数量:{0:0.00}",posEntity.TotalCount),new Font("微软雅黑",15F), StringAlignment.Far);
            height = this.DrawTicketItem(height, g, string.Format("合计金额:{0:0.00}",posEntity.TotalAmount),new Font("微软雅黑",15F, FontStyle.Bold),StringAlignment.Far);




            //return height;

        }


        /// <summary>
        /// 绘制小票图片
        /// </summary>
        /// <param name="pixY"></param>
        /// <param name="g"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private int DrawTicketImage(int pixY, Graphics g, string url = "")
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (this.HttpDownload(url, "\\Images\\QRCode.png"))
                {
                    var image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\QRCode.png");
                    var width = image.Width;
                    var height = image.Height;
                    var pixX = this.Width / 2; //取得打印文档宽度的中间点
                    pixX = pixX - (width / 2); //图片宽度的一半

                    g.DrawImage(image, new PointF(pixX, pixY));

                    return pixY + height + 2;
                }
                else
                {
                    return pixY;
                }
            }
            else
            {
                return pixY;
            }


        }

        /// <summary>
        /// 绘制小票标题
        /// </summary>
        /// <param name="title">标题内容</param>
        /// <param name="g">画板</param>
        private int DrawTicketTitle(string title, Graphics g)
        {
            //定义字体大小
            int fontSize = 12;
            //定义文字的对齐方式
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Font fontTitle = new Font("宋体", fontSize, FontStyle.Regular);
            g.DrawString(title + "\r\n", fontTitle, new SolidBrush(Color.Black), new Rectangle(0, 10, this.Width, 20), sf);

            var size = GetFontSize(title, fontSize, FontStyle.Regular);
            return Convert.ToInt32(fontTitle.GetHeight()) + 10;
        }

        /// <summary>
        /// 绘制线段
        /// </summary>
        /// <param name="pixY">位置</param>
        /// <param name="g">画板</param>
        /// <param name="drawdash">是否画虚线</param>
        private int DrawTicketLine(int pixY, Graphics g, bool drawdash)
        {
            if (drawdash)
            {
                Pen pen = new Pen(Color.Black, 1);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                pen.DashPattern = new float[] { 5, 5 };
                g.DrawLine(pen, 0, pixY, this.Width, pixY);
            }
            else
            {
                g.DrawLine(Pens.Black, 0, pixY, this.Width, pixY);
            }

            return pixY + 2;
        }

        /// <summary>
        /// 绘制小票的普通文字
        /// </summary>
        /// <param name="pixY">高度</param>
        /// <param name="g">画板</param>
        /// <returns></returns>
        private int DrawTicketItem(int pixY, Graphics g, string itemString, Font textFont = null, StringAlignment textAlign= StringAlignment.Near)
        {
            if (textFont == null)
            {
                //定义字体大小
                float fontSize = 6.5F;
                textFont = new Font("宋体", fontSize, FontStyle.Regular);
            }

            //定义文字的对齐方式
            StringFormat sf = new StringFormat();
            sf.Alignment = textAlign;

            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(itemString, textFont, new SolidBrush(Color.Black), new Rectangle(1, pixY, this.Width, Convert.ToInt32(textFont.GetHeight())+10), sf);

            return pixY + Convert.ToInt32(textFont.GetHeight()+10);
        }

        /// <summary>
        /// 绘制一行表格
        /// </summary>
        /// <param name="pixel_Y">起始高度</param>
        /// <param name="g">画板</param>
        /// <param name="row">表格数据</param>
        /// <returns></returns>
        private int DrawTiketTableRow(int pixel_Y, Graphics g, PrintRow row)
        {
            if (null != row)
            {
                //定义字体大小
                // float fontSize = 6.5F;
                //定义文字的对齐方式
                StringFormat sf = new StringFormat();
                if (row.TextAlign == 1)
                {
                    sf.Alignment = StringAlignment.Center;
                }
                else if (row.TextAlign == 0)
                {
                    sf.Alignment = StringAlignment.Near;
                }
                else
                {
                    sf.Alignment = StringAlignment.Far;
                }
                sf.LineAlignment = StringAlignment.Center;


                var cells = row.Cells.OrderBy(q => q.Index);
                var page_width = this.Width;
                var rect_x = 1;

                foreach (var item in cells)
                {
                    var rectWidth = Convert.ToInt32(Math.Ceiling(page_width * (item.Percent / 100.0)));
                    g.DrawString(item.Text, row.RowFont, new SolidBrush(Color.Black), new Rectangle(rect_x, pixel_Y, rectWidth, Convert.ToInt32(row.RowFont.GetHeight())), sf);
                    rect_x += rectWidth;
                }

                pixel_Y += Convert.ToInt32(row.RowFont.GetHeight()) + 10;

            }
            return pixel_Y;
        }

        /// <summary>
        /// 获取文字所占的大小
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontSize"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        private SizeF GetFontSize(string text, float fontSize, FontStyle style)
        {
            Graphics vGraphics = this.CreateGraphics();
            SizeF vSizeF = vGraphics.MeasureString(text, new Font("宋体", fontSize, style));
            int dStrLength = Convert.ToInt32(Math.Ceiling(vSizeF.Width)) + 2;
            return vSizeF;
        }

        private int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public bool HttpDownload(string url, string path)
        {

            string tempFile = AppDomain.CurrentDomain.BaseDirectory + path; //临时文件

            if (System.IO.File.Exists(tempFile))
            {
                return true;
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                // System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
