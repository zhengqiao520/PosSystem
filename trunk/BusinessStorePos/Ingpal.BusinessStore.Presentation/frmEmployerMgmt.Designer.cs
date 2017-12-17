namespace Ingpal.BusinessStore.Presentation
{
    partial class frmEmployerMgmt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployerMgmt));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnModify = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.cboRoles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboUsers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdUserRole = new DevExpress.XtraGrid.GridControl();
            this.gvUserRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserRole)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", ((System.Drawing.Image)(resources.GetObject("groupControl1.CustomHeaderButtons"))))});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(590, 470);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "员工管理";
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            this.groupControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseDown);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnRemove);
            this.groupControl2.Controls.Add(this.btnModify);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.cboRoles);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.cboUsers);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.grdUserRole);
            this.groupControl2.Location = new System.Drawing.Point(7, 48);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(578, 417);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "用户角色信息";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(401, 330);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(158, 36);
            this.btnRemove.TabIndex = 73;
            this.btnRemove.Text = "删除用户角色";
            this.btnRemove.Click += new System.EventHandler(this.btn_click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(401, 274);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(158, 36);
            this.btnModify.TabIndex = 72;
            this.btnModify.Text = "修改用户角色";
            this.btnModify.Click += new System.EventHandler(this.btn_click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(401, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 36);
            this.btnAdd.TabIndex = 71;
            this.btnAdd.Text = "指定用户角色";
            this.btnAdd.Click += new System.EventHandler(this.btn_click);
            // 
            // cboRoles
            // 
            this.cboRoles.Location = new System.Drawing.Point(401, 150);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Properties.AutoHeight = false;
            this.cboRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoles.Size = new System.Drawing.Size(158, 28);
            this.cboRoles.TabIndex = 70;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(443, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 69;
            this.labelControl2.Text = "设置员工角色";
            // 
            // cboUsers
            // 
            this.cboUsers.Location = new System.Drawing.Point(401, 65);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Properties.AutoHeight = false;
            this.cboUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUsers.Size = new System.Drawing.Size(158, 28);
            this.cboUsers.TabIndex = 68;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(443, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "选择门店员工";
            // 
            // grdUserRole
            // 
            this.grdUserRole.Location = new System.Drawing.Point(5, 24);
            this.grdUserRole.MainView = this.gvUserRole;
            this.grdUserRole.Name = "grdUserRole";
            this.grdUserRole.Size = new System.Drawing.Size(383, 342);
            this.grdUserRole.TabIndex = 0;
            this.grdUserRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserRole});
            // 
            // gvUserRole
            // 
            this.gvUserRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6});
            this.gvUserRole.GridControl = this.grdUserRole;
            this.gvUserRole.GroupCount = 1;
            this.gvUserRole.Name = "gvUserRole";
            this.gvUserRole.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvUserRole.OptionsView.ShowGroupPanel = false;
            this.gvUserRole.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvUserRole.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvUserRole_InitNewRow);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "用户id";
            this.gridColumn4.FieldName = "UserID";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "用户编码";
            this.gridColumn5.FieldName = "UserCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "角色id";
            this.gridColumn3.FieldName = "RoleID";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户名";
            this.gridColumn1.FieldName = "RealName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "角色名";
            this.gridColumn2.FieldName = "RoleName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "用户角色关系主键";
            this.gridColumn6.FieldName = "UserRoleRelationID";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // frmEmployerMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 470);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployerMgmt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门店员工管理";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdUserRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserRole;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnModify;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoles;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboUsers;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}