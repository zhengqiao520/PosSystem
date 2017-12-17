using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Presentation
{
   public class GridControl:DevExpress.XtraGrid.GridControl
    {
        private DevExpress.XtraGrid.GridControl grdControl;

        private void InitializeComponent()
        {
            this.grdControl = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdControl
            // 
            this.grdControl.Location = new System.Drawing.Point(0, 0);
            this.grdControl.MainView = null;
            this.grdControl.Name = "grdControl";
            this.grdControl.Size = new System.Drawing.Size(400, 200);
            this.grdControl.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
