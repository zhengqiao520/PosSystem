namespace Ingpal.BusinessStore.Business
{
    using Ingpal.BusinessStore.Model.Entity;
    using Ingpal.BusinessStore.DataAccess;
    using System.Collections.Generic;
    using Model;

    public class MdmBLL
    {
        private MdmBLL() { }
        public static readonly MdmBLL Instance = new MdmBLL();
        private static List<MDMTypeSubEntity> _MDMSubList = null;
        private static readonly object syncRoot = new object();
        public List<MDMTypeSubEntity> MDMSubList {
            get
            {
                if(_MDMSubList == null)
                {
                    lock (syncRoot)
                    {
                        return SysBLL.Instance.GetALL<MDMTypeSubEntity>();
                    }
                }
                return _MDMSubList;
            }
        }
    }
}