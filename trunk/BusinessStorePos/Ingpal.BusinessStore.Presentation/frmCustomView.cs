using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmCustomView : Form
    {
        private Random random = new Random();
        private List<string> images = new List<string>();

        /// <summary>
        /// 图片展示委托
        /// </summary>
        ///<param name="fileName"></param>
        public delegate void PlayImageHandler(string fileName);

        private int index = 0;

        public bool IsRuning { get; private set; }

        public frmCustomView()
        {
            InitializeComponent();
            this.Left = Screen.GetBounds(this).Width;
            this.WindowState = FormWindowState.Maximized;
            images = Getbitmap();
            Thread thread = new Thread(new ThreadStart(image_play));
            IsRuning = true;
            thread.Start();
        }

        public List<string> Getbitmap()
        {

            var files = Directory.GetFiles("add").ToList();
            return files;
        }

        private void image_play()
        {
            while (IsRuning)
            {
                try
                {
                    GC.Collect();
                    var image_count = images.Count;
                    string ran_image = images[new Random().Next(0, image_count - 1)];
                    PlayImageHandler play = new PlayImageHandler(PlayImage);
                    this.Invoke(play, new object[] { ran_image, });
                    Thread.Sleep(6000);
                }
                catch (Exception exc)
                {

                }
            }
        }

        /// <summary>
        /// 播放图片
        /// </summary>     
        /// <param name="fileName"></param>
        private void PlayImage(string fileName)
        {
            try
            {
                if (fileName.LastIndexOf(".jpg") > 0 || fileName.LastIndexOf(".gif") > 0 || fileName.LastIndexOf(".png") > 0)
                {
                    Image backImage = new Bitmap(fileName);
                    this.pictureMain.Image = null;
                    this.pictureMain.Image = backImage;                
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

    }
}
