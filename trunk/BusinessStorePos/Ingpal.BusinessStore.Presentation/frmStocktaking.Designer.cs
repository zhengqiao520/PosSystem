namespace Ingpal.BusinessStore.Presentation
{
    partial class frmStocktaking
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStocktaking));
            this.colProductionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtProductCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.itemProgressBarAlarmount = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockTakingEnd = new DevExpress.XtraEditors.SimpleButton();
            this.btnStatistics = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockTakingStart = new DevExpress.XtraEditors.SimpleButton();
            this.txtNameAbbr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductName = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridStockTaking = new DevExpress.XtraGrid.GridControl();
            this.gridViewStockTaking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockTakingCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemSpinEditInventoryQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colDifferenceQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPictureIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.errorInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemProgressBarAlarmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAbbr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockTaking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStockTaking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSpinEditInventoryQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // colProductionDate
            // 
            this.colProductionDate.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colProductionDate.AppearanceHeader.Options.UseFont = true;
            this.colProductionDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductionDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductionDate.Caption = "生产日期";
            this.colProductionDate.FieldName = "ProductionDate";
            this.colProductionDate.MaxWidth = 80;
            this.colProductionDate.MinWidth = 80;
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.OptionsColumn.AllowEdit = false;
            this.colProductionDate.OptionsColumn.AllowFocus = false;
            this.colProductionDate.Width = 80;
            // 
            // txtProductCode
            // 
            this.txtProductCode.EditValue = "";
            this.errorInfo.SetIconAlignment(this.txtProductCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtProductCode.Location = new System.Drawing.Point(98, 59);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtProductCode.Properties.Appearance.Options.UseFont = true;
            this.txtProductCode.Properties.NullText = "扫码盘点";
            this.txtProductCode.Properties.NullValuePrompt = "扫码盘点";
            this.txtProductCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtProductCode.Size = new System.Drawing.Size(238, 30);
            this.txtProductCode.TabIndex = 5;
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(11, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 21);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "商品条码：";
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
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Location = new System.Drawing.Point(355, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 21);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "商品名称：";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.btnStockTakingEnd);
            this.groupControl1.Controls.Add(this.btnStatistics);
            this.groupControl1.Controls.Add(this.btnStockTakingStart);
            this.groupControl1.Controls.Add(this.txtNameAbbr);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtProductCode);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtProductName);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", ((System.Drawing.Image)(resources.GetObject("groupControl1.CustomHeaderButtons"))))});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1018, 164);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "库存盘点";
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(701, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 30);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "确定";
            this.btnSearch.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnStockTakingEnd
            // 
            this.btnStockTakingEnd.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStockTakingEnd.Appearance.Options.UseFont = true;
            this.btnStockTakingEnd.Location = new System.Drawing.Point(783, 123);
            this.btnStockTakingEnd.Name = "btnStockTakingEnd";
            this.btnStockTakingEnd.Size = new System.Drawing.Size(103, 32);
            this.btnStockTakingEnd.TabIndex = 3;
            this.btnStockTakingEnd.Text = "结束盘点";
            this.btnStockTakingEnd.Click += new System.EventHandler(this.btnStockTakingEnd_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStatistics.Appearance.Options.UseFont = true;
            this.btnStatistics.Location = new System.Drawing.Point(905, 123);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(103, 32);
            this.btnStatistics.TabIndex = 4;
            this.btnStatistics.Text = "盘点统计";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnStockTakingStart
            // 
            this.btnStockTakingStart.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStockTakingStart.Appearance.Options.UseFont = true;
            this.btnStockTakingStart.Location = new System.Drawing.Point(661, 123);
            this.btnStockTakingStart.Name = "btnStockTakingStart";
            this.btnStockTakingStart.Size = new System.Drawing.Size(103, 30);
            this.btnStockTakingStart.TabIndex = 1;
            this.btnStockTakingStart.Text = "开始盘点";
            this.btnStockTakingStart.Click += new System.EventHandler(this.btnStockTakingStart_Click);
            // 
            // txtNameAbbr
            // 
            this.txtNameAbbr.EditValue = "";
            this.errorInfo.SetIconAlignment(this.txtNameAbbr, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtNameAbbr.Location = new System.Drawing.Point(98, 109);
            this.txtNameAbbr.Name = "txtNameAbbr";
            this.txtNameAbbr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtNameAbbr.Properties.Appearance.Options.UseFont = true;
            this.txtNameAbbr.Properties.NullText = "简码盘点";
            this.txtNameAbbr.Properties.NullValuePrompt = "简码盘点";
            this.txtNameAbbr.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtNameAbbr.Size = new System.Drawing.Size(238, 30);
            this.txtNameAbbr.TabIndex = 6;
            this.txtNameAbbr.Visible = false;
            this.txtNameAbbr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameAbbr_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl3.Location = new System.Drawing.Point(11, 114);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 21);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "商品简码：";
            this.labelControl3.Visible = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(442, 61);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.txtProductName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtProductName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BarID", "条码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameAbbr", "简码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True)});
            this.txtProductName.Properties.DisplayMember = "GoodsName";
            this.txtProductName.Properties.NullText = "";
            this.txtProductName.Properties.ShowFooter = false;
            this.txtProductName.Properties.ValueMember = "ID";
            this.txtProductName.Properties.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.txtProductName_Properties_FormatEditValue);
            this.txtProductName.Size = new System.Drawing.Size(238, 30);
            this.txtProductName.TabIndex = 7;
            this.txtProductName.EditValueChanged += new System.EventHandler(this.txtProductName_EditValueChanged);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 768);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 173);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1018, 592);
            this.panelControl1.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.gridStockTaking);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1014, 588);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "库存信息";
            // 
            // gridStockTaking
            // 
            this.gridStockTaking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStockTaking.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gridStockTaking.Location = new System.Drawing.Point(2, 28);
            this.gridStockTaking.MainView = this.gridViewStockTaking;
            this.gridStockTaking.Name = "gridStockTaking";
            this.gridStockTaking.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemProgressBarAlarmount,
            this.itemPictureIcon,
            this.itemSpinEditInventoryQty});
            this.gridStockTaking.Size = new System.Drawing.Size(1010, 558);
            this.gridStockTaking.TabIndex = 0;
            this.gridStockTaking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStockTaking});
            // 
            // gridViewStockTaking
            // 
            this.gridViewStockTaking.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridViewStockTaking.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewStockTaking.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridViewStockTaking.Appearance.Row.Options.UseFont = true;
            this.gridViewStockTaking.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.gridViewStockTaking.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewStockTaking.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewStockTaking.ColumnPanelRowHeight = 35;
            this.gridViewStockTaking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colBarID,
            this.colName,
            this.colNameAbbr,
            this.colStockQuantity,
            this.colStockTakingCount,
            this.colDifferenceQty,
            this.colDiffAmount,
            this.colSPEC,
            this.colProductionDate});
            this.gridViewStockTaking.FooterPanelHeight = 35;
            this.gridViewStockTaking.GridControl = this.gridStockTaking;
            this.gridViewStockTaking.Name = "gridViewStockTaking";
            this.gridViewStockTaking.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStockTaking.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStockTaking.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewStockTaking.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewStockTaking.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gridViewStockTaking.OptionsView.ShowFooter = true;
            this.gridViewStockTaking.OptionsView.ShowGroupPanel = false;
            this.gridViewStockTaking.RowHeight = 35;
            this.gridViewStockTaking.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridViewStockTaking_CustomRowCellEdit);
            this.gridViewStockTaking.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridViewStockTaking_CustomSummaryCalculate);
            this.gridViewStockTaking.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewStockTaking_RowUpdated);
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
            this.colBarID.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colBarID.AppearanceHeader.Options.UseFont = true;
            this.colBarID.AppearanceHeader.Options.UseTextOptions = true;
            this.colBarID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBarID.Caption = "条码";
            this.colBarID.FieldName = "BarID";
            this.colBarID.MaxWidth = 100;
            this.colBarID.MinWidth = 100;
            this.colBarID.Name = "colBarID";
            this.colBarID.OptionsColumn.AllowEdit = false;
            this.colBarID.OptionsColumn.AllowFocus = false;
            this.colBarID.Visible = true;
            this.colBarID.VisibleIndex = 0;
            this.colBarID.Width = 100;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "商品名称";
            this.colName.FieldName = "GoodsName";
            this.colName.MaxWidth = 120;
            this.colName.MinWidth = 120;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 120;
            // 
            // colNameAbbr
            // 
            this.colNameAbbr.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colNameAbbr.AppearanceHeader.Options.UseFont = true;
            this.colNameAbbr.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameAbbr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameAbbr.Caption = "商品简写";
            this.colNameAbbr.FieldName = "NameAbbr";
            this.colNameAbbr.MaxWidth = 80;
            this.colNameAbbr.MinWidth = 80;
            this.colNameAbbr.Name = "colNameAbbr";
            this.colNameAbbr.OptionsColumn.AllowEdit = false;
            this.colNameAbbr.OptionsColumn.AllowFocus = false;
            this.colNameAbbr.Width = 80;
            // 
            // colStockQuantity
            // 
            this.colStockQuantity.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStockQuantity.AppearanceHeader.Options.UseFont = true;
            this.colStockQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStockQuantity.Caption = "库存数量";
            this.colStockQuantity.FieldName = "StockQuantity";
            this.colStockQuantity.MaxWidth = 80;
            this.colStockQuantity.MinWidth = 80;
            this.colStockQuantity.Name = "colStockQuantity";
            this.colStockQuantity.OptionsColumn.AllowEdit = false;
            this.colStockQuantity.OptionsColumn.AllowFocus = false;
            this.colStockQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockQuantity", "库存数:{0:0.##}")});
            this.colStockQuantity.Visible = true;
            this.colStockQuantity.VisibleIndex = 3;
            this.colStockQuantity.Width = 80;
            // 
            // colStockTakingCount
            // 
            this.colStockTakingCount.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colStockTakingCount.AppearanceHeader.Options.UseFont = true;
            this.colStockTakingCount.Caption = "盘点数量";
            this.colStockTakingCount.ColumnEdit = this.itemSpinEditInventoryQty;
            this.colStockTakingCount.FieldName = "InventoryQty";
            this.colStockTakingCount.MinWidth = 70;
            this.colStockTakingCount.Name = "colStockTakingCount";
            this.colStockTakingCount.OptionsColumn.AllowEdit = false;
            this.colStockTakingCount.OptionsColumn.AllowFocus = false;
            this.colStockTakingCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InventoryQty", "盘点数:{0:0.##}")});
            this.colStockTakingCount.Visible = true;
            this.colStockTakingCount.VisibleIndex = 3;
            // 
            // itemSpinEditInventoryQty
            // 
            this.itemSpinEditInventoryQty.AutoHeight = false;
            this.itemSpinEditInventoryQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemSpinEditInventoryQty.DisplayFormat.FormatString = "D";
            this.itemSpinEditInventoryQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.itemSpinEditInventoryQty.EditFormat.FormatString = "D";
            this.itemSpinEditInventoryQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.itemSpinEditInventoryQty.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.itemSpinEditInventoryQty.Mask.EditMask = "D";
            this.itemSpinEditInventoryQty.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.itemSpinEditInventoryQty.Name = "itemSpinEditInventoryQty";
            this.itemSpinEditInventoryQty.NullText = "0";
            // 
            // colDifferenceQty
            // 
            this.colDifferenceQty.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colDifferenceQty.AppearanceHeader.Options.UseFont = true;
            this.colDifferenceQty.Caption = "差异数量";
            this.colDifferenceQty.FieldName = "DifferenceQty";
            this.colDifferenceQty.Name = "colDifferenceQty";
            this.colDifferenceQty.OptionsColumn.AllowEdit = false;
            this.colDifferenceQty.OptionsColumn.AllowFocus = false;
            this.colDifferenceQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DifferenceQty", "差异数:{0:n2}")});
            this.colDifferenceQty.Visible = true;
            this.colDifferenceQty.VisibleIndex = 6;
            // 
            // colDiffAmount
            // 
            this.colDiffAmount.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colDiffAmount.AppearanceHeader.Options.UseFont = true;
            this.colDiffAmount.Caption = "差异金额";
            this.colDiffAmount.DisplayFormat.FormatString = "n2";
            this.colDiffAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiffAmount.FieldName = "DiffAmount";
            this.colDiffAmount.Name = "colDiffAmount";
            this.colDiffAmount.OptionsColumn.AllowEdit = false;
            this.colDiffAmount.OptionsColumn.AllowFocus = false;
            this.colDiffAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DiffAmount", "差异金额:{0:n2}")});
            this.colDiffAmount.Visible = true;
            this.colDiffAmount.VisibleIndex = 7;
            // 
            // colSPEC
            // 
            this.colSPEC.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colSPEC.AppearanceHeader.Options.UseFont = true;
            this.colSPEC.AppearanceHeader.Options.UseTextOptions = true;
            this.colSPEC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSPEC.Caption = "规格";
            this.colSPEC.FieldName = "SPEC";
            this.colSPEC.MaxWidth = 80;
            this.colSPEC.MinWidth = 80;
            this.colSPEC.Name = "colSPEC";
            this.colSPEC.OptionsColumn.AllowEdit = false;
            this.colSPEC.OptionsColumn.AllowFocus = false;
            this.colSPEC.Width = 80;
            // 
            // itemPictureIcon
            // 
            this.itemPictureIcon.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("itemPictureIcon.Appearance.Image")));
            this.itemPictureIcon.Appearance.Options.UseImage = true;
            this.itemPictureIcon.Name = "itemPictureIcon";
            // 
            // errorInfo
            // 
            this.errorInfo.ContainerControl = this;
            // 
            // frmStocktaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStocktaking";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "库存盘点";
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemProgressBarAlarmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAbbr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStockTaking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStockTaking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSpinEditInventoryQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colProductionDate;
        private DevExpress.XtraEditors.TextEdit txtProductCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;

        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar itemProgressBarAlarmount;

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridStockTaking;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStockTaking;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit itemPictureIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colBarID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSPEC;
        private DevExpress.XtraGrid.Columns.GridColumn colStockTakingCount;
        private DevExpress.XtraEditors.SimpleButton btnStockTakingStart;
        private DevExpress.XtraEditors.SimpleButton btnStockTakingEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemSpinEditInventoryQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDifferenceQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffAmount;
        private DevExpress.XtraEditors.LookUpEdit txtProductName;
        private DevExpress.XtraEditors.TextEdit txtNameAbbr;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorInfo;
        private DevExpress.XtraEditors.SimpleButton btnStatistics;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}