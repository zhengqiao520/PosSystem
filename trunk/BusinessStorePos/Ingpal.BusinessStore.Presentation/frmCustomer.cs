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
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Infrastructure.Win32;
using System.IO;
using System.Threading;
using Ingpal.BusinessStore.Model;
using static Ingpal.BusinessStore.Presentation.frmPos;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {
        private Random random = new Random();
        private List<string> images = new List<string>();
        private AnimationType[] animationTypes = null;

        /// <summary>
        /// 图片展示委托
        /// </summary>
        ///<param name="fileName"></param>
        public delegate void PlayImageHandler(string fileName);      

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, AnimationType dwFlags);
        private int index = 0;

        public bool IsRuning { get; private set; }

        public frmCustomer()
        {
            InitializeComponent();
            this.Left = Screen.GetBounds(this).Width;
            this.WindowState = FormWindowState.Maximized;
            images=Getbitmap();
            Thread thread = new Thread(new ThreadStart(image_play));
            IsRuning = true;
            thread.Start();
        }

        private AnimationType GetRandomAnimationType()
        {
            if (animationTypes == null)
            {
                animationTypes = Enum.GetValues(typeof(AnimationType))
                    as AnimationType[];
            }
            return animationTypes[random.Next(0, animationTypes.Length - 1)];
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
                GC.Collect();
                var image_count = images.Count;
                string ran_image = images[new Random().Next(0, image_count - 1)];
                PlayImageHandler play = new PlayImageHandler(PlayImage);
                this.Invoke(play, new object[] { ran_image, });
                Thread.Sleep(6000);   
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
                    this.BackgroundImage = null;
                    this.BackgroundImage = backImage;
                    this.BackgroundImageLayout = ImageLayout.Stretch;

                }

             
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRuning = false;
        }
    }
}