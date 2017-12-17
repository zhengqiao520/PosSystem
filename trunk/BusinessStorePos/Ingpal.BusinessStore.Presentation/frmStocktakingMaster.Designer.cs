namespace Ingpal.BusinessStore.Presentation
{
    partial class frmStocktakingMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStocktakingMaster));
            this.gridViewStockTaking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStockTaking = new DevExpress.XtraGrid.GridControl();
            this.gridViewStockTakingMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockRevise = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemStockRevise = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colReviseTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemProgressBarAlarmount = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.itemPictureIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.itemSpinEditInventoryQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdateStock = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStartTime1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStartTime2 = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStockTaking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockTaking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStockTakingMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStockRevise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemProgressBarAlarmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSpinEditInventoryQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime2.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewStockTaking
            // 
            this.gridViewStockTaking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.colStockID,
            this.colGoodsName,
            this.colNameAbbr,
            this.colBarID});
            this.gridViewStockTaking.GridControl = this.gridStockTaking;
            this.gridViewStockTaking.Name = "gridViewStockTaking";
            this.gridViewStockTaking.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStockTaking.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStockTaking.OptionsBehavior.Editable = false;
            this.gridViewStockTaking.OptionsBehavior.ReadOnly = true;
            this.gridViewStockTaking.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridViewStockTaking.OptionsView.ShowGroupPanel = false;
            this.gridViewStockTaking.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // colStockID
            // 
            this.colStockID.Caption = "StockID";
            this.colStockID.FieldName = "StockID";
            this.colStockID.Name = "colStockID";
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "名称";
            this.colGoodsName.FieldName = "GoodsName";
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 0;
            // 
            // colNameAbbr
            // 
            this.colNameAbbr.Caption = "简码";
            this.colNameAbbr.FieldName = "NameAbbr";
            this.colNameAbbr.Name = "colNameAbbr";
            this.colNameAbbr.Visible = true;
            this.colNameAbbr.VisibleIndex = 1;
            // 
            // colBarID
            // 
            this.colBarID.Caption = "条码";
            this.colBarID.FieldName = "BarID";
            this.colBarID.Name = "colBarID";
            this.colBarID.Visible = true;
            this.colBarID.VisibleIndex = 2;
            // 
            // gridStockTaking
            // 
            this.gridStockTaking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStockTaking.Font = new System.Drawing.Font("微软雅黑", 12F);
            gridLevelNode1.LevelTemplate = this.gridViewStockTaking;
            gridLevelNode1.RelationName = "Level1";
            this.gridStockTaking.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridStockTaking.Location = new System.Drawing.Point(2, 28);
            this.gridStockTaking.MainView = this.gridViewStockTakingMaster;
            this.gridStockTaking.Name = "gridStockTaking";
            this.gridStockTaking.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemProgressBarAlarmount,
            this.itemPictureIcon,
            this.itemSpinEditInventoryQty,
            this.itemStockRevise});
            this.gridStockTaking.Size = new System.Drawing.Size(1010, 553);
            this.gridStockTaking.TabIndex = 0;
            this.gridStockTaking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStockTakingMaster,
            this.gridViewStockTaking});
            // 
            // gridViewStockTakingMaster
            // 
            this.gridViewStockTakingMaster.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridViewStockTakingMaster.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewStockTakingMaster.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridViewStockTakingMaster.Appearance.Row.Options.UseFont = true;
            this.gridViewStockTakingMaster.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.gridViewStockTakingMaster.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewStockTakingMaster.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewStockTakingMaster.ChildGridLevelName = "gridViewStockTaking";
            this.gridViewStockTakingMaster.ColumnPanelRowHeight = 35;
            this.gridViewStockTakingMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colStoreName,
            this.colUserName,
            this.colNumber,
            this.colStartTime,
            this.colEndTime,
            this.colCount,
            this.colMoney,
            this.colStockRevise,
            this.colReviseTime,
            this.colStatus,
            this.colRemark});
            this.gridViewStockTakingMaster.FooterPanelHeight = 35;
            this.gridViewStockTakingMaster.GridControl = this.gridStockTaking;
            this.gridViewStockTakingMaster.Name = "gridViewStockTakingMaster";
            this.gridViewStockTakingMaster.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStockTakingMaster.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewStockTakingMaster.OptionsBehavior.Editable = false;
            this.gridViewStockTakingMaster.OptionsBehavior.ReadOnly = true;
            this.gridViewStockTakingMaster.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewStockTakingMaster.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewStockTakingMaster.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gridViewStockTakingMaster.OptionsView.ShowFooter = true;
            this.gridViewStockTakingMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewStockTakingMaster.RowHeight = 35;
            this.gridViewStockTakingMaster.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewStockTakingMaster_CustomColumnDisplayText);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colStoreName
            // 
            this.colStoreName.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStoreName.AppearanceHeader.Options.UseFont = true;
            this.colStoreName.Caption = "门店名称";
            this.colStoreName.FieldName = "StoreName";
            this.colStoreName.Name = "colStoreName";
            this.colStoreName.OptionsColumn.AllowEdit = false;
            this.colStoreName.OptionsColumn.AllowFocus = false;
            this.colStoreName.Visible = true;
            this.colStoreName.VisibleIndex = 2;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colUserName.AppearanceHeader.Options.UseFont = true;
            this.colUserName.Caption = "操作员";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.AllowFocus = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 3;
            // 
            // colNumber
            // 
            this.colNumber.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colNumber.AppearanceHeader.Options.UseFont = true;
            this.colNumber.Caption = "盘点编号";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.OptionsColumn.AllowFocus = false;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 4;
            // 
            // colStartTime
            // 
            this.colStartTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStartTime.AppearanceHeader.Options.UseFont = true;
            this.colStartTime.Caption = "开始时间";
            this.colStartTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.OptionsColumn.AllowEdit = false;
            this.colStartTime.OptionsColumn.AllowFocus = false;
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 0;
            // 
            // colEndTime
            // 
            this.colEndTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colEndTime.AppearanceHeader.Options.UseFont = true;
            this.colEndTime.Caption = "结束时间";
            this.colEndTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.OptionsColumn.AllowEdit = false;
            this.colEndTime.OptionsColumn.AllowFocus = false;
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 1;
            // 
            // colCount
            // 
            this.colCount.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colCount.AppearanceHeader.Options.UseFont = true;
            this.colCount.Caption = "差异数量";
            this.colCount.FieldName = "Count";
            this.colCount.Name = "colCount";
            this.colCount.OptionsColumn.AllowEdit = false;
            this.colCount.OptionsColumn.AllowFocus = false;
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 5;
            // 
            // colMoney
            // 
            this.colMoney.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colMoney.AppearanceHeader.Options.UseFont = true;
            this.colMoney.Caption = "差异金额";
            this.colMoney.FieldName = "Money";
            this.colMoney.Name = "colMoney";
            this.colMoney.OptionsColumn.AllowEdit = false;
            this.colMoney.OptionsColumn.AllowFocus = false;
            this.colMoney.Visible = true;
            this.colMoney.VisibleIndex = 6;
            // 
            // colStockRevise
            // 
            this.colStockRevise.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStockRevise.AppearanceHeader.Options.UseFont = true;
            this.colStockRevise.Caption = "调整库存";
            this.colStockRevise.ColumnEdit = this.itemStockRevise;
            this.colStockRevise.FieldName = "StockRevise";
            this.colStockRevise.Name = "colStockRevise";
            this.colStockRevise.OptionsColumn.AllowEdit = false;
            this.colStockRevise.OptionsColumn.AllowFocus = false;
            // 
            // itemStockRevise
            // 
            this.itemStockRevise.AutoHeight = false;
            this.itemStockRevise.Name = "itemStockRevise";
            // 
            // colReviseTime
            // 
            this.colReviseTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colReviseTime.AppearanceHeader.Options.UseFont = true;
            this.colReviseTime.Caption = "调整时间";
            this.colReviseTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colReviseTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colReviseTime.FieldName = "ReviseTime";
            this.colReviseTime.Name = "colReviseTime";
            this.colReviseTime.OptionsColumn.AllowEdit = false;
            this.colReviseTime.OptionsColumn.AllowFocus = false;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.Caption = "盘点状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowFocus = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.colRemark.AppearanceHeader.Options.UseFont = true;
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.OptionsColumn.AllowFocus = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 8;
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
            // itemPictureIcon
            // 
            this.itemPictureIcon.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("itemPictureIcon.Appearance.Image")));
            this.itemPictureIcon.Appearance.Options.UseImage = true;
            this.itemPictureIcon.Name = "itemPictureIcon";
            // 
            // itemSpinEditInventoryQty
            // 
            this.itemSpinEditInventoryQty.AutoHeight = false;
            this.itemSpinEditInventoryQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemSpinEditInventoryQty.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.itemSpinEditInventoryQty.Name = "itemSpinEditInventoryQty";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.gridStockTaking);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1014, 583);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "库存信息";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.btnUpdateStock);
            this.groupControl1.Controls.Add(this.txtNumber);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dateEditStartTime1);
            this.groupControl1.Controls.Add(this.dateEditStartTime2);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", ((System.Drawing.Image)(resources.GetObject("groupControl1.CustomHeaderButtons"))))});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1018, 169);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "盘点统计";
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnUpdateStock.Appearance.Options.UseFont = true;
            this.btnUpdateStock.Location = new System.Drawing.Point(582, 49);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(96, 32);
            this.btnUpdateStock.TabIndex = 26;
            this.btnUpdateStock.Text = "调整库存";
            this.btnUpdateStock.Visible = false;
            this.btnUpdateStock.Click += new System.EventHandler(this.Update_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(82, 52);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtNumber.Properties.Appearance.Options.UseFont = true;
            this.txtNumber.Size = new System.Drawing.Size(176, 28);
            this.txtNumber.TabIndex = 25;
            this.txtNumber.EditValueChanged += new System.EventHandler(this.Control_EditValueChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(353, 52);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(176, 28);
            this.txtUserName.TabIndex = 25;
            this.txtUserName.EditValueChanged += new System.EventHandler(this.Control_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl6.Location = new System.Drawing.Point(8, 56);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 21);
            this.labelControl6.TabIndex = 24;
            this.labelControl6.Text = "盘点编号:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Location = new System.Drawing.Point(293, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 21);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "—";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl5.Location = new System.Drawing.Point(293, 55);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 21);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "收银员:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(8, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 21);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "盘点时间:";
            // 
            // dateEditStartTime1
            // 
            this.dateEditStartTime1.EditValue = new System.DateTime(2017, 5, 17, 16, 31, 22, 0);
            this.dateEditStartTime1.Location = new System.Drawing.Point(82, 96);
            this.dateEditStartTime1.Name = "dateEditStartTime1";
            this.dateEditStartTime1.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dateEditStartTime1.Properties.Appearance.Options.UseFont = true;
            this.dateEditStartTime1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartTime1.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditStartTime1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartTime1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dateEditStartTime1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateEditStartTime1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStartTime1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateEditStartTime1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStartTime1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dateEditStartTime1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditStartTime1.Size = new System.Drawing.Size(205, 28);
            this.dateEditStartTime1.TabIndex = 23;
            this.dateEditStartTime1.EditValueChanged += new System.EventHandler(this.Control_EditValueChanged);
            // 
            // dateEditStartTime2
            // 
            this.dateEditStartTime2.EditValue = new System.DateTime(2017, 5, 17, 15, 16, 23, 0);
            this.dateEditStartTime2.Location = new System.Drawing.Point(317, 96);
            this.dateEditStartTime2.Name = "dateEditStartTime2";
            this.dateEditStartTime2.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dateEditStartTime2.Properties.Appearance.Options.UseFont = true;
            this.dateEditStartTime2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartTime2.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditStartTime2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartTime2.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dateEditStartTime2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateEditStartTime2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStartTime2.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateEditStartTime2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStartTime2.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dateEditStartTime2.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditStartTime2.Size = new System.Drawing.Size(212, 28);
            this.dateEditStartTime2.TabIndex = 23;
            this.dateEditStartTime2.EditValueChanged += new System.EventHandler(this.Control_EditValueChanged);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 768);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 178);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1018, 587);
            this.panelControl1.TabIndex = 2;
            // 
            // frmStocktakingMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStocktakingMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "盘点统计";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStockTaking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockTaking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStockTakingMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStockRevise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemProgressBarAlarmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSpinEditInventoryQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime2.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridStockTaking;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStockTakingMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemSpinEditInventoryQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar itemProgressBarAlarmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit itemPictureIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Columns.GridColumn colMoney;
        private DevExpress.XtraGrid.Columns.GridColumn colStockRevise;
        private DevExpress.XtraGrid.Columns.GridColumn colReviseTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.DateEdit dateEditStartTime2;
        private DevExpress.XtraEditors.DateEdit dateEditStartTime1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit itemStockRevise;
        private DevExpress.XtraEditors.SimpleButton btnUpdateStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStockTaking;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn colStockID;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colBarID;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreName;
    }
}