using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Ingpal.BusinessStore.Model;
using System.Reflection;
using NPOI.HSSF.Util;

namespace Ingpal.BusinessStore.Infrastructure
{
    public class ExcelHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private ExcelHelper()
        {
        }

        #region Const Variables

        /// <summary>
        /// Excel 版本号
        /// </summary>
        private const string ExcelDefaultVersion = "8.0";

        /// <summary>
        /// 连接字符串模板
        /// </summary>
        private const string ConnectionStringTemplate = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source ={0};Extended Properties='Excel {1};HDR=YES;IMEX=1'";//HDR=YES;IMEX=1
        #endregion


        #region Public Methods
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <returns></returns>
        internal static OleDbConnection CreateConnection(string excelPath)
        {
            return CreateConnection(excelPath, ExcelDefaultVersion);
        }

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="excelVersion">Excel版本号。默认为 8.0</param>
        /// <returns></returns>
        internal static OleDbConnection CreateConnection(string excelPath, string excelVersion)
        {
            return new OleDbConnection(GetConnectionString(excelPath, excelVersion));
        }
        #region me扩展
        public static DataTable ReadExcelToDataTableForFirstDateTime(HttpPostedFile httpPostedFileBase, string sheetname)
        {
            Stream MyStream;
            int FileLen;
            FileLen = httpPostedFileBase.ContentLength;
            // 读取文件的 byte[]   
            //byte[] bytes = new byte[FileLen];
            MyStream = httpPostedFileBase.InputStream;
            //MyStream.Read(bytes, 0, FileLen);
            IWorkbook workbook;
            if (httpPostedFileBase.FileName.Contains(".xlsx"))
            {
                workbook = new XSSFWorkbook(MyStream);
            }
            else
            {
                workbook = new HSSFWorkbook(MyStream);
            }
            //获取excel的第一个sheet
            ISheet sheet = null;
            if (!string.IsNullOrEmpty(sheetname))
                sheet = workbook.GetSheet(sheetname);
            else
                sheet = workbook.GetSheetAt(0);

            DataTable table = new DataTable();
            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);

