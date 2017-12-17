using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.AutoUpdater
{
    public class AutoUpdaterInfo
    {
        public DateTime LastUpdateDate { get; set; }

        public DateTime ServerUpdateDate { get; set; }

        public string TargetPath { get; set; }

        public string LocalPath { get; set; }
    }
}
