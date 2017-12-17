
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Drawing.Printing;

using System.Runtime.InteropServices;

namespace Ingpal.BusinessStore.Presentation
{
    /// <summary>
    /// 获取本地打印机列表
    /// </summary>
    public class LocalPrinter
    {

        private static PrintDocument fPrintDocument = new PrintDocument();

        
        /// <summary>
        /// 获取默认打印机名称
        /// </summary>
        /// <returns></returns>
        public static String DefaultPrinter()
        {
            return fPrintDocument.PrinterSettings.PrinterName;
        }

        /// <summary>
        /// 获取本地打印机列表
        /// </summary>
        /// <returns></returns>
        public static List<dynamic> GetLocalPrinters()
        {
            List<dynamic> fPrinters = new List<dynamic>();
            fPrinters.Add(new { Name = DefaultPrinter() }); //默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (fPrinters.SingleOrDefault(q=>q.Name==fPrinterName)==null)
                {
                    fPrinters.Add(new { Name = fPrinterName });
                }
            }
            return fPrinters;
        }
    }

    /// <summary>
    /// 设置打印机为默认打印机
    /// </summary>
    public class Externs
    {
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name); //调用win api将指定名称的打印机设置为默认打印机

    }
}