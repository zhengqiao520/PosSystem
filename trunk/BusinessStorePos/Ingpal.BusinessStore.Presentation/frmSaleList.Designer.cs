namespace Ingpal.BusinessStore.Presentation
{
    partial class frmSaleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEndTime = new DevExpress.XtraEditors.DateEdit();
            this.dateStartTime = new DevExpress.XtraEditors.DateEdit();
            this.btnQuerySale = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTickno = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlPosDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewPosDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPosID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGoodsCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGoodsCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReturnCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGoodsAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscountPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscountAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSaleDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlPos = new DevExpress.XtraGrid.GridControl();
            this.gridViewPos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTicketCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCashier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordSerial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTickno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPosDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPosDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1018, 653);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.dateEndTime);
            this.groupControl1.Controls.Add(this.dateStartTime);
            this.groupControl1.Controls.Add(this.btnQuerySale);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtTickno);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", ((System.Drawing.Image)(resources.GetObject("groupControl1.CustomHeaderButtons"))))});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1012, 104);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "销售查询";
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // dateEndTime
            // 
            this.dateEndTime.EditValue = null;
            this.dateEndTime.Location = new System.Drawing.Point(597, 62);
            this.dateEndTime.Name = "dateEndTime";
            this.dateEndTime.Properties.AutoHeight = false;
            this.dateEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEndTime.Size = new System.Drawing.Size(180, 28);
            this.dateEndTime.TabIndex = 18;
            // 
            // dateStartTime
            // 
            this.dateStartTime.EditValue = null;
            this.dateStartTime.Location = new System.Drawing.Point(375, 60);
            this.dateStartTime.Name = "dateStartTime";
            this.dateStartTime.Properties.AutoHeight = false;
            this.dateStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStartTime.Size = new System.Drawing.Size(188, 28);
            this.dateStartTime.TabIndex = 17;
            // 
            // btnQuerySale
            // 
            this.btnQuerySale.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnQuerySale.Appearance.Options.UseFont = true;
            this.btnQuerySale.Location = new System.Drawing.Point(811, 58);
            this.btnQuerySale.Name = "btnQuerySale";
            this.btnQuerySale.Size = new System.Drawing.Size(102, 33);
            this.btnQuerySale.TabIndex = 16;
            this.btnQuerySale.Text = "查询";
            this.btnQuerySale.Click += new System.EventHandler(this.btnQuerySale_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(572, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 23);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "—";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Location = new System.Drawing.Point(296, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 21);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "销售时间";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(13, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 21);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "小票编号";
            // 
            // txtTickno
            // 
            this.txtTickno.Location = new System.Drawing.Point(81, 60);
            this.txtTickno.Name = "txtTickno";
            this.txtTickno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtTickno.Properties.Appearance.Options.UseFont = true;
            this.txtTickno.Size = new System.Drawing.Size(197, 28);
            this.txtTickno.TabIndex = 9;
            this.txtTickno.EditValueChanged += new System.EventHandler(this.txtTickno_EditValueChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Controls.Add(this.splitter1);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 113);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1012, 537);
            this.panelControl1.TabIndex = 2;
            // 
            // groupControl3
            // 
            this.groupControl3.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImage")));
            this.groupControl3.Controls.Add(this.gridControlPosDetail);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(568, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(442, 533);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "销售明细";
            // 
            // gridControlPosDetail
            // 
            this.gridControlPosDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPosDetail.Location = new System.Drawing.Point(2, 39);
            this.gridControlPosDetail.MainView = this.gridViewPosDetail;
            this.gridControlPosDetail.Name = "gridControlPosDetail";
            this.gridControlPosDetail.Size = new System.Drawing.Size(438, 492);
            this.gridControlPosDetail.TabIndex = 1;
            this.gridControlPosDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPosDetail});
            // 
            // gridViewPosDetail
            // 
            this.gridViewPosDetail.ColumnPanelRowHeight = 35;
            this.gridViewPosDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailID,
            this.gridColumnPosID,
            this.gridColumnBarID,
            this.gridColumnGoodsName,
            this.gridColumnGoodsCategory,
            this.gridColumnRetailPrice,
            this.gridColumnGoodsCount,
            this.gridColumnReturnCount,
            this.gridColumnGoodsAmount,
            this.gridColumnDiscountRate,
            this.gridColumnDiscountPrice,
            this.gridColumnDiscountAmount,
            this.gridColumnSaleDate});
            this.gridViewPosDetail.GridControl = this.gridControlPosDetail;
            this.gridViewPosDetail.Name = "gridViewPosDetail";
            this.gridViewPosDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPosDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPosDetail.OptionsBehavior.Editable = false;
            this.gridViewPosDetail.OptionsBehavior.ReadOnly = true;
            this.gridViewPosDetail.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewPosDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPosDetail.OptionsView.ShowFooter = true;
            this.gridViewPosDetail.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridViewPosDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewPosDetail.RowHeight = 35;
            this.gridViewPosDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewPosDetail_RowStyle);
            // 
            // colDetailID
            // 
            this.colDetailID.Caption = "ID";
            this.colDetailID.FieldName = "ID";
            this.colDetailID.Name = "colDetailID";
            // 
            // gridColumnPosID
            // 
            this.gridColumnPosID.Caption = "Pos主键";
            this.gridColumnPosID.FieldName = "PosID";
            this.gridColumnPosID.Name = "gridColumnPosID";
            this.gridColumnPosID.Width = 100;
            // 
            // gridColumnBarID
            // 
            this.gridColumnBarID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnBarID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnBarID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBarID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBarID.Caption = "商品编码";
            this.gridColumnBarID.FieldName = "BarID";
            this.gridColumnBarID.MinWidth = 100;
            this.gridColumnBarID.Name = "gridColumnBarID";
            this.gridColumnBarID.Visible = true;
            this.gridColumnBarID.VisibleIndex = 0;
            this.gridColumnBarID.Width = 100;
            // 
            // gridColumnGoodsName
            // 
            this.gridColumnGoodsName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnGoodsName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnGoodsName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnGoodsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnGoodsName.Caption = "商品名称";
            this.gridColumnGoodsName.FieldName = "GoodsName";
            this.gridColumnGoodsName.MinWidth = 100;
            this.gridColumnGoodsName.Name = "gridColumnGoodsName";
            this.gridColumnGoodsName.Visible = true;
            this.gridColumnGoodsName.VisibleIndex = 1;
            this.gridColumnGoodsName.Width = 100;
            // 
            // gridColumnGoodsCategory
            // 
            this.gridColumnGoodsCategory.AppearanceCell.Options.UseFont = true;
            this.gridColumnGoodsCategory.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnGoodsCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnGoodsCategory.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnGoodsCategory.AppearanceHeader.Options.UseFont = true;
            this.gridColumnGoodsCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnGoodsCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnGoodsCategory.Caption = "商品类别";
            this.gridColumnGoodsCategory.FieldName = "GoodsCategory";
            this.gridColumnGoodsCategory.MinWidth = 100;
            this.gridColumnGoodsCategory.Name = "gridColumnGoodsCategory";
            this.gridColumnGoodsCategory.Visible = true;
            this.gridColumnGoodsCategory.VisibleIndex = 2;
            this.gridColumnGoodsCategory.Width = 100;
            // 
            // gridColumnRetailPrice
            // 
            this.gridColumnRetailPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnRetailPrice.AppearanceHeader.Options.UseFont = true;
            this.gridColumnRetailPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnRetailPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnRetailPrice.Caption = "列表单价";
            this.gridColumnRetailPrice.FieldName = "RetailPrice";
            this.gridColumnRetailPrice.MinWidth = 80;
            this.gridColumnRetailPrice.Name = "gridColumnRetailPrice";
            this.gridColumnRetailPrice.Visible = true;
            this.gridColumnRetailPrice.VisibleIndex = 3;
            this.gridColumnRetailPrice.Width = 80;
            // 
            // gridColumnGoodsCount
            // 
            this.gridColumnGoodsCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnGoodsCount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnGoodsCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnGoodsCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnGoodsCount.Caption = "销售数量";
            this.gridColumnGoodsCount.FieldName = "GoodsCount";
            this.gridColumnGoodsCount.MinWidth = 80;
            this.gridColumnGoodsCount.Name = "gridColumnGoodsCount";
            this.gridColumnGoodsCount.Visible = true;
            this.gridColumnGoodsCount.VisibleIndex = 4;
            this.gridColumnGoodsCount.Width = 80;
            // 
            // gridColumnReturnCount
            // 
            this.gridColumnReturnCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReturnCount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnReturnCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnReturnCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnReturnCount.Caption = "退货数量";
            this.gridColumnReturnCount.FieldName = "ReturnCount";
            this.gridColumnReturnCount.MinWidth = 80;
            this.gridColumnReturnCount.Name = "gridColumnReturnCount";
            this.gridColumnReturnCount.Visible = true;
            this.gridColumnReturnCount.VisibleIndex = 6;
            this.gridColumnReturnCount.Width = 80;
            // 
            // gridColumnGoodsAmount
            // 
            this.gridColumnGoodsAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnGoodsAmount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnGoodsAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnGoodsAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnGoodsAmount.Caption = "商品金额";
            this.gridColumnGoodsAmount.FieldName = "GoodsAmount";
            this.gridColumnGoodsAmount.MinWidth = 80;
            this.gridColumnGoodsAmount.Name = "gridColumnGoodsAmount";
            this.gridColumnGoodsAmount.Visible = true;
            this.gridColumnGoodsAmount.VisibleIndex = 5;
            this.gridColumnGoodsAmount.Width = 80;
            // 
            // gridColumnDiscountRate
            // 
            this.gridColumnDiscountRate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnDiscountRate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnDiscountRate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDiscountRate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDiscountRate.Caption = "折扣率";
            this.gridColumnDiscountRate.FieldName = "DiscountRate";
            this.gridColumnDiscountRate.MinWidth = 80;
            this.gridColumnDiscountRate.Name = "gridColumnDiscountRate";
            this.gridColumnDiscountRate.Width = 80;
            // 
            // gridColumnDiscountPrice
            // 
            this.gridColumnDiscountPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnDiscountPrice.AppearanceHeader.Options.UseFont = true;
            this.gridColumnDiscountPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDiscountPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDiscountPrice.Caption = "折后单价";
            this.gridColumnDiscountPrice.FieldName = "DiscountPrice";
            this.gridColumnDiscountPrice.MinWidth = 80;
            this.gridColumnDiscountPrice.Name = "gridColumnDiscountPrice";
            this.gridColumnDiscountPrice.Width = 80;
            // 
            // gridColumnDiscountAmount
            // 
            this.gridColumnDiscountAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnDiscountAmount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnDiscountAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDiscountAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDiscountAmount.Caption = "优惠金额（总）";
            this.gridColumnDiscountAmount.FieldName = "DiscountAmount";
            this.gridColumnDiscountAmount.MinWidth = 10;
            this.gridColumnDiscountAmount.Name = "gridColumnDiscountAmount";
            this.gridColumnDiscountAmount.Width = 105;
            // 
            // gridColumnSaleDate
            // 
            this.gridColumnSaleDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnSaleDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnSaleDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSaleDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSaleDate.Caption = "销售日期";
            this.gridColumnSaleDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumnSaleDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnSaleDate.FieldName = "SaleDate";
            this.gridColumnSaleDate.MaxWidth = 130;
            this.gridColumnSaleDate.MinWidth = 130;
            this.gridColumnSaleDate.Name = "gridColumnSaleDate";
            this.gridColumnSaleDate.Visible = true;
            this.gridColumnSaleDate.VisibleIndex = 7;
            this.gridColumnSaleDate.Width = 130;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(565, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 533);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImage")));
            this.groupControl2.Controls.Add(this.gridControlPos);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(563, 533);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "销售汇总";
            // 
            // gridControlPos
            // 
            this.gridControlPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPos.Location = new System.Drawing.Point(2, 39);
            this.gridControlPos.MainView = this.gridViewPos;
            this.gridControlPos.Name = "gridControlPos";
            this.gridControlPos.Size = new System.Drawing.Size(559, 492);
            this.gridControlPos.TabIndex = 0;
            this.gridControlPos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPos});
            this.gridControlPos.Click += new System.EventHandler(this.gridControlPos_Click);
            // 
            // gridViewPos
            // 
            this.gridViewPos.ColumnPanelRowHeight = 35;
            this.gridViewPos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colStoreID,
            this.colTicketCode,
            this.colSaleDate,
            this.colTotalAmount,
            this.colActualAmount,
            this.colDiscountAmount,
            this.gridColumn1,
            this.colPayType,
            this.colCashier,
            this.colRecordStatus,
            this.colRecordSerial});
            this.gridViewPos.GridControl = this.gridControlPos;
            this.gridViewPos.Name = "gridViewPos";
            this.gridViewPos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPos.OptionsBehavior.Editable = false;
            this.gridViewPos.OptionsBehavior.ReadOnly = true;
            this.gridViewPos.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPos.OptionsView.ShowFooter = true;
            this.gridViewPos.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridViewPos.OptionsView.ShowGroupPanel = false;
            this.gridViewPos.RowHeight = 35;
            this.gridViewPos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewPos_RowClick);
            this.gridViewPos.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewPos_RowStyle);
            this.gridViewPos.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewPos_CustomColumnDisplayText);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colStoreID
            // 
            this.colStoreID.AppearanceCell.Options.UseTextOptions = true;
            this.colStoreID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStoreID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStoreID.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStoreID.AppearanceHeader.Options.UseFont = true;
            this.colStoreID.AppearanceHeader.Options.UseTextOptions = true;
            this.colStoreID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStoreID.Caption = "门店编号";
            this.colStoreID.FieldName = "StoreID";
            this.colStoreID.MaxWidth = 70;
            this.colStoreID.MinWidth = 70;
            this.colStoreID.Name = "colStoreID";
            this.colStoreID.Visible = true;
            this.colStoreID.VisibleIndex = 0;
            this.colStoreID.Width = 70;
            // 
            // colTicketCode
            // 
            this.colTicketCode.AppearanceCell.Options.UseFont = true;
            this.colTicketCode.AppearanceCell.Options.UseTextOptions = true;
            this.colTicketCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTicketCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTicketCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colTicketCode.AppearanceHeader.Options.UseFont = true;
            this.colTicketCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colTicketCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTicketCode.Caption = "小票号";
            this.colTicketCode.FieldName = "TicketCode";
            this.colTicketCode.MinWidth = 140;
            this.colTicketCode.Name = "colTicketCode";
            this.colTicketCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TicketCode", "小票数：{0}")});
            this.colTicketCode.Visible = true;
            this.colTicketCode.VisibleIndex = 1;
            this.colTicketCode.Width = 140;
            // 
            // colSaleDate
            // 
            this.colSaleDate.AppearanceCell.Options.UseTextOptions = true;
            this.colSaleDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSaleDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSaleDate.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colSaleDate.AppearanceHeader.Options.UseFont = true;
            this.colSaleDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaleDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSaleDate.Caption = "销售日期";
            this.colSaleDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colSaleDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSaleDate.FieldName = "SaleDate";
            this.colSaleDate.MaxWidth = 130;
            this.colSaleDate.MinWidth = 130;
            this.colSaleDate.Name = "colSaleDate";
            this.colSaleDate.Visible = true;
            this.colSaleDate.VisibleIndex = 2;
            this.colSaleDate.Width = 130;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalAmount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colTotalAmount.AppearanceHeader.Options.UseFont = true;
            this.colTotalAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalAmount.Caption = "列表总价";
            this.colTotalAmount.DisplayFormat.FormatString = "n2";
            this.colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.MinWidth = 120;
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "合计:{0:n2}")});
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 3;
            this.colTotalAmount.Width = 120;
            // 
            // colActualAmount
            // 
            this.colActualAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colActualAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colActualAmount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colActualAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colActualAmount.AppearanceHeader.Options.UseFont = true;
            this.colActualAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colActualAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colActualAmount.Caption = "实收金额";
            this.colActualAmount.FieldName = "GoodsAmount";
            this.colActualAmount.MinWidth = 70;
            this.colActualAmount.Name = "colActualAmount";
            this.colActualAmount.Visible = true;
            this.colActualAmount.VisibleIndex = 4;
            this.colActualAmount.Width = 70;
            // 
            // colDiscountAmount
            // 
            this.colDiscountAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colDiscountAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDiscountAmount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiscountAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colDiscountAmount.AppearanceHeader.Options.UseFont = true;
            this.colDiscountAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscountAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscountAmount.Caption = "优惠金额";
            this.colDiscountAmount.FieldName = "DiscountAmount";
            this.colDiscountAmount.MinWidth = 70;
            this.colDiscountAmount.Name = "colDiscountAmount";
            this.colDiscountAmount.Visible = true;
            this.colDiscountAmount.VisibleIndex = 5;
            this.colDiscountAmount.Width = 70;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "找零";
            this.gridColumn1.FieldName = "ChangeAmount";
            this.gridColumn1.MinWidth = 75;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // colPayType
            // 
            this.colPayType.AppearanceCell.Options.UseTextOptions = true;
            this.colPayType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPayType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPayType.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colPayType.AppearanceHeader.Options.UseFont = true;
            this.colPayType.AppearanceHeader.Options.UseTextOptions = true;
            this.colPayType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPayType.Caption = "收款方式";
            this.colPayType.FieldName = "PayTypeName";
            this.colPayType.MaxWidth = 80;
            this.colPayType.MinWidth = 80;
            this.colPayType.Name = "colPayType";
            this.colPayType.Visible = true;
            this.colPayType.VisibleIndex = 7;
            this.colPayType.Width = 80;
            // 
            // colCashier
            // 
            this.colCashier.AppearanceCell.Options.UseTextOptions = true;
            this.colCashier.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCashier.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCashier.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colCashier.AppearanceHeader.Options.UseFont = true;
            this.colCashier.AppearanceHeader.Options.UseTextOptions = true;
            this.colCashier.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCashier.Caption = "收银员";
            this.colCashier.FieldName = "Cashier";
            this.colCashier.MinWidth = 80;
            this.colCashier.Name = "colCashier";
            this.colCashier.Visible = true;
            this.colCashier.VisibleIndex = 8;
            this.colCashier.Width = 80;
            // 
            // colRecordStatus
            // 
            this.colRecordStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colRecordStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colRecordStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRecordStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colRecordStatus.AppearanceHeader.Options.UseFont = true;
            this.colRecordStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecordStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecordStatus.Caption = "记录状态";
            this.colRecordStatus.FieldName = "RecordStatus";
            this.colRecordStatus.MaxWidth = 70;
            this.colRecordStatus.MinWidth = 70;
            this.colRecordStatus.Name = "colRecordStatus";
            this.colRecordStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRecordStatus.OptionsFilter.AllowAutoFilter = false;
            this.colRecordStatus.OptionsFilter.AllowFilter = false;
            this.colRecordStatus.Visible = true;
            this.colRecordStatus.VisibleIndex = 9;
            this.colRecordStatus.Width = 70;
            // 
            // colRecordSerial
            // 
            this.colRecordSerial.AppearanceCell.Options.UseTextOptions = true;
            this.colRecordSerial.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colRecordSerial.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRecordSerial.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colRecordSerial.AppearanceHeader.Options.UseFont = true;
            this.colRecordSerial.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecordSerial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecordSerial.Caption = "流水号";
            this.colRecordSerial.FieldName = "RecordSerial";
            this.colRecordSerial.MinWidth = 120;
            this.colRecordSerial.Name = "colRecordSerial";
            this.colRecordSerial.Visible = true;
            this.colRecordSerial.VisibleIndex = 10;
            this.colRecordSerial.Width = 120;
            // 
            // frmSaleList
            // 
            this.AcceptButton = this.btnQuerySale;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaleList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "销售列表";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTickno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPosDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPosDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTickno;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControlPosDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPosDetail;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraGrid.GridControl gridControlPos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPos;
        private DevExpress.XtraEditors.SimpleButton btnQuerySale;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordSerial;
        private DevExpress.XtraGrid.Columns.GridColumn colTicketCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colActualAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCashier;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPosID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBarID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGoodsCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGoodsCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGoodsAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscountPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscountAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSaleDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreID;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPayType;
        private DevExpress.XtraEditors.DateEdit dateEndTime;
        private DevExpress.XtraEditors.DateEdit dateStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReturnCount;
    }
}