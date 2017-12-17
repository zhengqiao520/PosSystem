using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Presentation.Common
{
    /// <summary>
    /// 消息通知
    /// </summary>
    public static class Messager
    {
        /// <summary>
        /// 数据变更委托
        /// </summary>
        /// <param name="dataset">更改后的数据集</param>
        /// <param name="msgCode">消息标识</param>
        public delegate void DataChangedNotify(DataSet dataset, string msgCode);

        /// <summary>
        /// 当数据更改后
        /// </summary>
        public static event DataChangedNotify OnDataChanged;

        /// <summary>
        /// 给数据订阅者发送通知
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="msgCode">消息标识</param>
        public static void SendNotifyToSubscriber(DataSet data, string msgCode)
        {
            if (OnDataChanged != null)
            {
                OnDataChanged(data, msgCode);
            }
        }
    }

    /// <summary>
    /// 消息通知
    /// </summary>
    public static class Messager<T>
    {
        /// <summary>
        /// 数据变更委托
        /// </summary>
        /// <param name="model">更改后实体</param>
        /// <param name="msgCode">消息标识</param>
        public delegate void DataChangedNotify(T model, string msgCode);

        /// <summary>
        /// 当数据更改后
        /// </summary>
        public static event DataChangedNotify OnDataChanged;

        /// <summary>
        /// 给数据订阅者发送通知
        /// </summary>
        /// <param name="model">数据集</param>
        /// <param name="msgCode">消息标识</param>
        public static void SendNotifyToSubscriber(T model, string msgCode)
        {
            if (OnDataChanged != null)
            {
                OnDataChanged(model, msgCode);
            }
        }
    }
}
