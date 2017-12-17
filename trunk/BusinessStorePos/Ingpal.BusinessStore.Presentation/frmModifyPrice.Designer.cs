namespace Ingpal.BusinessStore.Presentation
{
    partial class frmModifyPrice
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
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRetail = new DevExpress.XtraEditors.TextEdit();
            this.txtDiscountPrice = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(255, 31);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 81);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "修改";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(51, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "现   价";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(51, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "零售价";
            // 
            // txtRetail
            // 
            this.txtRetail.Location = new System.Drawing.Point(100, 32);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.Properties.AutoHeight = false;
            this.txtRetail.Properties.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(131, 27);
            this.txtRetail.TabIndex = 1;
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscountPrice.Location = new System.Drawing.Point(100, 80);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Properties.AutoHeight = false;
            this.txtDiscountPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDiscountPrice.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDiscountPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDiscountPrice.Size = new System.Drawing.Size(131, 27);
            this.txtDiscountPrice.TabIndex = 3;
            // 
            // frmModifyPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 144);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtRetail);
            this.Controls.Add(this.txtDiscountPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyPrice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改价格";
            ((System.ComponentModel.ISupportInitialize)(this.txtRetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtRetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SpinEdit txtDiscountPrice;
    }
}