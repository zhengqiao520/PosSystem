namespace Ingpal.BusinessStore.Presentation
{
    partial class frmSysConfig
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
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.chkShowCustomerPlay = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPasswordConfirm = new DevExpress.XtraEditors.TextEdit();
            this.txtPassordOld = new DevExpress.XtraEditors.TextEdit();
            this.txtPasswordNew = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowCustomerPlay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassordOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlMain
            // 
            this.groupControlMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControlMain.AppearanceCaption.Options.UseFont = true;
            this.groupControlMain.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControlMain.CaptionImage = global::Ingpal.BusinessStore.Presentation.Properties.Resources.technology_32x32;
            this.groupControlMain.Controls.Add(this.groupControl4);
            this.groupControlMain.Controls.Add(this.groupControl3);
            this.groupControlMain.Controls.Add(this.btnClose);
            this.groupControlMain.Location = new System.Drawing.Point(0, 0);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(252, 347);
            this.groupControlMain.TabIndex = 0;
            this.groupControlMain.Text = "系统设置";
            this.groupControlMain.Click += new System.EventHandler(this.FrmSysConfig_Load);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.chkShowCustomerPlay);
            this.groupControl4.Location = new System.Drawing.Point(255, 42);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(235, 300);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "客显管理";
            // 
            // chkShowCustomerPlay
            // 
            this.chkShowCustomerPlay.Location = new System.Drawing.Point(5, 41);
            this.chkShowCustomerPlay.Name = "chkShowCustomerPlay";
            this.chkShowCustomerPlay.Properties.Caption = "显示客显";
            this.chkShowCustomerPlay.Size = new System.Drawing.Size(136, 19);
            this.chkShowCustomerPlay.TabIndex = 0;
            this.chkShowCustomerPlay.CheckedChanged += new System.EventHandler(this.chkShowCustomerPlay_CheckedChanged);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.simpleButton2);
            this.groupControl3.Controls.Add(this.simpleButton1);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.txtPasswordConfirm);
            this.groupControl3.Controls.Add(this.txtPassordOld);
            this.groupControl3.Controls.Add(this.txtPasswordNew);
            this.groupControl3.Location = new System.Drawing.Point(2, 42);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(244, 300);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "密码管理";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(63, 154);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "修改";
            this.simpleButton2.Click += new System.EventHandler(this.btnChanged_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(155, 154);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "原密码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(34, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "新密码：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "确认新密码：";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.EditValue = "";
            this.txtPasswordConfirm.Location = new System.Drawing.Point(92, 108);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPasswordConfirm.Properties.Appearance.Options.UseFont = true;
            this.txtPasswordConfirm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPasswordConfirm.Properties.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(138, 22);
            this.txtPasswordConfirm.TabIndex = 0;
            // 
            // txtPassordOld
            // 
            this.txtPassordOld.EditValue = "";
            this.txtPassordOld.Location = new System.Drawing.Point(92, 38);
            this.txtPassordOld.Name = "txtPassordOld";
            this.txtPassordOld.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPassordOld.Properties.Appearance.Options.UseFont = true;
            this.txtPassordOld.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassordOld.Properties.PasswordChar = '*';
            this.txtPassordOld.Size = new System.Drawing.Size(138, 22);
            this.txtPassordOld.TabIndex = 0;
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.EditValue = "";
            this.txtPasswordNew.Location = new System.Drawing.Point(92, 74);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPasswordNew.Properties.Appearance.Options.UseFont = true;
            this.txtPasswordNew.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPasswordNew.Properties.PasswordChar = '*';
            this.txtPasswordNew.Size = new System.Drawing.Size(138, 22);
            this.txtPasswordNew.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnClose.Image = global::Ingpal.BusinessStore.Presentation.Properties.Resources.delete_32x32;
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClose.Location = new System.Drawing.Point(458, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 349);
            this.ControlBox = false;
            this.Controls.Add(this.groupControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShowCustomerPlay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassordOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNew.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.CheckEdit chkShowCustomerPlay;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPasswordConfirm;
        private DevExpress.XtraEditors.TextEdit txtPassordOld;
        private DevExpress.XtraEditors.TextEdit txtPasswordNew;
    }
}