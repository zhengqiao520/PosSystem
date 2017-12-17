using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model.Entity;
using Ingpal.BusinessStore.Model;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Windows.Forms;
using Ingpal.BusinessStore.Business;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmMain : BaseForm
    {
        Timer time = new Timer();
        private WeatherAPIEntity wEntity = new WeatherAPIEntity();
        DateTime startTime;
        public frmMain()
        {
            InitializeComponent();
            InitEvent();
            startTime = DateTime.Now;
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            var sysTime = SysBLL.Instance.GetSysTime();
            var dt = string.IsNullOrEmpty(sysTime) ? DateTime.Now.ToString() : sysTime;
            lblTime.Text = $"当前时间：{dt}";
            TimeSpan tSpan = DateTime.Now - startTime;
            if (tSpan.Seconds == 3)
            {
                //GetGetWeather("上海");
            }
        }

        private void tile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

            var tile = sender as TileItem;
            var userRoleId = UserInfo.Instance.RoleId;
            switch (tile.Tag.ToString())
            {
                case "收银台":
                    if (!(userRoleId.IndexOf(BaseRoleConst.ShopManager) > -1 || userRoleId.IndexOf(BaseRoleConst.Crasher) > -1)) {
                        ShowMessage($"当前用户角色无操作{tile.Tag.ToString()}的权限！");
                        return;
                    }
                    new frmPos().Show(this);
                    break;
                case "库存查询":
                    new frmStockQuery().Show(this);
                    break;
                case "交接班":
                    new frmTransferWork().ShowDialog();
                    break;
                case "销售查询":
                    new frmSaleList().Show();
                    break;
                case "系统设置":
                    new frmSysConfig().ShowDialog();
                    break;
                case "库存盘点":
                    new frmStocktaking().Show();
                    break;
                case "商品入库":
                    new frmGoodsIn().ShowDialog();
                    break;
                case "退出系统":
                    AskExit();
                    break;
                case "商品出库":
                    new frmGoodsOutList().Show();
                    break;
                case "角色设置":
                    new frmEmployerMgmt().ShowDialog();
                    break;
                default:

                    break;
            }
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            var btn = e.Button as DevExpress.XtraBars.Docking2010.WindowsUIButton;
            if (btn.Caption.IndexOf("退出") > -1)
            {
                AskExit();
            }
            else if (btn.Caption.IndexOf("切换账号") > -1)
            {
                AskExit("您确认要切换账号吗?", () => Process.Start(Application.ExecutablePath));
            }
        }
        private void GetGetWeather(string cityName = "")
        {
            picWeather.SizeMode = PictureBoxSizeMode.StretchImage;
            wEntity = GetCityWeather(cityName);
            if (wEntity.data != null)
            {
                lblCity.Visible = true;
                lblTemputure.Visible = true;
                lblWeather.Visible = true;
                var data = wEntity.data.forecast[0];
                var type = data.@type;
                panelWeather.Visible = true;
                lblCity.Text = wEntity.data.city;
                lblWeather.Text = $"{data.@type}/{data.fengxiang}";
                lblTemputure.Text = data.high + "/" + data.low;
                if (type.IndexOf("多云") > -1 || type.IndexOf("晴") > -1)
                {
                    picWeather.Image = (Image)Properties.Resources.ResourceManager.GetObject("晴");
                }
                else if (type.IndexOf("雨") > -1)
                {
                    picWeather.Image = (Image)Properties.Resources.ResourceManager.GetObject("雨");
                }
                else if (type.IndexOf("阴") > -1)
                {
                    picWeather.Image = (Image)Properties.Resources.ResourceManager.GetObject("阴");
                }
                toolTip1.SetToolTip(picWeather, wEntity.data.ganmao);
            }
        }
        private static WeatherAPIEntity GetCityWeather(string cityName = "上海")
        {
            WeatherAPIEntity entity = new WeatherAPIEntity();
            try
            {
                System.Net.HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse("http://wthrcdn.etouch.cn/weather_mini?city=" + $"{HttpUtility.UrlEncode(cityName)}", null, null, null);
                string jsonString = HttpWebResponseUtility.getResponseString(response);
                entity = JsonConvert.DeserializeObject<WeatherAPIEntity>(jsonString);
            }
            catch { }
            return entity;
        }
        private void InitEvent()
        {
            this.picWeather.MouseHover += (o, s) => { toolTip1.UseAnimation = true; };
            lblNewWork.Text = $"网络状态：{(NetUtil.IsConnectInternet() ? "网络已连接" : "网络已断开")}";
            lblStoreName.Text += UserInfo.Instance.StoreName;
            if ((UserInfo.Instance.ExpectedAchievement ?? 0) > 0)
            {
                lbAchievement.Text = "业绩指标: " + UserInfo.Instance.ExpectedAchievement;
            }
            else
            {
                lbAchievement.Text = string.Empty;
            }
            time.Interval = 1000;
            time.Start();
            time.Tick += Time_Tick;
            tileRoleSetting.Visible = false;
         //   tileRoleSetting.Visible = IsShopManager;
        }
    }
}
