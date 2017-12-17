using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Ingpal.BusinessStore.AutoUpdater
{
    public partial class Form1 : Form
    {

        private AutoUpdaterInfo updaterInfo = new AutoUpdaterInfo();
        private BackgroundWorker upgradeWorker;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

  

        private bool LoadUpdateInfo()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string xmlPath = Application.StartupPath + "\\Upgrade.xml";
                doc.Load(xmlPath);

                updaterInfo.TargetPath = doc.GetElementsByTagName("TargetPath").Item(0).InnerText;

                string lastUpgradeDate = doc.GetElementsByTagName("UpgradeDate").Item(0).InnerText;
                CultureInfo provider = CultureInfo.InvariantCulture;
                updaterInfo.LastUpdateDate = DateTime.ParseExact(lastUpgradeDate, "yyyy-MM-dd", provider);

                XmlDocument doc2 = new XmlDocument();
                doc2.Load(updaterInfo.TargetPath + "\\Upgrade.xml");

                string lastUpgradeDate2 = doc2.GetElementsByTagName("UpgradeDate").Item(0).InnerText;

                updaterInfo.ServerUpdateDate = DateTime.ParseExact(lastUpgradeDate2, "yyyy-MM-dd", provider);


                return true;
                


            }
            catch (Exception ex)
            {

                MessageBox.Show("缺少配置文件");
                this.Close();
            }
            return false;
        }

        private void UpdateUpgradedDate()
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = Application.StartupPath + "\\Upgrade.xml";
            doc.Load(xmlPath);

            XmlNode xn = doc.SelectSingleNode("AutoUpdater/UpgradeDate");
            XmlElement xe = (XmlElement)xn;
            xe.InnerText = updaterInfo.ServerUpdateDate.ToString("yyyy-MM-dd");
            doc.Save(xmlPath);

        }

        private void StartMainProcess()
        {
            var mainProcessPath = Application.StartupPath + @"\MainProcess\Ingpal.BusinessStore.Presentation.exe";
            Process.Start(mainProcessPath);

            this.Close();
        }
        private void CheckUpgrade()
        {
            if (updaterInfo.LastUpdateDate < updaterInfo.ServerUpdateDate)
            {
                this.updaterProgress.Visible = true;
                this.lbTip.Text = "更新中...";
                this.lbPercent.Visible = true;

                CloseExistsClients();
                DeleteCurrrentFiles();
                MoveFiles();
            }
            else
            {
                StartMainProcess();
            }

            
        }

        private void DeleteCurrrentFiles()
        {
            //DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\MainProcess");
            //FileInfo[] files = dir.GetFiles();
            //foreach (var item in files)
            //{
            //    File.Delete(item.FullName);
            //}
        }

        private void StartMoveFiles()
        {
            

            this.upgradeWorker = new BackgroundWorker();
            upgradeWorker.DoWork += UpgradeWorker_DoWork;
            upgradeWorker.RunWorkerCompleted += UpgradeWorker_RunWorkerCompleted;
            upgradeWorker.WorkerReportsProgress = true;
            upgradeWorker.ProgressChanged += UpgradeWorker_ProgressChanged;
            upgradeWorker.WorkerSupportsCancellation = true;
            upgradeWorker.RunWorkerAsync();
        }

        private void UpgradeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.updaterProgress.Value += 1;
            this.lbPercent.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        private void UpgradeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateUpgradedDate();
            StartMainProcess();
        }

        private void UpgradeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string localPath = Application.StartupPath + @"\MainProcess\";
                DirectoryInfo dir = new DirectoryInfo(this.updaterInfo.TargetPath);
                FileInfo[] files = dir.GetFiles();

                foreach (var item in files)
                {
                    File.Copy(item.FullName, localPath + item.Name, true);

                    int percentage = (int)(this.updaterProgress.Value * 100 / files.Length);
                    this.upgradeWorker.ReportProgress(percentage);
                }
            }
            catch (Exception ex)
            {

                this.upgradeWorker.CancelAsync();
                this.Close();
            }
            
        }

        private void MoveFiles()
        {

            string localPath = Application.StartupPath + @"\MainProcess\";
            DirectoryInfo dir = new DirectoryInfo(this.updaterInfo.TargetPath);
            FileInfo[] files = dir.GetFiles();
            this.updaterProgress.Maximum = files.Length;
            this.updaterProgress.Minimum = 0;
            this.updaterProgress.Value = 0;

            StartMoveFiles();

          

           
        }

        private void CloseExistsClients()
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName.Contains("Ingpal.BusinessStore.Presentation"))
                {
                    item.Kill();
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (LoadUpdateInfo())
            {
                CheckUpgrade();
            }
            else
            {
                this.Close();
            }
        }
    }
}
