

namespace Ingpal.BusinessStore.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Data;
    using System.Windows.Forms;
    using System.Drawing.Printing;
    using System.Drawing;

    public class PosPrinter
    {
        public PosPrinter()
        {

        }
        private IntPtr iHandle;
        private FileStream fs;
        private StreamWriter sw;

        private string prnPort = "LPT1";   //打印机端口

        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const int OPEN_EXISTING = 3;

        /// <summary>
        /// 打开一个vxd(设备)
        /// </summary>
        [DllImport("kernel32.dll", EntryPoint = "CreateFile", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes,
                                                int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);

        /// <summary>
        /// 开始连接打印机
        /// </summary>
        public bool PrintOpen()
        {
            iHandle = CreateFile(prnPort, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            if (iHandle.ToInt32() == -1)
            {
                MessageBox.Show("没有连接打印机或者打印机端口不是LPT1！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                fs = new FileStream(iHandle, FileAccess.ReadWrite);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);   //写数据
                return true;
            }
        }
        /// <summary>
        /// 打印字符串
        /// </summary>
        /// <param name="str">要打印的字符串</param>
        public void PrintLine(string str)
        {
            sw.WriteLine(str); ;
        }

        /// <summary>
        /// 关闭打印连接
        /// </summary>
        public void PrintEnd()
        {
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 打印票据
        /// </summary>
        /// <param name="ds">tb_Temp 全部字段数据集合</param>
        /// <returns>true：打印成功 false：打印失败</returns>
        public bool PrintDataSet(DataSet dsPrint)
        {
            try
            {
                if (PrintOpen())
                {
                    PrintLine(" ");
                    PrintLine("欢迎光临");
                    PrintLine("商品1");
                    PrintLine("商品2");
                    PrintLine("商品3");
                    ////PrintLine("NO :      " + dsPrint.Tables[0].Rows[0][1].ToString());
                    //PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][2].ToString());
                    //PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][3].ToString());
                    //PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][4].ToString());
                    //PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][5].ToString());
                    //PrintLine("操 作 员: " + dsPrint.Tables[0].Rows[0][6].ToString() + " " + dsPrint.Tables[0].Rows[0][7].ToString());
                    PrintLine("-------------------------------------------");
                }
                PrintEnd();

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// ESC/P 指令
        /// </summary>
        /// <param name="iSelect">0：退纸命令 1：进纸命令 2：换行命令</param>
        public void PrintESC(int iSelect)
        {
            string send;

            iHandle = CreateFile(prnPort, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            if (iHandle.ToInt32() == -1)
            {
                MessageBox.Show("没有连接打印机或者打印机端口不是LPT1！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fs = new FileStream(iHandle, FileAccess.ReadWrite);


                byte[] buf = new byte[80];

                switch (iSelect)
                {
                    case 0:
                        send = "" + (char)(27) + (char)(64) + (char)(27) + 'j' + (char)(255);    //退纸1 255 为半张纸长
                        send = send + (char)(27) + 'j' + (char)(125);    //退纸2
                        break;
                    case 1:
                        send = "" + (char)(27) + (char)(64) + (char)(27) + 'J' + (char)(255);    //进纸
                        break;
                    case 2:
                        send = "" + (char)(27) + (char)(64) + (char)(12);   //换行
                        break;
                    case 3:
                        send = "" + (char)(27) + 'p' + (char)(0) + (char)(60) + (char)(255);//打开钱箱
                        break;
                    // ((char)27).ToString() + "p " + ((char)0).ToString() + ((char)60).ToString() + ((char)255).ToString()
                    default:
                        send = "" + (char)(27) + (char)(64) + (char)(12);   //换行
                        break;
                }

                for (int i = 0; i < send.Length; i++)
                {
                    buf[i] = (byte)send[i];
                }

                fs.Write(buf, 0, buf.Length);
                fs.Close();
            }
        }
    }

    public class PrintTicket
    {

        //public bool PrintDoc()
        //{
        //    bool bolIsSuccess = false;
        //    PrintDocument pd = new PrintDocument();

        //    PaperSize ps = new PaperSize("Measure", 350, 650);
        //    pd.DefaultPageSettings.PaperSize = ps;
        //    pd.DefaultPageSettings.PrinterSettings.Copies = 1;
        //    pd.DefaultPageSettings.PrinterSettings.MaximumPage = 1;
        //    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        //    pd.Print();
        //    bolIsSuccess = true;
        //    return bolIsSuccess;
        //}

        //void pd_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    Font titleFont = new Font("宋体", 14, FontStyle.Bold);//标题字体 
        //    Font fntTxt = new Font("宋体", 12, FontStyle.Regular);//正文文字 
        //    Brush brush = new SolidBrush(Color.Black);//画刷 
        //    Pen pen = new Pen(Color.Black);           //线条颜色 
        //    Point poTitle = new Point(40, 200);
        //    Point poTime = new Point(70, 210);
        //    Point poTxt = new Point(20, 235);
        //    StringBuilder sb = GetPrintSW();

        //    string strTime = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日   " + DateTime.Now.ToString("HH:mm:ss");
        //    try
        //    {
        //        e.Graphics.DrawString("\r\n\r\n\r\n\r\n\r\n\r\nXXXXXXX计量单", fntTxt, new SolidBrush(Color.White), new Point(45, 100));
        //        e.Graphics.DrawString("\r\n\r\n\r\n\r\n\r\n\r\nXXXXXXXX计量单", fntTxt, brush, poTitle);
        //        e.Graphics.DrawString("\r\n\r\n\r\n\r\n\r\n\r\n\r\n" + strTime, fntTxt, brush, poTime);
        //        e.Graphics.DrawString(sb.ToString(), fntTxt, brush, poTxt);   //DrawString方式进行打印。 

        //        if (dt.Rows.Count > 0)
        //        {
        //            string strMeaDocId = dt.Rows[0]["C_MeasureDocID"].ToString() ?? "";
        //            if (!string.IsNullOrEmpty(strMeaDocId))
        //            {
        //                barcodeControl.Data = strMeaDocId;
        //            }
        //        }
        //        barcodeControl.CopyRight = "";
        //        BarcodeType bt = BarcodeType.CODE39;
        //        barcodeControl.BarcodeType = bt;
        //        Graphics g = e.Graphics;
        //        Rectangle rect = barcodeControl.ClientRectangle;
        //        rect = new Rectangle(90, 550, 230, 50);
        //        //打印
        //        barcodeControl.Draw(g, rect, GraphicsUnit.Inch, 0.01f, 0, null);
        //        g.Dispose();

        //    }
        //    catch (Exception ex)
        //    {
        //        //SaveLog.SaveErrLog("打印小票出错：" + ex.Message);
        //        return;
        //    }
        //}



        public void Print() {
            //打印预览            

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(20, 20, 20, 20);
            pd.DefaultPageSettings.Margins = margin;
            ////纸张设置默认
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 600);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            pd.PrintPage += Pd_PrintPage;
            ppd.Document = pd;
            ppd.ShowDialog();
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
            }

        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            string strFile = GetPrintStr();
            Font ft = new Font("宋体", 8.5F, FontStyle.Regular);
            Point pt = new Point(0, 0);
            g.DrawString(strFile, ft, new SolidBrush(Color.Black), pt);
        }

        private int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }
        public string GetPrintStr()
        {

            StringBuilder sb = new StringBuilder();
            string tou = "葡缇文化收银系统";
            string address = "上海市浦东新区杨高南路";
            string saleID = "2010930233330";
            string item = "项目";
            decimal price = 25.00M;
            int count = 5;
            decimal total = 0.00M;
            decimal fukuan = 500.00M;
            sb.Append("            " + tou + "     /n");
            sb.Append("-----------------------------------------------------------------/n");
            sb.Append("日期:" + DateTime.Now.ToShortDateString() + "  " + "单号:" + saleID + "/n");
            sb.Append("-----------------------------------------------------------------/n");
            sb.Append("项目" + "/t/t" + "数量" + "/t" + "单价" + "/t" + "小计" + "/n");
            for (int i = 0; i < count; i++)
            {
                decimal xiaoji = (i + 1) * price;
                sb.Append(item + (i + 1) + "/t/t" + (i + 1) + "/t" + price + "/t" + xiaoji);
                total += xiaoji;
                if (i != (count))

                    sb.Append("/n");
            }
            sb.Append("-----------------------------------------------------------------/n");
            sb.Append("数量: " + count + " 合计:   " + total + "/n");
            sb.Append("付款: 现金" + "    " + fukuan);
            sb.Append("         现金找零:" + "   " + (fukuan - total) + "/n");
            sb.Append("-----------------------------------------------------------------/n");
            sb.Append("地址：" + address + "/n");
            sb.Append("电话：123456789   123456789/n");
            sb.Append("                 谢谢惠顾欢迎下次光临                    ");
            return sb.ToString();
        }
    }
        
}

