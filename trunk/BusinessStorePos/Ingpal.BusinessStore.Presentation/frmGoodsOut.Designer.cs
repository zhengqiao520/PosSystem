namespace Ingpal.BusinessStore.Presentation
{
    partial class frmGoodsOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoodsOut));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboReciveStore = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grdGoodsOutList = new DevExpress.XtraGrid.GridControl();
            this.gvGoodsOutList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSearchGoods = new DevExpress.XtraEditors.SearchControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnRemoveRow = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOperator = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboGoosOutType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReciveStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGoodsOutList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGoodsOutList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchGoods.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGoosOutType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "D";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatString = "D";
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Mask.EditMask = "D";
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboReciveStore);
            this.groupControl1.Controls.Add(this.grdGoodsOutList);
            this.groupControl1.Controls.Add(this.txtSearchGoods);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtOperator);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cboGoosOutType);
            this.groupControl1.Controls.Add(this.txtRemark);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", ((System.Drawing.Image)(resources.GetObject("groupControl1.CustomHeaderButtons"))), -1, DevExpress.XtraEditors.ButtonPanel.ImageLocation.AfterText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, null, -1)});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(837, 458);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "商品出库";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 106);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "接收门店：";
            // 
            // cboReciveStore
            // 
            this.cboReciveStore.Location = new System.Drawing.Point(85, 99);
            this.cboReciveStore.Name = "cboReciveStore";
            this.cboReciveStore.Properties.AutoHeight = false;
            this.cboReciveStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReciveStore.Size = new System.Drawing.Size(316, 28);
            this.cboReciveStore.TabIndex = 74;
            // 
            // grdGoodsOutList
            // 
            this.grdGoodsOutList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGoodsOutList.Location = new System.Drawing.Point(9, 211);
            this.grdGoodsOutList.MainView = this.gvGoodsOutList;
            this.grdGoodsOutList.Name = "grdGoodsOutList";
            this.grdGoodsOutList.Size = new System.Drawing.Size(823, 193);
            this.grdGoodsOutList.TabIndex = 4;
            this.grdGoodsOutList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGoodsOutList});
            // 
            // gvGoodsOutList
            // 
            this.gvGoodsOutList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn16,
            this.gridColumn1,
            this.gridColumn24});
            this.gvGoodsOutList.GridControl = this.grdGoodsOutList;
            this.gvGoodsOutList.Name = "gvGoodsOutList";
            this.gvGoodsOutList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGoodsOutList.OptionsView.ShowGroupPanel = false;
            this.gvGoodsOutList.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvGoodsOutList_CustomRowCellEdit);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "商品名称";
            this.gridColumn13.FieldName = "Name";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            this.gridColumn13.Width = 100;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "成本价";
            this.gridColumn14.FieldName = "BuyingPrice";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Width = 74;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "出库数量";
            this.gridColumn16.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn16.DisplayFormat.FormatString = "D";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "OutQuantityStock";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutQuantityStock", "数量:{0:D}")});
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 74;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "库存数";
            this.gridColumn1.FieldName = "StockQuantity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 74;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "备注";
            this.gridColumn24.FieldName = "Remark";
            this.gridColumn24.Name = "gridColumn24";
            // 
            // txtSearchGoods
            // 
            this.txtSearchGoods.Location = new System.Drawing.Point(5, 144);
            this.txtSearchGoods.Name = "txtSearchGoods";
            this.txtSearchGoods.Properties.AutoHeight = false;
            this.txtSearchGoods.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton("search", 30, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, false, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Repository.MRUButton("combo", 30, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, false, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtSearchGoods.Properties.NullValuePrompt = "商品条码/商品名称";
            this.txtSearchGoods.Properties.ShowMRUButton = true;
            this.txtSearchGoods.Size = new System.Drawing.Size(826, 37);
            this.txtSearchGoods.TabIndex = 4;
            this.txtSearchGoods.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchGoods_KeyPress);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnRemoveRow);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Location = new System.Drawing.Point(3, 187);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(828, 266);
            this.groupControl2.TabIndex = 73;
            this.groupControl2.Text = "出库明细";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRow.Location = new System.Drawing.Point(623, 223);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(81, 35);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "删除选中行";
            this.btnRemoveRow.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(725, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "确认出库";
            this.btnSave.Click += new System.EventHandler(this.btn_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(460, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 71;
            this.labelControl2.Text = "备注：";
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(502, 55);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Properties.AutoHeight = false;
            this.txtOperator.Properties.ReadOnly = true;
            this.txtOperator.Size = new System.Drawing.Size(329, 28);
            this.txtOperator.TabIndex = 69;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(448, 62);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 70;
            this.labelControl6.Text = "操作人：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 68;
            this.labelControl1.Text = "出库类型：";
            // 
            // cboGoosOutType
            // 
            this.cboGoosOutType.Location = new System.Drawing.Point(85, 54);
            this.cboGoosOutType.Name = "cboGoosOutType";
            this.cboGoosOutType.Properties.AutoHeight = false;
            this.cboGoosOutType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGoosOutType.Size = new System.Drawing.Size(316, 28);
            this.cboGoosOutType.TabIndex = 67;
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "";
            this.txtRemark.Location = new System.Drawing.Point(502, 105);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(329, 27);
            this.txtRemark.TabIndex = 72;
            // 
            // frmGoodsOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 457);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGoodsOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品出库";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReciveStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGoodsOutList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGoodsOutList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchGoods.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGoosOutType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboGoosOutType;
        private DevExpress.XtraEditors.TextEdit txtOperator;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.SearchControl txtSearchGoods;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnRemoveRow;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grdGoodsOutList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGoodsOutList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboReciveStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
    }
}