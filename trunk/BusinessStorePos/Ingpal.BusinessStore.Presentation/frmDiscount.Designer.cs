namespace Ingpal.BusinessStore.Presentation
{
    partial class frmDiscount
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
            this.txtDiscountRate = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.toggleSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtDiscoutMoney = new DevExpress.XtraEditors.ButtonEdit();
            this.txtDiscountPrice = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscoutMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.Location = new System.Drawing.Point(113, 93);
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.Properties.AutoHeight = false;
            this.txtDiscountRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)});
            this.txtDiscountRate.Properties.Mask.EditMask = "P2";
            this.txtDiscountRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscountRate.Properties.MaxLength = 10;
            this.txtDiscountRate.Size = new System.Drawing.Size(190, 30);
            this.txtDiscountRate.TabIndex = 0;
            this.txtDiscountRate.EditValueChanged += new System.EventHandler(this.txtDiscountRate_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(20, 98);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "折扣率：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(20, 200);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 19);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "折扣价：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(20, 152);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "折扣额：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(133, 236);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 36);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(227, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Location = new System.Drawing.Point(113, 26);
            this.toggleSwitch.Name = "toggleSwitch";
            this.toggleSwitch.Properties.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitch.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitch.Properties.AutoHeight = false;
            this.toggleSwitch.Properties.OffText = "单品打折";
            this.toggleSwitch.Properties.OnText = "整单打折";
            this.toggleSwitch.Size = new System.Drawing.Size(196, 48);
            this.toggleSwitch.TabIndex = 13;
            this.toggleSwitch.Toggled += new System.EventHandler(this.toggleSwitch_Toggled);
            // 
            // txtDiscoutMoney
            // 
            this.txtDiscoutMoney.Location = new System.Drawing.Point(112, 146);
            this.txtDiscoutMoney.Name = "txtDiscoutMoney";
            this.txtDiscoutMoney.Properties.AutoHeight = false;
            this.txtDiscoutMoney.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)});
            this.txtDiscoutMoney.Properties.Mask.EditMask = "f";
            this.txtDiscoutMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscoutMoney.Properties.MaxLength = 10;
            this.txtDiscoutMoney.Size = new System.Drawing.Size(190, 30);
            this.txtDiscoutMoney.TabIndex = 14;
            this.txtDiscoutMoney.EditValueChanged += new System.EventHandler(this.txtDiscoutMoney_EditValueChanged);
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Location = new System.Drawing.Point(113, 194);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Properties.AutoHeight = false;
            this.txtDiscountPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)});
            this.txtDiscountPrice.Properties.Mask.EditMask = "f";
            this.txtDiscountPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscountPrice.Properties.MaxLength = 10;
            this.txtDiscountPrice.Size = new System.Drawing.Size(190, 30);
            this.txtDiscountPrice.TabIndex = 15;
            this.txtDiscountPrice.EditValueChanged += new System.EventHandler(this.txtDiscountPrice_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtDiscountPrice);
            this.groupControl1.Controls.Add(this.txtDiscoutMoney);
            this.groupControl1.Controls.Add(this.toggleSwitch);
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnConfirm);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtDiscountRate);
            this.groupControl1.Location = new System.Drawing.Point(91, 59);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(363, 334);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "折扣";
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 468);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品折扣";
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscoutMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtDiscountRate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch;
        private DevExpress.XtraEditors.ButtonEdit txtDiscoutMoney;
        private DevExpress.XtraEditors.ButtonEdit txtDiscountPrice;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}