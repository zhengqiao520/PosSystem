using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Ingpal.BusinessStore.Model.DTO;
namespace Ingpal.BusinessStore.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService2”。
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        void GetUser(UserDTO userDto);

        [OperationContract]
        DataTable GetUser2(UserDTO userDto);

        [OperationContract]
        int InsertUser(UserDTO dto);
    }
}
