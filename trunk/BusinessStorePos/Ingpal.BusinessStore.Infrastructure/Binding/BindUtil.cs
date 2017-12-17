using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace Ingpal.BusinessStore.Infrastructure
{
    /// <summary>
    /// 绑定数据帮助类
    /// </summary>
    public static class BindUtil
    {
        /// <summary>
        /// 绑定LookUpEdit
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="lst">LookUpEdit控件</param>
        /// <param name="needQingXuanZ">是否需要请选择</param>
        public static void BindDropDownList(DataTable dt, LookUpEdit lst, bool needQingXuanZ)
        {
            if (dt.Columns.Count > 2)
            {
                return;
            }

            if (dt.Columns.Count == 1)
            {
                dt = ConvertHelper.AddColumn(dt);
            }

            if (needQingXuanZ)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "--请选择--";
                dr[1] = "-99999";
                dt.Rows.InsertAt(dr, 0);
            }

            lst.Properties.DataSource = dt;
            lst.Properties.DisplayMember = dt.Columns[0].ColumnName;
            lst.Properties.ValueMember = dt.Columns[1].ColumnName;
            lst.Properties.Columns.Clear();
            lst.Properties.Columns.Add(new LookUpColumnInfo(dt.Columns[0].ColumnName, 80));
            lst.Properties.ShowHeader = false;
            lst.Properties.ShowFooter = false;
            lst.Properties.NullText = "";
            lst.Properties.PopupFormMinSize = new System.Drawing.Size(10, 10);
            lst.Properties.BestFitMode = BestFitMode.BestFitResizePopup;//下拉框在第二个Tab页时，BestFit()不能显示全部
            lst.Properties.PopupWidth = lst.Properties.BestFit();//BestFitMode只在第一次弹出下拉框时生效，特殊情况不能满足
            lst.Properties.DropDownRows = dt.Rows.Count <= 6 ? dt.Rows.Count : 6;

            if (dt.Rows.Count > 0)
            {
                lst.Properties.ForceInitialize();
                lst.ItemIndex = 0;
            }
        }
        /// <summary>
        /// 绑定LookUpEdit
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="lst">LookUpEdit控件</param>
        /// <param name="needQingXuanZ">是否需要请选择</param>
        public static void BindDropDownList(DataTable dt, LookUpEdit lst, bool needQingXuanZ, int dropDownRows)
        {
            if (dt.Columns.Count > 2)
            {
                return;
            }

            if (dt.Columns.Count == 1)
            {
                dt = ConvertHelper.AddColumn(dt);
            }

            if (needQingXuanZ)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "--请选择--";
                dr[1] = "-99999";
                dt.Rows.InsertAt(dr, 0);
            }

            lst.Properties.DataSource = dt;
            lst.Properties.DisplayMember = dt.Columns[0].ColumnName;
            lst.Properties.ValueMember = dt.Columns[1].ColumnName;
            lst.Properties.Columns.Clear();
            lst.Properties.Columns.Add(new LookUpColumnInfo(dt.Columns[0].ColumnName, 80));
            lst.Properties.ShowHeader = false;
            lst.Properties.ShowFooter = false;
            lst.Properties.NullText = "";
            lst.Properties.PopupFormMinSize = new System.Drawing.Size(10, 10);
            lst.Properties.BestFitMode = BestFitMode.BestFitResizePopup;//下拉框在第二个Tab页时，BestFit()不能显示全部
            lst.Properties.PopupWidth = lst.Properties.BestFit();//BestFitMode只在第一次弹出下拉框时生效，特殊情况不能满足
            lst.Properties.DropDownRows = dropDownRows;

            if (dt.Rows.Count > 0)
            {
                lst.Properties.ForceInitialize();
                lst.ItemIndex = 0;
            }

        }
        /// <summary>
        /// 绑定LookUpEdit
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="lst">LookUpEdit控件</param>
        /// <param name="needQingXuanZ">是否需要选择值</param>
        /// <param name="DisplayMember">显示文本列</param>
        /// <param name="ValueMember">值列</param>
        public static void BindDropDownList(DataTable dt, LookUpEdit lst, bool needQingXuanZ, string DisplayMember, string ValueMember)
        {
            if (dt == null)
            {
                return;
            }

            if (needQingXuanZ)
            {
                DataRow dr = dt.NewRow();
                dr[DisplayMember] = "--请选择--";
                dr[ValueMember] = "-99999";
                dt.Rows.InsertAt(dr, 0);
            }

            lst.Properties.DataSource = dt;
            lst.Properties.DisplayMember = DisplayMember;
            lst.Properties.ValueMember = ValueMember;
            lst.Properties.Columns.Clear();
            lst.Properties.Columns.Add(new LookUpColumnInfo(DisplayMember, 80));
            lst.Properties.ShowHeader = false;
            lst.Properties.ShowFooter = false;
            lst.Properties.NullText = "";
            lst.Properties.PopupFormMinSize = new System.Drawing.Size(10, 10);
            lst.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            lst.Properties.PopupWidth = lst.Properties.BestFit();
            lst.Properties.DropDownRows = dt.Rows.Count <= 6 ? dt.Rows.Count : 6;

            if (dt.Rows.Count > 0)
            {
                lst.Properties.ForceInitialize();
                lst.ItemIndex = 0;
            }

        }

        /// <summary>
        /// 绑定LookUpEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        public static void BindDropDownList(DataTable dt, LookUpEdit lst)
        {
            BindDropDownList(dt, lst, false);
        }

        /// <summary>
        /// 绑定RepositoryItemLookUpEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        public static void BindDropDownList(DataTable dt, RepositoryItemLookUpEdit lst)
        {
            if (dt.Columns.Count >= 1 && dt.Columns.Count <= 2)
            {
                lst.DataSource = dt;
                lst.DisplayMember = dt.Columns[0].ColumnName;
                if (dt.Columns.Count == 1)
                {
                    lst.ValueMember = dt.Columns[0].ColumnName;
                }
                else
                {
                    lst.ValueMember = dt.Columns[1].ColumnName;
                }
                lst.Columns.Clear();
                lst.Columns.Add(new LookUpColumnInfo(dt.Columns[0].ColumnName, 80));
                lst.ShowHeader = false;
                lst.ShowFooter = false;
                lst.NullText = "";
                lst.PopupFormMinSize = new System.Drawing.Size(10, 10);
                lst.DropDownRows = dt.Rows.Count <= 6 ? dt.Rows.Count : 6;
            }
        }

        /// <summary>
        /// 绑定ComboBoxEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        public static void BindDropDownList(DataTable dt, DevExpress.XtraEditors.ComboBoxEdit lst)
        {
            if (dt != null && dt.Columns.Count >= 1 && dt.Columns.Count <= 2)
            {
                lst.Properties.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ComboBoxItem item;
                    if (dt.Columns.Count != 1)
                    {
                        item = new ComboBoxItem(row[0].ToString(), row[1].ToString());
                    }
                    else
                    {
                        item = new ComboBoxItem(row[0].ToString(), row[0].ToString());
                    }
                    lst.Properties.Items.Add(item);
                }
                if (lst.Properties.Items.Count > 0)
                    lst.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 绑定ImageComboBoxEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        public static void BindDropDownList(DataTable dt, ImageComboBoxEdit lst)
        {
            if (dt.Columns.Count >= 1 && dt.Columns.Count <= 2)
            {
                lst.Properties.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ImageComboBoxItem item;
                    if (dt.Columns.Count != 1)
                    {
                        item = new ImageComboBoxItem(row[0].ToString(), row[1].ToString());
                    }
                    else
                    {
                        item = new ImageComboBoxItem(row[0].ToString(), row[0].ToString());
                    }
                    lst.Properties.Items.Add(item);
                }
                if (lst.Properties.Items.Count > 0)
                    lst.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 绑定ImageComboBoxEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        public static void BindDropDownList(DataTable dt, RepositoryItemImageComboBox lst)
        {
            if (dt.Columns.Count >= 1 && dt.Columns.Count <= 2)
            {
                lst.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ImageComboBoxItem item;
                    if (dt.Columns.Count != 1)
                    {
                        item = new ImageComboBoxItem(row[0].ToString(), row[1].ToString());
                    }
                    else
                    {
                        item = new ImageComboBoxItem(row[0].ToString(), row[0].ToString());
                    }
                    lst.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 绑定ImageComBoBoxEdit下拉框数据  
        /// </summary>
        /// <param name="cmb">ImageComBoBoxEdit的name</param>
        /// <param name="dt">数据源</param>
        /// <param name="key">显示名称</param>
        /// <param name="val">对应EditValue值</param>
        public static void BindImageComboBoxEdit(ImageComboBoxEdit cmb, DataTable dt, string key, string val)
        {
            cmb.Properties.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = dr[key].ToString();
                item.Value = dr[val].ToString();
                cmb.Properties.Items.Add(item);
            }
            if (cmb.Properties.Items.Count > 0)
                cmb.SelectedIndex = 0;
        }
        public static void BindComboBoxEdit<T>(ComboBoxEdit cmb, List<T> lists, string key, string val,bool showNullText=true,bool showKeyValueMode=false) where T:new()
        {
            cmb.Properties.Items.Clear();
            if (!showNullText)
            {
                cmb.Properties.Items.Add(new ImageComboBoxItem("--请选择--", -1));
            }
            if (lists == null) { return; }
            lists.ForEach(lst =>
            {
                Type t = lst.GetType();
                var text = t.GetProperty(key).GetValue(lst, null);
                var value = t.GetProperty(val).GetValue(lst, null);
                string descrption = $"{value.ToString()}-{text.ToString()}";
                ComboBoxItem item = new ComboBoxItem(showKeyValueMode ? descrption : (text == null ? "" : text.ToString()), value == null ? "" : value.ToString(), text == null ? "" : text.ToString());
                cmb.Properties.Items.Add(item);
            });
            if (cmb.Properties.Items.Count > 0&&!showNullText)
                cmb.SelectedIndex = 0;
        }
        /// <summary>
        /// 绑定数据集到GridControl控件中的RepositoryItemImageComboBox列 
        /// </summary>
        /// <param name="cmb">RepositoryItemImageComboBox控件</param>
        /// <param name="dt"></param>
        /// <param name="description"></param>
        /// <param name="value"></param>
        public static void BindImageComboBoxEdit(RepositoryItemImageComboBox cmb, DataTable dt, string description, string value)
        {
            cmb.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = dr[description].ToString();
                item.Value = Convert.ToDecimal(dr[value]);
                cmb.Items.Add(item);
            }
        }
        /// <summary>
        /// 绑定数据集到GridControl控件中的RepositoryItemLookUpEdit列
        /// </summary>   
        /// <param name="lookUpEdit">lookupEdit控件</param>
        /// <param name="dataTable">数据源</param>
        /// <param name="displayMember">显示名称</param>
        /// <param name="valueMember">对应EditValue值</param>
        public static void BindLookUpEdit(RepositoryItemLookUpEdit lookUpEdit, DataTable dataTable, string displayMember, string valueMember)
        {
            if (dataTable.Rows.Count == 0 || dataTable.Rows[0][displayMember].ToString() != "--请选择--")
            {
                DataRow dataRowTemp = dataTable.NewRow();
                dataRowTemp[displayMember] = "--请选择--";
                dataRowTemp[valueMember] = "-99999";
                dataTable.Rows.InsertAt(dataRowTemp, 0);
            }

            lookUpEdit.DataSource = dataTable;
            lookUpEdit.DisplayMember = displayMember;
            lookUpEdit.ValueMember = valueMember;
            lookUpEdit.Columns.Clear();
            lookUpEdit.Columns.Add(new LookUpColumnInfo(displayMember));
            lookUpEdit.ShowHeader = false;
            lookUpEdit.ShowFooter = false;
            //lookUpEdit.NullText = "";
            lookUpEdit.PopupFormMinSize = new System.Drawing.Size(10, 10);
            //lookUpEdit.PopupWidth = lookUpEdit.Width - 3;
            lookUpEdit.DropDownRows = dataTable.Rows.Count <= 6 ? dataTable.Rows.Count : 6;
            lookUpEdit.NullText = "";
            if (dataTable.Rows.Count > 0)
            {
                lookUpEdit.ForceInitialize();
            }
        }

        /// <summary>
        /// 绑定数据集到GridControl控件中的RepositoryItemLookUpEdit列(无请选择列）
        /// </summary>   
        /// <param name="lookUpEdit">lookupEdit控件</param>
        /// <param name="dataTable">数据源</param>
        /// <param name="displayMember">显示名称</param>
        /// <param name="valueMember">对应EditValue值</param>
        public static void BindLookUpEdit(RepositoryItemLookUpEdit lookUpEdit, DataTable dataTable, string displayMember, string valueMember, string defaultvalue)
        {
            lookUpEdit.DataSource = dataTable;
            lookUpEdit.DisplayMember = displayMember;
            lookUpEdit.ValueMember = valueMember;
            lookUpEdit.Columns.Clear();
            lookUpEdit.Columns.Add(new LookUpColumnInfo(displayMember));
            lookUpEdit.ShowHeader = false;
            lookUpEdit.ShowFooter = false;
            lookUpEdit.NullText = "";
            lookUpEdit.PopupFormMinSize = new System.Drawing.Size(10, 10);
            lookUpEdit.DropDownRows = dataTable.Rows.Count <= 6 ? dataTable.Rows.Count : 6;
            if (dataTable.Rows.Count > 0)
            {
                lookUpEdit.ForceInitialize();
            }
        }
        /// <summary>
        /// 绑定CheckedComboBoxEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        public static void BindDropDownList(DataTable dt, CheckedComboBoxEdit lst)
        {
            if (dt.Columns.Count >= 1 && dt.Columns.Count <= 2)
            {
                lst.Properties.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    CheckedListBoxItem item;
                    if (dt.Columns.Count != 1)
                    {
                        item = new CheckedListBoxItem(row[1].ToString(), row[0].ToString());
                    }
                    else
                    {
                        item = new CheckedListBoxItem(row[1].ToString(), row[0].ToString());
                    }
                    lst.Properties.Items.Add(item);
                }

            }
        }

        /// <summary>绑定checkboxlist
        /// </summary>
        /// <param name="dt">数据dt</param>
        /// <param name="lst">CheckedListBoxControl的checkboxlist</param>
        /// <param name="description">显示名</param>
        /// <param name="value">值</param>
        public static void BindCheckBoxList(DataTable dt, CheckedListBoxControl lst, string description, string value)
        {
            lst.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                var checkedListBoxItem = new CheckedListBoxItem(dr[value], dr[description].ToString());
                lst.Items.Add(checkedListBoxItem);
            }
        }

        /// <summary>
        /// ComboBoxItem
        /// </summary>
        public class ComboBoxItem
        {
            /// <summary>
            /// ComboBox值
            /// </summary>
            private string _value;
            /// <summary>
            /// ComboBox文本
            /// </summary>
            private string _text;
            /// <summary>
            /// 格式化前原始字符串
            /// </summary>
            private string _orginText;

            /// <summary>
            /// ComboBoxItem构造函数
            /// </summary>
            /// <param name="text">文本</param>
            /// <param name="value">值</param>
            public ComboBoxItem(string text, string value,string orginText=null)
            {
                _value = value;
                _text = text;
                _orginText = orginText;
            }
            /// <summary>
            /// 覆盖ToString方法
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return _text;
            }
            /// <summary>
            /// 值
            /// </summary>
            public string Value
            {
                get
                {
                    return _value;
                }
            }
            public string Text {
                get {
                    return _text;
                }
            }
            public string OrginText
            {
                get {
                    return _orginText;
                }
            }
        }


        /// <summary>
        /// LookupEdit绑定 1是0否
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void BindLookUpEdit_IsOrNot(RepositoryItemLookUpEdit lookUpEdit)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S_CANSHUMC", typeof(string));
            dataTable.Columns.Add("S_CANSHUZ", typeof(string));
            DataRow dataRowTemp = dataTable.NewRow();
            dataRowTemp["S_CANSHUMC"] = "是";
            dataRowTemp["S_CANSHUZ"] = "1";
            dataTable.Rows.InsertAt(dataRowTemp, 0);
            dataRowTemp = dataTable.NewRow();
            dataRowTemp["S_CANSHUMC"] = "否";
            dataRowTemp["S_CANSHUZ"] = "0";
            dataTable.Rows.InsertAt(dataRowTemp, 1);

            BindLookUpEdit(lookUpEdit, dataTable, "S_CANSHUMC", "S_CANSHUZ");
        }

        /// <summary>
        /// LookupEdit绑定 年
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void BindLookUpEdit_Year(RepositoryItemLookUpEdit lookUpEdit)
        {
            int nowYear = DateTime.Now.Year;
            DataRow dataRowTemp;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S_CANSHUMC", typeof(string));
            dataTable.Columns.Add("S_CANSHUZ", typeof(int));

            dataRowTemp = dataTable.NewRow();
            dataRowTemp["S_CANSHUMC"] = " ";
            dataRowTemp["S_CANSHUZ"] = 0;
            dataTable.Rows.Add(dataRowTemp);

            for (int i = 0; i < 50; i++)
            {
                dataRowTemp = dataTable.NewRow();
                dataRowTemp["S_CANSHUMC"] = (nowYear - i).ToString();
                dataRowTemp["S_CANSHUZ"] = nowYear - i;
                dataTable.Rows.Add(dataRowTemp);
            }
            BindLookUpEdit(lookUpEdit, dataTable, "S_CANSHUMC", "S_CANSHUZ", "");
            lookUpEdit.DropDownRows = 12;
        }

        /// <summary>
        /// LookupEdit绑定 月
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void BindLookUpEdit_Month(RepositoryItemLookUpEdit lookUpEdit)
        {
            DataRow dataRowTemp;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S_CANSHUMC", typeof(string));
            dataTable.Columns.Add("S_CANSHUZ", typeof(int));

            for (int i = 0; i <= 12; i++)
            {
                dataRowTemp = dataTable.NewRow();
                if (0 == i)
                    dataRowTemp["S_CANSHUMC"] = " ";
                else
                    dataRowTemp["S_CANSHUMC"] = i.ToString();
                dataRowTemp["S_CANSHUZ"] = i;
                dataTable.Rows.Add(dataRowTemp);
            }
            BindLookUpEdit(lookUpEdit, dataTable, "S_CANSHUMC", "S_CANSHUZ", "");
            lookUpEdit.DropDownRows = 13;
        }


        /// <summary>
        /// LookupEdit绑定 组合查询运算符
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void BindLookUpEdit_Array(RepositoryItemLookUpEdit lookUpEdit, string[,] ShuZu)
        {
            DataRow dataRowTemp;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S_CANSHUMC", typeof(string));
            dataTable.Columns.Add("S_CANSHUZ", typeof(string));

            for (int i = 0; i < ShuZu.Length / 2; i++)
            {
                dataRowTemp = dataTable.NewRow();
                dataRowTemp["S_CANSHUMC"] = ShuZu[i, 0];
                dataRowTemp["S_CANSHUZ"] = ShuZu[i, 1];
                dataTable.Rows.Add(dataRowTemp);
            }
            BindLookUpEdit(lookUpEdit, dataTable, "S_CANSHUMC", "S_CANSHUZ", "");
        }


        /// <summary>
        /// 绑定 CheckedComboBox
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lst"></param>
        /// <param name="description"></param>
        /// <param name="value"></param>
        public static void BindCheckedComboBoxEdit(DataTable dt, RepositoryItemCheckedComboBoxEdit lst, string description, string value)
        {
            lst.DataSource = dt;
            lst.DisplayMember = description;
            lst.ValueMember = value;
            lst.SelectAllItemCaption = "选择全部";
            lst.SelectAllItemVisible = true;
            lst.ShowButtons = false;
            lst.GetItems();
        }





    }
}
