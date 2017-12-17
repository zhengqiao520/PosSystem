namespace Ingpal.BusinessStore.Presentation
{
    partial class frmReturnGoods
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnReturnGoods = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelReturnAmount = new DevExpress.XtraEditors.LabelControl();
            this.labelReturnCount = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelGuider = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelPaytype = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelSaleDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelLS = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtGuider = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtBarID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTicketCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlReturnGoods = new DevExpress.XtraGrid.GridControl();
            this.gridViewReturnGoods = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReturnCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemSpinGoodsCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colGoodsAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextGoodsAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTicketCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReturnGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReturnGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemSpinGoodsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextGoodsAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btnReturnGoods);
            this.panelControl4.Controls.Add(this.btnCancel);
            this.panelControl4.Controls.Add(this.txtDescription);
            this.panelControl4.Controls.Add(this.labelControl14);
            this.panelControl4.Controls.Add(this.labelControl16);
            this.panelControl4.Controls.Add(this.labelReturnAmount);
            this.panelControl4.Controls.Add(this.labelReturnCount);
            this.panelControl4.Controls.Add(this.labelControl13);
            this.panelControl4.Controls.Add(this.labelControl12);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(3, 589);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1074, 149);
            this.panelControl4.TabIndex = 3;
            // 
            // btnReturnGoods
            // 
            this.btnReturnGoods.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturnGoods.Location = new System.Drawing.Point(707, 54);
            this.btnReturnGoods.Name = "btnReturnGoods";
            this.btnReturnGoods.Size = new System.Drawing.Size(91, 31);
            this.btnReturnGoods.TabIndex = 3;
            this.btnReturnGoods.Text = "退货";
            this.btnReturnGoods.Click += new System.EventHandler(this.btnReturnGoods_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(582, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(62, 20);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.AutoHeight = false;
            this.txtDescription.Size = new System.Drawing.Size(502, 65);
            this.txtDescription.TabIndex = 4;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(702, 22);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(60, 14);
            this.labelControl14.TabIndex = 0;
            this.labelControl14.Text = "退货金额：";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(912, 15);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(0, 14);
            this.labelControl16.TabIndex = 0;
            // 
            // labelReturnAmount
            // 
            this.labelReturnAmount.Appearance.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturnAmount.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelReturnAmount.Location = new System.Drawing.Point(768, 21);
            this.labelReturnAmount.Name = "labelReturnAmount";
            this.labelReturnAmount.Size = new System.Drawing.Size(31, 19);
            this.labelReturnAmount.TabIndex = 0;
            this.labelReturnAmount.Text = "0.00";
            // 
            // labelReturnCount
            // 
            this.labelReturnCount.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelReturnCount.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelReturnCount.Location = new System.Drawing.Point(648, 21);
            this.labelReturnCount.Name = "labelReturnCount";
            this.labelReturnCount.Size = new System.Drawing.Size(9, 18);
            this.labelReturnCount.TabIndex = 0;
            this.labelReturnCount.Text = "0";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(582, 23);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(60, 14);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "退货数量：";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(9, 19);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(36, 14);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "备注：";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelGuider);
            this.panelControl2.Controls.Add(this.labelControl10);
            this.panelControl2.Controls.Add(this.labelPaytype);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelSaleDate);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.labelLS);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 78);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1074, 69);
            this.panelControl2.TabIndex = 1;
            // 
            // labelGuider
            // 
            this.labelGuider.Location = new System.Drawing.Point(762, 27);
            this.labelGuider.Name = "labelGuider";
            this.labelGuider.Size = new System.Drawing.Size(0, 14);
            this.labelGuider.TabIndex = 0;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(708, 27);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 14);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "导购员：";
            // 
            // labelPaytype
            // 
            this.labelPaytype.Location = new System.Drawing.Point(570, 27);
            this.labelPaytype.Name = "labelPaytype";
            this.labelPaytype.Size = new System.Drawing.Size(0, 14);
            this.labelPaytype.TabIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(504, 27);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "支付方式：";
            // 
            // labelSaleDate
            // 
            this.labelSaleDate.Location = new System.Drawing.Point(342, 27);
            this.labelSaleDate.Name = "labelSaleDate";
            this.labelSaleDate.Size = new System.Drawing.Size(0, 14);
            this.labelSaleDate.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(276, 27);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "销售时间：";
            // 
            // labelLS
            // 
            this.labelLS.Location = new System.Drawing.Point(98, 27);
            this.labelLS.Name = "labelLS";
            this.labelLS.Size = new System.Drawing.Size(0, 14);
            this.labelLS.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 27);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "销售流水号：";
            // 
            // tableLayout
            // 
            this.tableLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.panelControl4, 0, 3);
            this.tableLayout.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayout.Controls.Add(this.panelControl2, 0, 1);
            this.tableLayout.Controls.Add(this.panelControl3, 0, 2);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 4;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayout.Size = new System.Drawing.Size(1080, 741);
            this.tableLayout.TabIndex = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSelect);
            this.panelControl1.Controls.Add(this.txtGuider);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtBarID);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtTicketCode);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1074, 69);
            this.panelControl1.TabIndex = 0;
            // 
            // txtGuider
            // 
            this.txtGuider.Location = new System.Drawing.Point(624, 23);
            this.txtGuider.Name = "txtGuider";
            this.txtGuider.Properties.AutoHeight = false;
            this.txtGuider.Properties.ReadOnly = true;
            this.txtGuider.Size = new System.Drawing.Size(175, 25);
            this.txtGuider.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(558, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "导购员：";
            // 
            // txtBarID
            // 
            this.txtBarID.Location = new System.Drawing.Point(348, 23);
            this.txtBarID.Name = "txtBarID";
            this.txtBarID.Properties.AutoHeight = false;
            this.txtBarID.Size = new System.Drawing.Size(175, 25);
            this.txtBarID.TabIndex = 2;
            this.txtBarID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarID_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(282, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "商品编码：";
            // 
            // txtTicketCode
            // 
            this.txtTicketCode.Location = new System.Drawing.Point(86, 23);
            this.txtTicketCode.Name = "txtTicketCode";
            this.txtTicketCode.Properties.AutoHeight = false;
            this.txtTicketCode.Size = new System.Drawing.Size(175, 25);
            this.txtTicketCode.TabIndex = 1;
            this.txtTicketCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTicketCode_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "退货小票：";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.gridControlReturnGoods);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 153);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1074, 430);
            this.panelControl3.TabIndex = 2;
            // 
            // gridControlReturnGoods
            // 
            this.gridControlReturnGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlReturnGoods.Location = new System.Drawing.Point(0, 0);
            this.gridControlReturnGoods.MainView = this.gridViewReturnGoods;
            this.gridControlReturnGoods.Name = "gridControlReturnGoods";
            this.gridControlReturnGoods.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemSpinGoodsCount,
            this.ItemTextGoodsAmount});
            this.gridControlReturnGoods.Size = new System.Drawing.Size(1074, 430);
            this.gridControlReturnGoods.TabIndex = 0;
            this.gridControlReturnGoods.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReturnGoods,
            this.gridView1});
            // 
            // gridViewReturnGoods
            // 
            this.gridViewReturnGoods.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.gridViewReturnGoods.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewReturnGoods.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBarID,
            this.colGoodsName,
            this.colRetailPrice,
            this.colReturnCount,
            this.colGoodsCount,
            this.colGoodsAmount});
            this.gridViewReturnGoods.GridControl = this.gridControlReturnGoods;
            this.gridViewReturnGoods.Name = "gridViewReturnGoods";
            this.gridViewReturnGoods.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewReturnGoods.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewReturnGoods.OptionsView.ShowGroupPanel = false;
            this.gridViewReturnGoods.OptionsView.ShowIndicator = false;
            this.gridViewReturnGoods.RowHeight = 25;
            this.gridViewReturnGoods.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewReturnGoods_RowUpdated);
            // 
            // colBarID
            // 
            this.colBarID.Caption = "商品编码";
            this.colBarID.FieldName = "BarID";
            this.colBarID.Name = "colBarID";
            this.colBarID.OptionsColumn.AllowEdit = false;
            this.colBarID.OptionsColumn.AllowFocus = false;
            this.colBarID.OptionsColumn.ReadOnly = true;
            this.colBarID.Visible = true;
            this.colBarID.VisibleIndex = 0;
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "商品名称";
            this.colGoodsName.FieldName = "GoodsName";
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.OptionsColumn.AllowEdit = false;
            this.colGoodsName.OptionsColumn.AllowFocus = false;
            this.colGoodsName.OptionsColumn.ReadOnly = true;
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 1;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.Caption = "商品原价";
            this.colRetailPrice.FieldName = "RetailPrice";
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.OptionsColumn.AllowEdit = false;
            this.colRetailPrice.OptionsColumn.AllowFocus = false;
            this.colRetailPrice.OptionsColumn.ReadOnly = true;
            this.colRetailPrice.Visible = true;
            this.colRetailPrice.VisibleIndex = 2;
            // 
            // colReturnCount
            // 
            this.colReturnCount.Caption = "可退货数量";
            this.colReturnCount.FieldName = "GoodsCount";
            this.colReturnCount.Name = "colReturnCount";
            this.colReturnCount.OptionsColumn.AllowEdit = false;
            this.colReturnCount.OptionsColumn.AllowFocus = false;
            this.colReturnCount.OptionsColumn.ReadOnly = true;
            this.colReturnCount.Visible = true;
            this.colReturnCount.VisibleIndex = 3;
            // 
            // colGoodsCount
            // 
            this.colGoodsCount.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.colGoodsCount.AppearanceCell.Options.UseFont = true;
            this.colGoodsCount.Caption = "退货数量";
            this.colGoodsCount.ColumnEdit = this.ItemSpinGoodsCount;
            this.colGoodsCount.FieldName = "ReturnCount";
            this.colGoodsCount.Name = "colGoodsCount";
            this.colGoodsCount.Visible = true;
            this.colGoodsCount.VisibleIndex = 4;
            // 
            // ItemSpinGoodsCount
            // 
            this.ItemSpinGoodsCount.AutoHeight = false;
            this.ItemSpinGoodsCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemSpinGoodsCount.DisplayFormat.FormatString = "D";
            this.ItemSpinGoodsCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemSpinGoodsCount.EditFormat.FormatString = "D";
            this.ItemSpinGoodsCount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemSpinGoodsCount.Mask.EditMask = "D";
            this.ItemSpinGoodsCount.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ItemSpinGoodsCount.Name = "ItemSpinGoodsCount";
            this.ItemSpinGoodsCount.NullText = "0";
            // 
            // colGoodsAmount
            // 
            this.colGoodsAmount.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.colGoodsAmount.AppearanceCell.Options.UseFont = true;
            this.colGoodsAmount.Caption = "退货金额";
            this.colGoodsAmount.ColumnEdit = this.ItemTextGoodsAmount;
            this.colGoodsAmount.FieldName = "ReturnAmount";
            this.colGoodsAmount.Name = "colGoodsAmount";
            this.colGoodsAmount.Visible = true;
            this.colGoodsAmount.VisibleIndex = 5;
            // 
            // ItemTextGoodsAmount
            // 
            this.ItemTextGoodsAmount.AutoHeight = false;
            this.ItemTextGoodsAmount.DisplayFormat.FormatString = "{0.00}";
            this.ItemTextGoodsAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ItemTextGoodsAmount.EditFormat.FormatString = "{0:0.00}";
            this.ItemTextGoodsAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ItemTextGoodsAmount.Mask.EditMask = "c";
            this.ItemTextGoodsAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextGoodsAmount.Name = "ItemTextGoodsAmount";
            this.ItemTextGoodsAmount.NullText = "0.00";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlReturnGoods;
            this.gridView1.Name = "gridView1";
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSelect.Location = new System.Drawing.Point(835, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(86, 30);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.txtBarID_EditValueChanged);
            // 
            // frmReturnGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 741);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReturnGoods";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "销售退货";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReturnGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTicketCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReturnGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReturnGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemSpinGoodsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextGoodsAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnReturnGoods;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelReturnAmount;
        private DevExpress.XtraEditors.LabelControl labelReturnCount;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelGuider;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelPaytype;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelSaleDate;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelLS;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtBarID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTicketCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControlReturnGoods;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReturnGoods;
        private DevExpress.XtraGrid.Columns.GridColumn colBarID;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colReturnCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ItemSpinGoodsCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextGoodsAmount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtGuider;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
    }
}