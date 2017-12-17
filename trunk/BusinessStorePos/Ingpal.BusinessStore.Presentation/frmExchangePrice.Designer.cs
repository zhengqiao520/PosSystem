namespace Ingpal.BusinessStore.Presentation
{
    partial class frmExchangePrice
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
            this.grdExchangeGoods = new DevExpress.XtraGrid.GridControl();
            this.gvExchangeGoods = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PosActualAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StockQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdExchangeGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExchangeGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // grdExchangeGoods
            // 
            this.grdExchangeGoods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grdExchangeGoods.Dock = System.Windows.Forms.DockStyle.Top;
            gridLevelNode1.RelationName = "Level1";
            this.grdExchangeGoods.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdExchangeGoods.Location = new System.Drawing.Point(0, 0);
            this.grdExchangeGoods.MainView = this.gvExchangeGoods;
            this.grdExchangeGoods.Name = "grdExchangeGoods";
            this.grdExchangeGoods.Size = new System.Drawing.Size(566, 341);
            this.grdExchangeGoods.TabIndex = 9;
            this.grdExchangeGoods.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExchangeGoods});
            // 
            // gvExchangeGoods
            // 
            this.gvExchangeGoods.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.gvExchangeGoods.Appearance.FooterPanel.Options.UseFont = true;
            this.gvExchangeGoods.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridName,
            this.RetailPrice,
            this.PosActualAmount,
            this.StockQuantity});
            this.gvExchangeGoods.GridControl = this.grdExchangeGoods;
            this.gvExchangeGoods.Name = "gvExchangeGoods";
            this.gvExchangeGoods.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvExchangeGoods.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvExchangeGoods.OptionsBehavior.Editable = false;
            this.gvExchangeGoods.OptionsBehavior.ReadOnly = true;
            this.gvExchangeGoods.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvExchangeGoods.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvExchangeGoods.OptionsView.ShowGroupPanel = false;
            this.gvExchangeGoods.RowHeight = 35;
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
            this.GridName.Width = 292;
            // 
            // RetailPrice
            // 
            this.RetailPrice.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.RetailPrice.AppearanceHeader.Options.UseFont = true;
            this.RetailPrice.Caption = "原价";
            this.RetailPrice.DisplayFormat.FormatString = "n2";
            this.RetailPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RetailPrice.FieldName = "RetailPrice";
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.OptionsColumn.AllowEdit = false;
            this.RetailPrice.OptionsColumn.ReadOnly = true;
            this.RetailPrice.Visible = true;
            this.RetailPrice.VisibleIndex = 1;
            this.RetailPrice.Width = 94;
            // 
            // PosActualAmount
            // 
            this.PosActualAmount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.PosActualAmount.AppearanceHeader.Options.UseFont = true;
            this.PosActualAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.PosActualAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PosActualAmount.Caption = "换购价";
            this.PosActualAmount.FieldName = "ExchangePrice";
            this.PosActualAmount.Name = "PosActualAmount";
            this.PosActualAmount.OptionsColumn.ReadOnly = true;
            this.PosActualAmount.Visible = true;
            this.PosActualAmount.VisibleIndex = 2;
            this.PosActualAmount.Width = 78;
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
            this.StockQuantity.VisibleIndex = 3;
            this.StockQuantity.Width = 84;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(462, 347);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(97, 33);
            this.btnConfirm.TabIndex = 55;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(354, 347);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 33);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmExchangePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 390);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.grdExchangeGoods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExchangePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "可换购商品清单";
            this.Load += new System.EventHandler(this.frmExchangePrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdExchangeGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExchangeGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdExchangeGoods;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExchangeGoods;
        private DevExpress.XtraGrid.Columns.GridColumn GridName;
        private DevExpress.XtraGrid.Columns.GridColumn RetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn PosActualAmount;
        private DevExpress.XtraGrid.Columns.GridColumn StockQuantity;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}