            //一行最后一个方格的编号 即总的列数
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row != null)
                {
                    DataRow dataRow = table.NewRow();
                    string RowString = "";
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (j == 0)
                            {
                                try
                                {
                                    dataRow[j] = row.GetCell(j).DateCellValue.ToString();
                                    RowString += dataRow[j];
                                }
                                catch (Exception ex)
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                    RowString += row.GetCell(j).ToString();
                                }
                            }
                            else
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                                RowString += row.GetCell(j).ToString();
                            }

                        }
                    }

                    if (!string.IsNullOrEmpty(RowString))
                        table.Rows.Add(dataRow);
                }
            }

            workbook = null;
            sheet = null;
            MyStream.Close();
            return table;
        }

        public static DataTable ReadExcelToDataTable(HttpPostedFile httpPostedFileBase, string sheetname)
        {
            Stream MyStream;
            int FileLen;
            FileLen = httpPostedFileBase.ContentLength;
            // 读取文件的 byte[]   
            //byte[] bytes = new byte[FileLen];
            MyStream = httpPostedFileBase.InputStream;
            //MyStream.Read(bytes, 0, FileLen);
            IWorkbook workbook;
            if (httpPostedFileBase.FileName.Contains(".xlsx"))
            {
                workbook = new XSSFWorkbook(MyStream);
            }
            else
            {
                workbook = new HSSFWorkbook(MyStream);
            }
            //获取excel的第一个sheet
            ISheet sheet = null;
            if (!string.IsNullOrEmpty(sheetname))
                sheet = workbook.GetSheet(sheetname);
            else
                sheet = workbook.GetSheetAt(0);

            DataTable table = new DataTable();
            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);

            //一行最后一个方格的编号 即总的列数
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //数据总条数
            {
                IRow row = sheet.GetRow(i);

                if (row != null)
                {
                    DataRow dataRow = table.NewRow();
                    string RowString = "";

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (j == 0)
                            {
                                dataRow[j] = row.GetCell(j).DateCellValue.ToString();
                                RowString += dataRow[j];
                            }
                            else
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                                RowString += row.GetCell(j).ToString();
                            }

                        }
                    }

                    if (!string.IsNullOrEmpty(RowString))
                        table.Rows.Add(dataRow);
                }
            }

            workbook = null;
            sheet = null;
            MyStream.Close();
            return table;
        }


 


        #endregion


        public static IList<IList<string>> ReadExcelData(HttpPostedFile httpPostedFileBase)
        {
            IList<IList<string>> list = new List<IList<string>>();
            string path = SaveFile(httpPostedFileBase);
            return list;
        }

        public static IList<IList<string>> ReadData(HttpPostedFile httpPostedFileBase)
        {
            IList<IList<string>> list = new List<IList<string>>();
            string path = string.Empty;
            //try
            //{
            //path = SaveFile(httpPostedFileBase);
            //DataTable dt = Query(path);

            DataTable dt = ReadExcelToDataTableForFirstDateTime(httpPostedFileBase, string.Empty);

            if (dt == null || dt.Rows.Count == 0) return list;
            IList<string> titleList = new List<string>();
            var colLength = dt.Columns.Count;
            foreach (DataColumn dc in dt.Columns)
            {
                titleList.Add(dc.ColumnName);
            }
            list.Add(titleList);
            var columCount = dt.Columns.Count;
            foreach (DataRow dr in dt.Rows)
            {
                IList<string> colList = new List<string>();
                for (int i = 0; i < columCount; i++)
                {
                    colList.Add(dr[i].ToString().Trim());
                }
                list.Add(colList);
            }
            //}
            //catch
            //{

            //}
            //finally
            //{
            //File.Delete(path);
            //}
            return list;
        }

        public static IList<IList<string>> ReadFilterEmptyData(HttpPostedFile httpPostedFileBase, string sheetName)
        {
            IList<IList<string>> list = new List<IList<string>>();
            string path = string.Empty;
            try
            {
                //path = SaveFile(httpPostedFileBase);
                //DataTable dt = QueryFilterEmpty(path, sheetName);

                DataTable dt = ReadExcelToDataTable(httpPostedFileBase, sheetName);

                if (dt == null || dt.Rows.Count == 0) return list;
                IList<string> titleList = new List<string>();
                var colLength = dt.Columns.Count;
                foreach (DataColumn dc in dt.Columns)
                {
                    titleList.Add(dc.ColumnName);
                }
                list.Add(titleList);
                var columCount = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    IList<string> colList = new List<string>();
                    for (int i = 0; i < columCount; i++)
                    {
                        colList.Add(dr[i].ToString().Trim());
                    }
                    list.Add(colList);
                }
            }
            catch
            {

            }
            finally
            {
                //File.Delete(path);
            }
            return list;
        }
        public static IList<IList<string>> ReadFilterEmptyData(HttpPostedFile httpPostedFileBase, string sheetName, string fieldName)
        {
            IList<IList<string>> list = new List<IList<string>>();
            string path = string.Empty;
            try
            {
                path = SaveFile(httpPostedFileBase);
                DataTable dt = QueryFilterEmpty(path, sheetName, fieldName);


                if (dt == null || dt.Rows.Count == 0) return list;
                IList<string> titleList = new List<string>();
                var colLength = dt.Columns.Count;
                foreach (DataColumn dc in dt.Columns)
                {
                    titleList.Add(dc.ColumnName);
                }
                list.Add(titleList);
                var columCount = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    IList<string> colList = new List<string>();
                    for (int i = 0; i < columCount; i++)
                    {
                        colList.Add(dr[i].ToString().Trim());
                    }
                    list.Add(colList);
                }
            }
            catch
            {

            }
            finally
            {
                //File.Delete(path);
            }
            return list;
        }

        public static IList<IList<string>> ReadData(HttpPostedFile httpPostedFileBase, string sheetName)
        {
            IList<IList<string>> list = new List<IList<string>>();
            string path = string.Empty;
            try
            {
                //path = SaveFile(httpPostedFileBase);
                //DataTable dt = Query(path, sheetName);

                DataTable dt = ReadExcelToDataTable(httpPostedFileBase, sheetName);

                if (dt == null || dt.Rows.Count == 0) return list;
                IList<string> titleList = new List<string>();
                var colLength = dt.Columns.Count;
                foreach (DataColumn dc in dt.Columns)
                {
                    titleList.Add(dc.ColumnName);
                }
                list.Add(titleList);
                var columCount = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    IList<string> colList = new List<string>();
                    for (int i = 0; i < columCount; i++)
                    {
                        colList.Add(dr[i].ToString().Trim());
                    }
                    list.Add(colList);
                }
            }
            catch
            {

            }
            finally
            {
                //File.Delete(path);
            }
            return list;
        }
        /// <summary>
        /// 保存临时文件
        /// </summary>
        /// <param name="httpPostedFileBase"></param>
        /// <returns></returns>
        private static string SaveFile(HttpPostedFile httpPostedFileBase)
        {
            //http://www.cnblogs.com/mickeychang/archive/2009/03/26/1422589.html
            string tempPath = "exceltemefile\\";
            string filename = "excel" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(100, 10000).ToString() + ".xls";
            string path = System.AppDomain.CurrentDomain.BaseDirectory + tempPath + filename;
            if (File.Exists(path)) // delete the file if it exists. (3)
            {
                File.Delete(path);
            }
            try
            {
                httpPostedFileBase.SaveAs(path);
            }
            catch (Exception ex)
            {
                throw new Exception("上传文件失败，服务器没有开启写入权限", ex);
            }
            return path;
        }
        #endregion
        /// <summary>
        /// 获取Excel的第一个Sheet的数据。注意，这里的第一个是按Sheet名排列后的第一个Sheet。
        /// <example>
        /// DataTable dt = Query(@"C:\My Documents\1.xls");
        /// </example>
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <returns></returns>
        public static DataTable Query(string excelPath)
        {
            return Query(excelPath, 0);
        }

        /// <summary>
        /// 获取Excel指定Sheet名称的数据。
        /// <example>
        /// DataTable dt = Query(@"C:\My Documents\1.xls", "sheet1");
        /// </example>
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="sheetName">Sheet名，允许空格存在。如：sheet1</param>
        /// <returns></returns>
        public static DataTable Query(string excelPath, string sheetName)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            conn.Open();

            DataTable dt = new DataTable();
            dt = QueryBySheetName(conn, sheetName + "$");

            conn.Close();
            return dt;
        }

        /// <summary>
        /// 获取Excel指定Sheet名称的数据。
        /// <example>
        /// DataTable dt = Query(@"C:\My Documents\1.xls", "sheet1");
        /// </example>
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="sheetName">Sheet名，允许空格存在。如：sheet1</param>
        /// <returns></returns>
        public static DataTable QueryFilterEmpty(string excelPath, string sheetName)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            conn.Open();

            DataTable dt = new DataTable();
            dt = QueryBySheetNameFilterEmpty(conn, sheetName + "$");

            conn.Close();
            return dt;
        }
        public static DataTable QueryFilterEmpty(string excelPath, string sheetName, string fieldName)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            conn.Open();

            DataTable dt = new DataTable();
            dt = QueryBySheetNameFilterEmpty(conn, sheetName + "$", fieldName);

            conn.Close();
            return dt;
        }
        /// <summary>
        /// 获取Excel指定Sheet名称的数据。
        /// <example>
        /// DataTable dt = Query(@"C:\My Documents\1.xls", "sheet1$");
        /// DataTable dt = Query(@"C:\My Documents\1.xls", "'My Sheet'$");
        /// </example>
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="rawSheetName">Sheet名，允许空格存在。如：sheet1$, 'My Sheet'$</param>
        /// <returns></returns>
        public static DataTable QueryEx(string excelPath, string rawSheetName)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            conn.Open();

            DataTable dt = new DataTable();
            dt = QueryBySheetName(conn, rawSheetName);

            conn.Close();
            return dt;
        }

        /// <summary>
        /// 获取指定序号的Sheet的数据。序号从0开始。注意，是按Sheet名排列后的第Index个Sheet。
        /// <example>
        /// DataTable dt = Query(@"C:\My Documents\1.xls", 0);
        /// </example>
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="sheetIndex">Sheet的序号，从0开始。</param>
        /// <returns></returns>
        public static DataTable Query(string excelPath, int sheetIndex)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            //string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", excelPath);
            //OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();

            ArrayList arrSheets = GetSheetNames(conn);
            if (arrSheets.Count <= sheetIndex)
                throw new ArgumentOutOfRangeException();
            string sheetName = arrSheets[sheetIndex].ToString();
            DataTable dt = QueryBySheetName(conn, sheetName);
            conn.Close();
            return dt;
        }

        /// <summary>
        /// 获取Excel的所有的Sheet的名称。
        /// </summary>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <returns></returns>
        public static ArrayList GetSheetNames(string excelPath)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            ArrayList arrSheets = GetSheetNames(conn);
            conn.Close();
            return arrSheets;
        }

        /// <summary>
        /// 将DataTable的内容保存到Excel的一个指定模板的Sheet中。
        /// 指定模板是指指定了的列头。
        /// </summary>
        /// <param name="dt">要保存的数据</param>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="sheetName">Sheet名，允许空格存在。如：sheet1</param>
        public static void DataTableToExcel(DataTable dt, string excelPath, string sheetName)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            conn.Open();
            DataTableToExcel(conn, dt, sheetName + "$");
            conn.Close();
        }

        /// <summary>
        /// 将DataTable的内容保存到Excel的一个指定模板的Sheet中。
        /// 指定模板是指指定了的列头。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="excelPath">Excel文件绝对路径。</param>
        /// <param name="sheetIndex">Sheet的序号，从0开始。</param>
        public static void DataTableToExcel(DataTable dt, string excelPath, int sheetIndex)
        {
            OleDbConnection conn = CreateConnection(excelPath);
            conn.Open();

            ArrayList arrSheets = GetSheetNames(conn);
            if (arrSheets.Count <= sheetIndex)
                throw new ArgumentOutOfRangeException();

            string sheetName = arrSheets[sheetIndex].ToString();
            DataTableToExcel(conn, dt, sheetName);
            conn.Close();
        }


        /// <summary>
        /// Allowed:
        ///     12121.32432434e+10
        ///     -1.32432434E-20
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToNumberString(string s)
        {
            string result = string.Empty;
            try
            {
                // 先检查是不是合法的数字字符串
                if (!Regex.IsMatch(s, @"^[\-\+]?[0-9]+(\.[0-9]+)?[eE]+[\+\-][0-9]+$"))
                    return s;
                decimal value = decimal.Parse(s,
                    System.Globalization.NumberStyles.AllowExponent | System.Globalization.NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture);
                result = value.ToString();
            }
            catch
            {
                //throw new Exception("",ex);   
                result = s;
                return result;
            }
            return result;
        }



        #region Private Methods

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="excelVersion"></param>
        /// <returns></returns>
        private static string GetConnectionString(string excelPath, string excelVersion)
        {
            return string.Format(CultureInfo.InvariantCulture, ConnectionStringTemplate, excelPath, excelVersion);
        }

        /// <summary>
        /// 根据Sheet的名获取数据。
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private static DataTable QueryBySheetName(OleDbConnection conn, string sheetName)
        {
            try
            {
                //+ " where [" + sheetName + "].工号<> ''"
                string cmd = "select * from [" + sheetName + "]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }

        /// <summary>
        /// 根据Sheet的名获取数据。
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private static DataTable QueryBySheetNameFilterEmpty(OleDbConnection conn, string sheetName)
        {
            try
            {
                //+ " where [" + sheetName + "].工号<> ''"
                string cmd = "select * from [" + sheetName + "] where [" + sheetName + "].姓名<> ''";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }
        /// <summary>
        /// 根据Sheet的名获取数据，重载add by hudong 7.19
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private static DataTable QueryBySheetNameFilterEmpty(OleDbConnection conn, string sheetName, string fieldName)
        {
            try
            {
                string cmd = "select * from [" + sheetName + "] where [" + sheetName + "]." + fieldName + " <> '' ";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }
        /// <summary>
        /// 获取所有的Sheet名
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private static ArrayList GetSheetNames(OleDbConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            ArrayList arrSheets = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                arrSheets.Add(row[2]);
            }
            return arrSheets;
        }

        /// <summary>
        /// 两个DataTable的数据对拷
        /// </summary>
        /// <param name="srcTable"></param>
        /// <param name="destTable"></param>
        private static void CopyDataTable(DataTable srcTable, DataTable destTable)
        {
            foreach (DataRow row in srcTable.Rows)
            {
                DataRow newRow = destTable.NewRow();
                for (int i = 0; i < destTable.Columns.Count; i++)
                {
                    newRow[i] = row[i];
                }
                destTable.Rows.Add(newRow);
            }
        }

        /// <summary>
        /// 将DataTable的内容保存到Excel中。
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="dt"></param>
        /// <param name="sheetName"></param>
        private static void DataTableToExcel(OleDbConnection conn, DataTable dt, string sheetName)
        {
            string cmd = "select * from [" + sheetName + "$]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            cmdBuilder.QuotePrefix = "[";
            cmdBuilder.QuoteSuffix = "]";
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table1");

            CopyDataTable(dt, ds.Tables[0]);

            adapter.Update(ds, "Table1");
        }

        #endregion
    }
    public class ExcelExport
    {
        /// <summary>  
        /// 批量导出需要导出的列表  
        /// </summary>  
        /// <returns></returns>  
        public static  MemoryStream ExportMemory(DataTable source,List<string> caption)
        {
            //创建Excel文件的对象  
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了  
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            for (int i = 0; i < caption.Count; i++)
            {
                var element = caption[i];
                row1.CreateCell(i).SetCellValue(element);
            } 
            //将数据逐步写入sheet1各个行  
            for (int i = 0; i < source.Rows.Count; i++)
            {
                var dataRow = source.Rows[i];
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                for (int j = 0; j < caption.Count; j++)
                {
                    var keyValue = caption[j];
                    rowtemp.CreateCell(j).SetCellValue(dataRow[j].ToString());
                }
            }
            // 写入到客户端   
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "查询结果" + dateTime + ".xls";
            return ms;
            //return File(ms, "application/vnd.ms-excel", fileName);
        }
        public static  MemoryStream ExportMemory<T>(List<T> entities, List<string> fields)
        {
            //创建Excel文件的对象  
            HSSFWorkbook book = new HSSFWorkbook();
            ISheet sheet1 = book.CreateSheet("Sheet1");
            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了  
            IRow row1 = sheet1.CreateRow(0);

            var rowstyle = book.CreateCellStyle();
            rowstyle.Alignment = HorizontalAlignment.Center;
            rowstyle.VerticalAlignment = VerticalAlignment.Center;
            rowstyle.FillBackgroundColor = HSSFColor.COLOR_NORMAL;
            var font = book.CreateFont();            
            font.IsBold = true;
            font.FontName = "宋体";
            rowstyle.SetFont(font);

            T entity = entities[0];
            for (int i = 0; i < fields.Count; i++)
            {
                Type t=entity.GetType();
                string filed = fields[i];
                string caption = GetCaption(t.GetTypeInfo().GetProperty(filed), filed);
                var rowCell = row1.CreateCell(i);
                    rowCell.SetCellValue(caption);
                    rowCell.CellStyle = rowstyle;
                rowCell.Row.Height = 360;
            }
            //将数据逐步写入sheet1各个行  
            for (int i = 0; i < entities.Count; i++)
            {
                var t = entities[i];
                IRow rowtemp = sheet1.CreateRow(i + 1);
                for (int j = 0; j < fields.Count; j++)
                {
                    var type = t.GetType();
                    var filed = fields[j];
                    var value = type.GetProperty(filed).GetValue(t, null);
                    var cell = rowtemp.CreateCell(j);
                    cell.Row.Height = 300;
                    cell.SetCellValue(value==null?"":value.ToString());
                }
            }
            // 写入到客户端   
            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public  static string GetCaption(PropertyInfo proper,string properName)
        {
            object[] objs = proper.GetCustomAttributes(typeof(TableAttribute), true);
            string columnName= "";
            foreach (var obj in objs)
            {
                if (obj is TableAttribute)
                {
                    TableAttribute target = (TableAttribute)obj;
                    columnName = target.ColumnName;
                    break;
                }
            }
            return columnName;
        }
    }
}
