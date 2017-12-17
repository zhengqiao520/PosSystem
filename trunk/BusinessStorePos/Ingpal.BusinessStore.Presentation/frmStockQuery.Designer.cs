namespace Ingpal.BusinessStore.Presentation
{
    partial class frmStockQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockQuery));
            this.gridViewStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPictureIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlarmAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductionPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colProductionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStock = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.itemProgressBarAlarmount = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnQueryStock = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpCategories = new DevExpress.XtraEditors.LookUpEdit();
            this.chkStoreWaring = new DevExpress.XtraEditors.CheckEdit();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtProductCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemProgressBarAlarmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCategories.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreWaring.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewStock
            // 
            this.gridViewStock.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridViewStock.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewStock.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridViewStock.Appearance.Row.Options.UseFont = true;
            this.gridViewStock.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.gridViewStock.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewStock.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewStock.ColumnPanelRowHeight = 35;
            this.gridViewStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnIcon,
            this.colID,
            this.colBarID,
            this.colStoreID,
            this.colName,
            this.colNameAbbr,
            this.colStockQuantity,
            this.colAlarmAmount,
            this.colRetailPrice,
            this.colCategory,
            this.colMemberPrice,
            this.colSaleQuantity,
            this.colSaleAmount,
            this.colDiscountRate,
            this.colUnit,
            this.colSupplier,
            this.colBatchNo,
            this.colModelNumber,
            this.colSPEC,
            this.colProductionPlace,
            this.colAllowDiscount,
            this.colProductionDate});
            this.gridViewStock.FooterPanelHeight = 35;
            this.gridViewStock.GridControl = this.gridStock;
            this.gridViewStock.Name = "gridViewStock";
            this.gridViewStock.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStock.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStock.OptionsBehavior.Editable = false;
            this.gridViewStock.OptionsBehavior.ReadOnly = true;
            this.gridViewStock.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewStock.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewStock.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gridViewStock.OptionsView.ShowFooter = true;
            this.gridViewStock.OptionsView.ShowGroupPanel = false;
            this.gridViewStock.RowHeight = 35;
            this.gridViewStock.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewStock_RowStyle);
            this.gridViewStock.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewStock_CustomUnboundColumnData);
            // 
            // gridColumnIcon
            // 
            this.gridColumnIcon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumnIcon.AppearanceHeader.Options.UseFont = true;
            this.gridColumnIcon.ColumnEdit = this.itemPictureIcon;
            this.gridColumnIcon.FieldName = "Image";
            this.gridColumnIcon.MaxWidth = 50;
            this.gridColumnIcon.MinWidth = 50;
            this.gridColumnIcon.Name = "gridColumnIcon";
            this.gridColumnIcon.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gridColumnIcon.Width = 50;
            // 
            // itemPictureIcon
            // 
            this.itemPictureIcon.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("itemPictureIcon.Appearance.Image")));
            this.itemPictureIcon.Appearance.Options.UseImage = true;
            this.itemPictureIcon.Name = "itemPictureIcon";
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colBarID
            // 
            this.colBarID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colBarID.AppearanceHeader.Options.UseFont = true;
            this.colBarID.AppearanceHeader.Options.UseTextOptions = true;
            this.colBarID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBarID.Caption = "条码";
            this.colBarID.FieldName = "BarID";
            this.colBarID.MaxWidth = 100;
            this.colBarID.MinWidth = 100;
            this.colBarID.Name = "colBarID";
            this.colBarID.Visible = true;
            this.colBarID.VisibleIndex = 1;
            this.colBarID.Width = 100;
            // 
            // colStoreID
            // 
            this.colStoreID.AppearanceCell.Options.UseTextOptions = true;
            this.colStoreID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStoreID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStoreID.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStoreID.AppearanceHeader.Options.UseFont = true;
            this.colStoreID.Caption = "门店编号";
            this.colStoreID.FieldName = "StoreID";
            this.colStoreID.MaxWidth = 80;
            this.colStoreID.MinWidth = 80;
            this.colStoreID.Name = "colStoreID";
            this.colStoreID.Visible = true;
            this.colStoreID.VisibleIndex = 0;
            this.colStoreID.Width = 80;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "商品名称";
            this.colName.FieldName = "Name";
            this.colName.MaxWidth = 250;
            this.colName.MinWidth = 120;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 120;
            // 
            // colNameAbbr
            // 
            this.colNameAbbr.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colNameAbbr.AppearanceHeader.Options.UseFont = true;
            this.colNameAbbr.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameAbbr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameAbbr.Caption = "商品简写";
            this.colNameAbbr.FieldName = "NameAbbr";
            this.colNameAbbr.MaxWidth = 80;
            this.colNameAbbr.MinWidth = 80;
            this.colNameAbbr.Name = "colNameAbbr";
            this.colNameAbbr.Width = 80;
            // 
            // colStockQuantity
            // 
            this.colStockQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colStockQuantity.AppearanceHeader.Options.UseFont = true;
            this.colStockQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStockQuantity.Caption = "库存数量";
            this.colStockQuantity.FieldName = "StockQuantity";
            this.colStockQuantity.MaxWidth = 80;
            this.colStockQuantity.MinWidth = 80;
            this.colStockQuantity.Name = "colStockQuantity";
            this.colStockQuantity.Visible = true;
            this.colStockQuantity.VisibleIndex = 4;
            this.colStockQuantity.Width = 80;
            // 
            // colAlarmAmount
            // 
            this.colAlarmAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAlarmAmount.AppearanceHeader.Options.UseFont = true;
            this.colAlarmAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAlarmAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAlarmAmount.Caption = "预警数量";
            this.colAlarmAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAlarmAmount.FieldName = "AlarmAmount";
            this.colAlarmAmount.MaxWidth = 80;
            this.colAlarmAmount.MinWidth = 80;
            this.colAlarmAmount.Name = "colAlarmAmount";
            this.colAlarmAmount.Visible = true;
            this.colAlarmAmount.VisibleIndex = 5;
            this.colAlarmAmount.Width = 80;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colRetailPrice.AppearanceHeader.Options.UseFont = true;
            this.colRetailPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colRetailPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRetailPrice.Caption = "零售价";
            this.colRetailPrice.FieldName = "RetailPrice";
            this.colRetailPrice.MaxWidth = 80;
            this.colRetailPrice.MinWidth = 80;
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.Visible = true;
            this.colRetailPrice.VisibleIndex = 6;
            this.colRetailPrice.Width = 80;
            // 
            // colCategory
            // 
            this.colCategory.AppearanceCell.Options.UseFont = true;
            this.colCategory.AppearanceCell.Options.UseTextOptions = true;
            this.colCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategory.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colCategory.AppearanceHeader.Options.UseFont = true;
            this.colCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.colCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategory.Caption = "商品类别";
            this.colCategory.FieldName = "Category";
            this.colCategory.MaxWidth = 80;
            this.colCategory.MinWidth = 80;
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            this.colCategory.Width = 80;
            // 
            // colMemberPrice
            // 
            this.colMemberPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colMemberPrice.AppearanceHeader.Options.UseFont = true;
            this.colMemberPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colMemberPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMemberPrice.Caption = "会员价";
            this.colMemberPrice.FieldName = "MemberPrice";
            this.colMemberPrice.MaxWidth = 80;
            this.colMemberPrice.MinWidth = 80;
            this.colMemberPrice.Name = "colMemberPrice";
            this.colMemberPrice.Width = 80;
            // 
            // colSaleQuantity
            // 
            this.colSaleQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colSaleQuantity.AppearanceHeader.Options.UseFont = true;
            this.colSaleQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaleQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSaleQuantity.Caption = "销售数量";
            this.colSaleQuantity.FieldName = "SaleQuantity";
            this.colSaleQuantity.MaxWidth = 80;
            this.colSaleQuantity.MinWidth = 80;
            this.colSaleQuantity.Name = "colSaleQuantity";
            this.colSaleQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleQuantity", "{0:n}")});
            this.colSaleQuantity.Width = 80;
            // 
            // colSaleAmount
            // 
            this.colSaleAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colSaleAmount.AppearanceHeader.Options.UseFont = true;
            this.colSaleAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaleAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSaleAmount.Caption = "销售金额";
            this.colSaleAmount.FieldName = "SaleAmount";
            this.colSaleAmount.MaxWidth = 100;
            this.colSaleAmount.MinWidth = 100;
            this.colSaleAmount.Name = "colSaleAmount";
            this.colSaleAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleAmount", "{0:n2}")});
            this.colSaleAmount.Width = 100;
            // 
            // colDiscountRate
            // 
            this.colDiscountRate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colDiscountRate.AppearanceHeader.Options.UseFont = true;
            this.colDiscountRate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscountRate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscountRate.Caption = "折扣率";
            this.colDiscountRate.FieldName = "DiscountRate";
            this.colDiscountRate.MaxWidth = 80;
            this.colDiscountRate.MinWidth = 80;
            this.colDiscountRate.Name = "colDiscountRate";
            this.colDiscountRate.Width = 80;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colUnit.AppearanceHeader.Options.UseFont = true;
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.Caption = "单位";
            this.colUnit.FieldName = "Unit";
            this.colUnit.MaxWidth = 80;
            this.colUnit.MinWidth = 80;
            this.colUnit.Name = "colUnit";
            this.colUnit.Width = 80;
            // 
            // colSupplier
            // 
            this.colSupplier.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colSupplier.AppearanceHeader.Options.UseFont = true;
            this.colSupplier.AppearanceHeader.Options.UseTextOptions = true;
            this.colSupplier.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplier.Caption = "供应商";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.MaxWidth = 200;
            this.colSupplier.MinWidth = 160;
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Width = 160;
            // 
            // colBatchNo
            // 
            this.colBatchNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colBatchNo.AppearanceHeader.Options.UseFont = true;
            this.colBatchNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colBatchNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBatchNo.Caption = "生产批号";
            this.colBatchNo.FieldName = "BatchNo";
            this.colBatchNo.MaxWidth = 80;
            this.colBatchNo.MinWidth = 80;
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.Width = 80;
            // 
            // colModelNumber
            // 
            this.colModelNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colModelNumber.AppearanceHeader.Options.UseFont = true;
            this.colModelNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colModelNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModelNumber.Caption = "型号";
            this.colModelNumber.FieldName = "ModelNumber";
            this.colModelNumber.MaxWidth = 80;
            this.colModelNumber.MinWidth = 80;
            this.colModelNumber.Name = "colModelNumber";
            this.colModelNumber.Width = 80;
            // 
            // colSPEC
            // 
            this.colSPEC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colSPEC.AppearanceHeader.Options.UseFont = true;
            this.colSPEC.AppearanceHeader.Options.UseTextOptions = true;
            this.colSPEC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSPEC.Caption = "规格";
            this.colSPEC.FieldName = "SPEC";
            this.colSPEC.MaxWidth = 80;
            this.colSPEC.MinWidth = 80;
            this.colSPEC.Name = "colSPEC";
            this.colSPEC.Width = 80;
            // 
            // colProductionPlace
            // 
            this.colProductionPlace.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colProductionPlace.AppearanceHeader.Options.UseFont = true;
            this.colProductionPlace.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductionPlace.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductionPlace.Caption = "产地";
            this.colProductionPlace.FieldName = "ProductionPlace";
            this.colProductionPlace.MaxWidth = 80;
            this.colProductionPlace.MinWidth = 80;
            this.colProductionPlace.Name = "colProductionPlace";
            this.colProductionPlace.Width = 80;
            // 
            // colAllowDiscount
            // 
            this.colAllowDiscount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAllowDiscount.AppearanceHeader.Options.UseFont = true;
            this.colAllowDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAllowDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllowDiscount.Caption = "是否允许打折";
            this.colAllowDiscount.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAllowDiscount.FieldName = "AllowDiscount";
            this.colAllowDiscount.MaxWidth = 80;
            this.colAllowDiscount.MinWidth = 80;
            this.colAllowDiscount.Name = "colAllowDiscount";
            this.colAllowDiscount.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "是";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colProductionDate
            // 
            this.colProductionDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colProductionDate.AppearanceHeader.Options.UseFont = true;
            this.colProductionDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductionDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductionDate.Caption = "生产日期";
            this.colProductionDate.FieldName = "ProductionDate";
            this.colProductionDate.MaxWidth = 80;
            this.colProductionDate.MinWidth = 80;
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.Width = 80;
            // 
            // gridStock
            // 
            this.gridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStock.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gridStock.Location = new System.Drawing.Point(2, 28);
            this.gridStock.MainView = this.gridViewStock;
            this.gridStock.Name = "gridStock";
            this.gridStock.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.itemProgressBarAlarmount,
            this.itemPictureIcon,
            this.repositoryItemImageEdit1});
            this.gridStock.Size = new System.Drawing.Size(949, 411);
            this.gridStock.TabIndex = 0;
            this.gridStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStock});
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // itemProgressBarAlarmount
            // 
            this.itemProgressBarAlarmount.AppearanceDisabled.BackColor = System.Drawing.Color.Red;
            this.itemProgressBarAlarmount.AppearanceFocused.BackColor = System.Drawing.Color.Red;
            this.itemProgressBarAlarmount.AppearanceReadOnly.BackColor = System.Drawing.Color.Red;
            this.itemProgressBarAlarmount.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.itemProgressBarAlarmount.AppearanceReadOnly.ForeColor2 = System.Drawing.SystemColors.HotTrack;
            this.itemProgressBarAlarmount.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.itemProgressBarAlarmount.EndColor = System.Drawing.Color.Red;
            this.itemProgressBarAlarmount.Name = "itemProgressBarAlarmount";
            this.itemProgressBarAlarmount.NullText = "0";
            this.itemProgressBarAlarmount.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.itemProgressBarAlarmount.ShowTitle = true;
            this.itemProgressBarAlarmount.StartColor = System.Drawing.Color.Transparent;
            this.itemProgressBarAlarmount.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.gridStock);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(953, 441);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "库存信息";
            // 
            // btnQueryStock
            // 
            this.btnQueryStock.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnQueryStock.Appearance.Options.UseFont = true;
            this.btnQueryStock.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQueryStock.Location = new System.Drawing.Point(734, 53);
            this.btnQueryStock.Name = "btnQueryStock";
            this.btnQueryStock.Size = new System.Drawing.Size(100, 32);
            this.btnQueryStock.TabIndex = 15;
            this.btnQueryStock.Text = "查询";
            this.btnQueryStock.Visible = false;
            this.btnQueryStock.Click += new System.EventHandler(this.btnQueryStock_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Location = new System.Drawing.Point(251, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 21);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "商品名称：";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.lookUpCategories);
            this.groupControl1.Controls.Add(this.chkStoreWaring);
            this.groupControl1.Controls.Add(this.txtProductName);
            this.groupControl1.Controls.Add(this.btnQueryStock);
            this.groupControl1.Controls.Add(this.txtProductCode);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", ((System.Drawing.Image)(resources.GetObject("groupControl1.CustomHeaderButtons"))))});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(957, 114);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "查询条件";
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            // 
            // lookUpCategories
            // 
            this.lookUpCategories.EditValue = 0;
            this.lookUpCategories.Location = new System.Drawing.Point(579, 54);
            this.lookUpCategories.Name = "lookUpCategories";
            this.lookUpCategories.Properties.AutoHeight = false;
            this.lookUpCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCategories.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "商品类别")});
            this.lookUpCategories.Properties.NullText = "";
            this.lookUpCategories.Properties.ShowFooter = false;
            this.lookUpCategories.Properties.ShowHeader = false;
            this.lookUpCategories.Size = new System.Drawing.Size(148, 30);
            this.lookUpCategories.TabIndex = 21;
            this.lookUpCategories.EditValueChanged += new System.EventHandler(this.txtProductCode_EditValueChanged);
            // 
            // chkStoreWaring
            // 
            this.chkStoreWaring.EditValue = true;
            this.chkStoreWaring.Location = new System.Drawing.Point(847, 58);
            this.chkStoreWaring.Name = "chkStoreWaring";
            this.chkStoreWaring.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chkStoreWaring.Properties.Appearance.Options.UseFont = true;
            this.chkStoreWaring.Properties.Caption = "库存预警";
            this.chkStoreWaring.Size = new System.Drawing.Size(101, 25);
            this.chkStoreWaring.TabIndex = 20;
            this.chkStoreWaring.CheckedChanged += new System.EventHandler(this.chkStoreWaring_CheckedChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(337, 54);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Size = new System.Drawing.Size(150, 30);
            this.txtProductName.TabIndex = 16;
            this.txtProductName.EditValueChanged += new System.EventHandler(this.txtProductCode_EditValueChanged);
            // 
            // txtProductCode
            // 
            this.txtProductCode.EditValue = "";
            this.txtProductCode.Location = new System.Drawing.Point(95, 54);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtProductCode.Properties.Appearance.Options.UseFont = true;
            this.txtProductCode.Size = new System.Drawing.Size(150, 30);
            this.txtProductCode.TabIndex = 9;
            this.txtProductCode.EditValueChanged += new System.EventHandler(this.txtProductCode_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(9, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 21);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "商品编号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl3.Location = new System.Drawing.Point(493, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 21);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "商品类别：";
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 571);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 123);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(957, 445);
            this.panelControl1.TabIndex = 2;
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // gridView3
            // 
            this.gridView3.Name = "gridView3";
            // 
            // frmStockQuery
            // 
            this.AcceptButton = this.btnQueryStock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存查询";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemProgressBarAlarmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCategories.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreWaring.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStock;
        private DevExpress.XtraGrid.GridControl gridStock;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnQueryStock;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtProductCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.CheckEdit chkStoreWaring;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colBarID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colBatchNo;
        private DevExpress.XtraGrid.Columns.GridColumn colModelNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSPEC;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colAlarmAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowDiscount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar itemProgressBarAlarmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit itemPictureIcon;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreID;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraEditors.LookUpEdit lookUpCategories;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}