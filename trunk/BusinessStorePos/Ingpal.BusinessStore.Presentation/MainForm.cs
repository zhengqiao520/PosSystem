using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using Ingpal.BusinessStore.Infrastructure;
using DevExpress.Utils.Design;

namespace Ingpal.BusinessStore.Presentation
{
    /// <summary>
    /// demo数据
    /// </summary>
    public partial class MainForm : BaseForm
    {
        SampleDataSource dataSource;
        Dictionary<SampleDataGroup, PageGroup> groupsItemDetailPage;
        public MainForm()
        {
            InitializeComponent();
            windowsUIView.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
            dataSource = new SampleDataSource();
            groupsItemDetailPage = new Dictionary<SampleDataGroup, PageGroup>();
            CreateLayout();
        }
        void CreateLayout()
        {
            foreach (SampleDataGroup group in dataSource.Data.Groups)
            {
                tileContainer.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton(group.Title, null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, group, -1, false, false));
                tileContainer.ButtonClick += TileContainer_ButtonClick;
                PageGroup pageGroup = new PageGroup();
                pageGroup.Parent = tileContainer;
                pageGroup.Caption = group.Title;
                foreach (SampleDataItem item in group.Items)
                {
                    ItemDetailPage itemDetailPage = new ItemDetailPage(item);
                    itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    pageGroup.Items.Add(document as Document);
                    CreateTile(document as Document, item);
                }
            }
            tileContainer.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton("重新登录", null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, dataSource.Data.Groups[0], -1, false, false));
        }

        private void TileContainer_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            var btn = e.Button as DevExpress.XtraBars.Docking2010.WindowsUIButton;
            if (btn.Caption.IndexOf("退出") > -1)
            {
                AskExit();
            }
            else if (btn.Caption.IndexOf("重新登录")>-1)
            {
                AskExit("您确认要重新登陆系统吗?", () => Process.Start(Application.ExecutablePath));
            }
        }

        Tile CreateTile(Document document, SampleDataItem item)
        {
            Tile tile = new Tile();
            tile.Group = item.GroupName;
            tile.Tag = item;
            var dataItem = (SampleDataItem)tile.Tag;
            tile.Name = dataItem.Subtitle;
            switch (dataItem.Subtitle) {
                case "交接班":
                    tile.Properties.ItemSize = TileItemSize.Wide;
                    tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.TopLeft, new Point(20, 50), 26));
                    tile.Elements.Add(new TileItemElement() { Image = ((Image)(Properties.Resources.ResourceManager.GetObject("ico-系统设置"))), ImageSize=new Size(64,64), ImageAlignment=TileItemContentAlignment.MiddleRight });
                    tile.Elements.Add(new TileItemElement() { Text = "进入快速销售收银", TextAlignment = TileItemContentAlignment.BottomLeft, TextLocation = new Point(20, -25) });
                    break;
                case "开始收银":
                    tile.Properties.ItemSize = TileItemSize.Large;
                    tile.Padding = new Padding(30);
                    tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.TopLeft, new Point(20, 50), 26));
                    tile.Elements.Add(new TileItemElement() {  Image = ((Image)(Properties.Resources.ResourceManager.GetObject("ico-系统设置"))), Height=32, Width=32, ImageSize = new Size(32, 32), ImageToTextAlignment = TileControlImageToTextAlignment.Right, ImageLocation=new Point(120,-50) });
                    tile.Elements.Add(new TileItemElement() { Text="进入快速销售收银",TextAlignment=TileItemContentAlignment.BottomLeft, TextLocation=new Point(20,-25)});
                    break;
                //case "系统设置":
                //    tile.Properties.ItemSize = TileItemSize.Wide;
                //    tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.TopLeft, new Point(20, 50), 26));
                //    tile.Elements.Add(new TileItemElement() { Image = ((Image)(Properties.Resources.ResourceManager.GetObject("ico-" + dataItem.Subtitle))), ImageSize = new Size(64, 64), ImageToTextAlignment = TileControlImageToTextAlignment.Default });
                //    tile.Elements.Add(new TileItemElement() { Text = "系统相关参数设置", TextAlignment = TileItemContentAlignment.BottomLeft, TextLocation = new Point(20, -25) });
                //    break;
                //case "退出系统":
                //    tile.Properties.ItemSize = TileItemSize.Medium;
                //    tile.Properties.ItemSize = TileItemSize.Wide;
                //    tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.TopLeft, new Point(20, 50), 26));
                //    tile.Elements.Add(new TileItemElement() { Image = ((Image)(Properties.Resources.ResourceManager.GetObject("ico-"+dataItem.Subtitle))), ImageSize = new Size(64, 64), ImageToTextAlignment=TileControlImageToTextAlignment.Default });
                //    tile.Elements.Add(new TileItemElement() { Text = "商品信息和库存信息查询", TextAlignment = TileItemContentAlignment.BottomLeft, TextLocation = new Point(20, -25) });
                //    break;
                //default:
                //    tile.Properties.ItemSize = TileItemSize.Wide;
                //    tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.TopLeft, new Point(20, 50), 26));
                //    tile.Elements.Add(new TileItemElement() { Image = ((Image)(Properties.Resources.ResourceManager.GetObject("ico-" + dataItem.Subtitle))), ImageSize = new Size(64, 64), ImageToTextAlignment = TileControlImageToTextAlignment.Default });
                //    tile.Elements.Add(new TileItemElement() { Text = "商品信息和库存信息查询", TextAlignment = TileItemContentAlignment.BottomLeft, TextLocation = new Point(20, -25) });
                //    break;
            }
            //tile.BackgroundImage = ((Image)(Properties.Resources.ResourceManager.GetObject("ico-"+dataItem.Subtitle)));
            item.Subtitle = string.Empty;
            //tile.Properties.BackgroundImageScaleMode = TileItemImageScaleMode.Default;
            tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.MiddleCenter, Point.Empty, 24));
            tile.Appearances.Selected.BackColor = tile.Appearances.Hovered.BackColor = tile.Appearances.Normal.BackColor = RandomColor;
            tile.Appearances.Selected.BorderColor = tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BorderColor = RandomColor;
            tile.Click += new TileClickEventHandler(tile_Click);
            //CreateAnimation(tile);
            tile.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            tileContainer.Items.Add(tile);
            return tile;
        }
        TileItemElement CreateTileItemElement(string text, TileItemContentAlignment alignment, Point location, float fontSize)
        {
            TileItemElement element = new TileItemElement();
            element.TextAlignment = alignment;
            if (!location.IsEmpty) element.TextLocation = location;
            element.Appearance.Normal.Options.UseFont = true;
            element.Appearance.Normal.Font = new Font(new FontFamily("微软雅黑"), fontSize);
            element.Text = text;
            return element;
        }
        void CreateAnimation(Tile tile)
        {
            TileItem newTile = new TileItem();
            //First Frame - Image only
            if (tile.Name == "开始收银")
            {
                TileItemFrame logoDXFrame = new TileItemFrame();
                TileItemElement logoEl = new TileItemElement();
                logoEl.Image = ((Image)(resources.GetObject(tile.Name)));
                logoEl.ImageScaleMode = TileItemImageScaleMode.Stretch;
                logoEl.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                logoDXFrame.Elements.Add(logoEl);
                logoDXFrame.Elements[0].AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
                logoDXFrame.Animation = TileItemContentAnimationType.SegmentedFade;
                tile.Frames.Add(logoDXFrame);
                //Second Frame - Text only
                TileItemFrame mottoDXFrame = new TileItemFrame();
                TileItemElement mottoEl = new TileItemElement();
                mottoEl.Text = "<Size=+24><Color=Sienna><b>葡萄科技</b></Color></Size>";
                mottoEl.TextAlignment = TileItemContentAlignment.MiddleCenter;
                mottoDXFrame.Elements.Add(mottoEl);
                mottoDXFrame.Animation = TileItemContentAnimationType.RandomSegmentedFade;
                mottoDXFrame.Elements[0].AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
                //Global Tile Item Settings
                tile.Frames.Add(mottoDXFrame);
                tile.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
                tile.Properties.FrameAnimationInterval = 3000;
                tileContainer.AllowAnimation(tile, true);
            }
            else if (tile.Name == "销售查询")
            {
                CrateTileElement(new TileItemElement
                {
                    Image = ((Image)(resources.GetObject(tile.Name))),
                    ImageScaleMode = TileItemImageScaleMode.Stretch,
                    ImageAlignment = TileItemContentAlignment.MiddleCenter
                }, tile);
                CrateTileElement(new TileItemElement
                {
                    Image = ((Image)(resources.GetObject(tile.Name))),
                    ImageScaleMode = TileItemImageScaleMode.Stretch,
                    ImageAlignment = TileItemContentAlignment.MiddleCenter
                }, tile, TileItemContentAnimationType.RandomSegmentedFade);
            }
        }
        private void CrateTileElement(TileItemElement element,Tile tile, TileItemContentAnimationType animationType=TileItemContentAnimationType.ScrollDown) {
            TileItemFrame dxFrame = new TileItemFrame();
            dxFrame.Elements.Add(element);
            dxFrame.Elements[0].AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
            dxFrame.Animation = animationType;
            tile.Frames.Add(dxFrame);
        }
        void tile_Click(object sender, TileClickEventArgs e)                    
        {
            var tile = sender as Tile;
            if (tile.Name == "开始收银")
            {
                new frmPos().Show();
            }
            if (tile.Name == "库存查询")
            {
                new frmStockQuery().Show();
            }
            if (tile.Name == "交接班")
            {
                new frmTransferWork().Show();
            }
            if (tile.Name == "销售查询") {
                new frmSaleList().Show(this);
            }
            if (tile.Name == "系统设置")
            {
                new frmSysConfig().Show(this);
            }
            if (tile.Name.Contains("退出")) {
                AskExit();
            }
        }
        PageGroup CreateGroupItemDetailPage(SampleDataGroup group, PageGroup child)
        {
            GroupDetailPage page = new GroupDetailPage(group, child);
            PageGroup pageGroup = page.PageGroup;
            BaseDocument document = windowsUIView.AddDocument(page);
            pageGroup.Parent = tileContainer;
            pageGroup.Items.Add(document as Document);
            windowsUIView.ContentContainers.Add(pageGroup);
            windowsUIView.ActivateContainer(pageGroup);
            return pageGroup;
        }
        public Color RandomColor
        {
            get
            {
                Random rnd = new Random();
                return Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.windowsUIView.BeginUpdate();
            this.tileContainer.Subtitle = DateTime.Now.ToString();
            //var tile = tileContainer.Items.ToList().Where(item => item.Name == "开始收银").First();
            //tile.Appearances.BeginUpdate();
            //TileItemElement el = tile.Elements[0];
            //el.Text = time;
            this.windowsUIView.EndUpdate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
