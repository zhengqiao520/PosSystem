using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Infrastructure.Win32;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmEmployerMgmt : BaseForm
    {
        private List<UserRoleRealationView> userRelationView = new List<UserRoleRealationView>();
        public frmEmployerMgmt()
        {
            InitializeComponent();
            Load += FrmEmployerMgmt_Load;
        }

        private void FrmEmployerMgmt_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            UserInfo user = UserInfo.Instance;
            var userList = SysBLL.Instance.GetBy<UserEntity>(item => item.StoreID == user.StoreID && item.ID != user.ID);
            BindUtil.BindComboBoxEdit(cboUsers, userList, "RealName", "ID");
            var roleList = SysBLL.Instance.GetBy<BaseRoleEntity>(item => item.RecordStatus == RecordStatus.Normal && item.RoleName != "店长" && item.IsBackstage == false);
            BindUtil.BindComboBoxEdit(cboRoles, roleList, "RoleName", "ID");
            GetUserRoleList(user);
        }
        private void GetUserRoleList(UserInfo user)
        {
            userRelationView = SysBLL.Instance.GetBy<UserRoleRealationView>(item => item.StoreID == user.StoreID && !string.IsNullOrEmpty(item.RoleName));
            grdUserRole.DataSource = userRelationView;
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Close();
        }
        private void btn_click(object sender, EventArgs e)
        {
            int res = -1;
            var btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btnAdd":
                    var cboUserItem = cboUsers.EditValue as BindUtil.ComboBoxItem;
                    var cboRolesItem = cboRoles.EditValue as BindUtil.ComboBoxItem;
                    if (cboUserItem == null)
                    {
                        ShowMessage($"请选择门店员工后再设置角色！");
                        cboUsers.Focus();
                        return;
                    }
                    var baseRole = new UserRoleRelationEntity
                    {
                        ID = Guid.NewGuid(),
                        UserID = Guid.Parse(cboUserItem.Value),
                        BaseRoleID = Guid.Parse(cboRolesItem.Value),
                        RoleType = 1
                    };
                    res = SysBLL.Instance.CheckInsertUserRoleRelation(baseRole);
                    if (!(res > 0))
                    {
                        ShowMessage($"{cboUsers.Text}：不能为用户重复指定该角色！");
                        return;
                    }
                    GetUserRoleList(UserInfo.Instance);
                    UpdateRoleData(baseRole.UserID);
                    break;
                case "btnRemove":
                    var focusRow = gvUserRole.GetFocusedRow() as UserRoleRealationView;
                    if (focusRow != null)
                    {
                        if (focusRow.RoleName == "店长")
                        {
                            ShowMessage("您无删除店长角色权限！");
                            return;
                        }
                        SysBLL.Instance.DeteleByKey<UserRoleRelationEntity>(focusRow.UserRoleRelationID);
                        GetUserRoleList(UserInfo.Instance);
                        UpdateRoleData(focusRow.UserID);
                    }
                    break;
                case "btnModify":
                    if (!(gvUserRole.FocusedRowHandle > -1))
                    {
                        ShowMessage("请先选中左边列表中的用户角色！");
                        return;
                    }
                    if (cboRoles.EditValue == null)
                    {
                        ShowMessage("请从列表中选择用户角色！");
                        cboRoles.Focus();
                        return;
                    }
                    var selectedRow = gvUserRole.GetFocusedRow() as UserRoleRealationView;
                    res = SysBLL.Instance.UpDateUserRoleRelation(new UserRoleRelationEntity
                    {
                        BaseRoleID = Guid.Parse((cboRoles.EditValue as BindUtil.ComboBoxItem).Value),
                        ID = (Guid)selectedRow.UserRoleRelationID,
                        UserID = selectedRow.UserID
                    });
                    if (!(res > -1))
                    {
                        ShowMessage($"{selectedRow.RealName}：该用户角色已存在无法更新！");
                        return;
                    }
                    else if (res > 0)
                    {
                        ShowMessage($"角色更新成功！");
                        GetUserRoleList(UserInfo.Instance);
                        UpdateRoleData(selectedRow.UserID);
                    }
                    break;
            }
        }

        private void UpdateRoleData(Guid userGuid)
        {
            if (userRelationView != null && userRelationView.Any())
            {
                var userEntity = SysBLL.Instance.GetALL<UserEntity>().FirstOrDefault(s => s.ID == userGuid);
                if (userEntity != null)
                {
                    var userRelationViewQuery = userRelationView.Where(p => p.UserID == userGuid);
                    var roleID = userRelationViewQuery.Select(k => k.RoleID);
                    var roleName = userRelationViewQuery.Select(k => k.RoleName);
                    userEntity.RoleId = roleID.Any() ? string.Join(",", roleID.ToList()) : string.Empty;
                    userEntity.RoleName = roleName.Any() ? string.Join(",", roleName.ToList()) : string.Empty;
                    SysBLL.Instance.UpdateByKey(userEntity);
                }
            }
        }

        private void groupControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //WinAPI.ReleaseCapture();
            //WinAPI.SendMessage(this.Handle, WinAPI.WM_SYSCOMMAND, WinAPI.SC_MOVE + WinAPI.HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboRoles.EditValue == null)
            {
                ShowMessage("请选择用户角色!");
                cboRoles.Focus();
                return;
            }
            else if (cboUsers.EditValue == null)
            {
                ShowMessage("请选择用户!");
                cboUsers.Focus();
                return;
            }
            gvUserRole.AddNewRow();
        }

        private void gvUserRole_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            gridView.SetRowCellValue(e.RowHandle, "RealName", cboUsers.Text);
            gridView.SetRowCellValue(e.RowHandle, "UserID", cboUsers.EditValue);
            gridView.SetRowCellValue(e.RowHandle, "RoleName", cboRoles.Text);
            gridView.SetRowCellValue(e.RowHandle, "UserID", cboRoles.EditValue);
        }
    }
}