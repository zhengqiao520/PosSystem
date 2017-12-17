namespace Ingpal.BusinessStore.Presentation
{
    partial class frmGetHanding
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridRestPos = new DevExpress.XtraGrid.GridControl();
            this.gvRestPos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridGuider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSaleDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGetOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnFakeOrder = new DevExpress.XtraEditors.SimpleButton();
            this.grdGoods = new DevExpress.XtraGrid.GridControl();
            this.gvGoods = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PosActualAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PosSalesCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PosSalesAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StockQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridRestPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRestPos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRestPos
            // 
            this.gridRestPos.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridRestPos.Location = new System.Drawing.Point(0, 0);
            this.gridRestPos.MainView = this.gvRestPos;
            this.gridRestPos.Name = "gridRestPos";
            this.gridRestPos.Size = new System.Drawing.Size(484, 658);
            this.gridRestPos.TabIndex = 0;
            this.gridRestPos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRestPos});
            // 
            // gvRestPos
            // 
            this.gvRestPos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridGuider,
            this.gridTotalAmount,
            this.gridTotalCount,
            this.gridSaleDate});
            this.gvRestPos.GridControl = this.gridRestPos;
            this.gvRestPos.Name = "gvRestPos";
            this.gvRestPos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvRestPos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvRestPos.OptionsBehavior.Editable = false;
            this.gvRestPos.OptionsBehavior.ReadOnly = true;
            this.gvRestPos.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRestPos.OptionsView.ShowFooter = true;
            this.gvRestPos.OptionsView.ShowGroupPanel = false;
            this.gvRestPos.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gvRestPos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvRestPos_RowClick);
            this.gvRestPos.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRestPos_FocusedRowChanged);
            this.gvRestPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvRestPos_MouseDown);
            // 
            // gridGuider
            // 
            this.gridGuider.Caption = "导购";
            this.gridGuider.FieldName = "Guider";
            this.gridGuider.Name = "gridGuider";
            this.gridGuider.OptionsColumn.AllowEdit = false;
            this.gridGuider.OptionsColumn.ReadOnly = true;
            this.gridGuider.Visible = true;
            this.gridGuider.VisibleIndex = 0;
            // 
            // gridTotalAmount
            // 
            this.gridTotalAmount.Caption = "金额";
            this.gridTotalAmount.DisplayFormat.FormatString = "n2";
            this.gridTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridTotalAmount.FieldName = "TotalAmount";
            this.gridTotalAmount.Name = "gridTotalAmount";
            this.gridTotalAmount.OptionsColumn.ReadOnly = true;
            this.gridTotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "{0:n2}")});
            this.gridTotalAmount.Visible = true;
            this.gridTotalAmount.VisibleIndex = 1;
            // 
            // gridTotalCount
            // 
            this.gridTotalCount.Caption = "数量";
            this.gridTotalCount.FieldName = "TotalCount";
            this.gridTotalCount.Name = "gridTotalCount";
            this.gridTotalCount.OptionsColumn.ReadOnly = true;
            this.gridTotalCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCount", "{0:0.##}")});
            this.gridTotalCount.Visible = true;
            this.gridTotalCount.VisibleIndex = 2;
            // 
            // gridSaleDate
            // 
            this.gridSaleDate.Caption = "时间";
            this.gridSaleDate.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridSaleDate.FieldName = "SaleDate";
            this.gridSaleDate.Name = "gridSaleDate";
            this.gridSaleDate.OptionsColumn.AllowEdit = false;
            this.gridSaleDate.OptionsColumn.ReadOnly = true;
            this.gridSaleDate.Visible = true;
            this.gridSaleDate.VisibleIndex = 3;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(484, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 658);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGetOrder);
            this.panel2.Controls.Add(this.btnFakeOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(489, 584);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 74);
            this.panel2.TabIndex = 3;
            // 
            // btnGetOrder
            // 
            this.btnGetOrder.Location = new System.Drawing.Point(222, 17);
            this.btnGetOrder.Name = "btnGetOrder";
            this.btnGetOrder.Size = new System.Drawing.Size(75, 45);
            this.btnGetOrder.TabIndex = 1;
            this.btnGetOrder.Text = "取单";
            this.btnGetOrder.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFakeOrder
            // 
            this.btnFakeOrder.Location = new System.Drawing.Point(121, 17);
            this.btnFakeOrder.Name = "btnFakeOrder";
            this.btnFakeOrder.Size = new System.Drawing.Size(75, 45);
            this.btnFakeOrder.TabIndex = 0;
            this.btnFakeOrder.Text = "整单作废";
            this.btnFakeOrder.Click += new System.EventHandler(this.btn_Click);
            // 
            // grdGoods
            // 
            this.grdGoods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grdGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdGoods.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdGoods.Location = new System.Drawing.Point(489, 0);
            this.grdGoods.MainView = this.gvGoods;
            this.grdGoods.Name = "grdGoods";
            this.grdGoods.Size = new System.Drawing.Size(401, 584);
            this.grdGoods.TabIndex = 8;
            this.grdGoods.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGoods});
            // 
            // gvGoods
            // 
            this.gvGoods.Appearance.FooterPanel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.gvGoods.Appearance.FooterPanel.Options.UseFont = true;
            this.gvGoods.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridName,
            this.RetailPrice,
            this.PosActualAmount,
            this.PosSalesCount,
            this.PosSalesAmount,
            this.StockQuantity});
            this.gvGoods.GridControl = this.grdGoods;
            this.gvGoods.Name = "gvGoods";
            this.gvGoods.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvGoods.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvGoods.OptionsBehavior.Editable = false;
            this.gvGoods.OptionsBehavior.ReadOnly = true;
            this.gvGoods.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvGoods.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvGoods.OptionsView.ShowFooter = true;
            this.gvGoods.OptionsView.ShowGroupPanel = false;
            this.gvGoods.RowHeight = 35;
            // 
            // GridName
            // 
            this.GridName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.GridName.AppearanceHeader.Options.UseFont = true;
            this.GridName.AppearanceHeader.Options.UseTextOptions = true;
            this.GridName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridName.Caption = "商品名";
            this.GridName.FieldName = "Name";
            this.GridName.Name = "GridName";
            this.GridName.OptionsColumn.AllowEdit = false;
            this.GridName.OptionsColumn.ReadOnly = true;
            this.GridName.Visible = true;
            this.GridName.VisibleIndex = 0;
            // 
            // RetailPrice
            // 
            this.RetailPrice.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.RetailPrice.AppearanceHeader.Options.UseFont = true;
            this.RetailPrice.Caption = "单价";
            this.RetailPrice.DisplayFormat.FormatString = "n2";
            this.RetailPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RetailPrice.FieldName = "RetailPrice";
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.OptionsColumn.AllowEdit = false;
            this.RetailPrice.OptionsColumn.ReadOnly = true;
            this.RetailPrice.Visible = true;
            this.RetailPrice.VisibleIndex = 1;
            // 
            // PosActualAmount
            // 
            this.PosActualAmount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.PosActualAmount.AppearanceHeader.Options.UseFont = true;
            this.PosActualAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.PosActualAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PosActualAmount.Caption = "折扣价";
            this.PosActualAmount.FieldName = "DiscountPrice";
            this.PosActualAmount.Name = "PosActualAmount";
            this.PosActualAmount.OptionsColumn.ReadOnly = true;
            this.PosActualAmount.Visible = true;
            this.PosActualAmount.VisibleIndex = 2;
            // 
            // PosSalesCount
            // 
            this.PosSalesCount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.PosSalesCount.AppearanceHeader.Options.UseFont = true;
            this.PosSalesCount.AppearanceHeader.Options.UseTextOptions = true;
            this.PosSalesCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PosSalesCount.Caption = "数量";
            this.PosSalesCount.FieldName = "PosSalesCount";
            this.PosSalesCount.Name = "PosSalesCount";
            this.PosSalesCount.OptionsColumn.ReadOnly = true;
            this.PosSalesCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PosSalesCount", "{0}")});
            this.PosSalesCount.Visible = true;
            this.PosSalesCount.VisibleIndex = 3;
            // 
            // PosSalesAmount
            // 
            this.PosSalesAmount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.PosSalesAmount.AppearanceHeader.Options.UseFont = true;
            this.PosSalesAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.PosSalesAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PosSalesAmount.Caption = "金额";
            this.PosSalesAmount.DisplayFormat.FormatString = "n2";
            this.PosSalesAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PosSalesAmount.FieldName = "PosSalesAmount";
            this.PosSalesAmount.Name = "PosSalesAmount";
            this.PosSalesAmount.OptionsColumn.AllowEdit = false;
            this.PosSalesAmount.OptionsColumn.ReadOnly = true;
            this.PosSalesAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PosSalesAmount", "{0:n2}")});
            this.PosSalesAmount.Visible = true;
            this.PosSalesAmount.VisibleIndex = 4;
            // 
            // StockQuantity
            // 
            this.StockQuantity.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.StockQuantity.AppearanceHeader.Options.UseFont = true;
            this.StockQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.StockQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StockQuantity.Caption = "库存数";
            this.StockQuantity.DisplayFormat.FormatString = "n";
            this.StockQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.StockQuantity.FieldName = "StockQuantity";
            this.StockQuantity.Name = "StockQuantity";
            this.StockQuantity.OptionsColumn.ReadOnly = true;
            this.StockQuantity.Visible = true;
            this.StockQuantity.VisibleIndex = 5;
            // 
            // frmGetHanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 658);
            this.Controls.Add(this.grdGoods);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gridRestPos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGetHanding";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取回挂单";
            ((System.ComponentModel.ISupportInitialize)(this.gridRestPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRestPos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridRestPos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRestPos;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridGuider;
        private DevExpress.XtraGrid.Columns.GridColumn gridTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridSaleDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridTotalCount;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnGetOrder;
        private DevExpress.XtraEditors.SimpleButton btnFakeOrder;
        private DevExpress.XtraGrid.GridControl grdGoods;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGoods;
        private DevExpress.XtraGrid.Columns.GridColumn GridName;
        private DevExpress.XtraGrid.Columns.GridColumn RetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn PosActualAmount;
        private DevExpress.XtraGrid.Columns.GridColumn PosSalesCount;
        private DevExpress.XtraGrid.Columns.GridColumn PosSalesAmount;
        private DevExpress.XtraGrid.Columns.GridColumn StockQuantity;
    }
}