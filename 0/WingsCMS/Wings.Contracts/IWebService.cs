using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wings.DataObjects;

namespace Wings.Contracts
{
    /// <summary>
    /// 标示 “站点” 服务的契约
    /// </summary>
    [ServiceContract(Name = "http://www.wings.com")]
    public interface IWebService
    {
        /// <summary>
        /// 添加一个新的站点
        /// </summary>
        /// <param name="webdto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void CreateWeb(WebDTO webdto);
        /// <summary>
        /// 编辑站点
        /// </summary>
        /// <param name="webdto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void EditWeb(WebDTO webdto);
        /// <summary>
        /// 删除一个现有站点
        /// </summary>
        /// <param name="webid"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteWeb(Guid webid);
        /// <summary>
        /// 获取使用此站点下的所有用户
        /// </summary>
        /// <param name="webid"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTOList GetUsersByWeb(Guid webid);
        /// <summary>
        /// 获取站点的分页
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        DataObjectListWithPagination<WebDTOList> GetWebsByPage(Pagination pagination);
        /// <summary>
        /// 该站点创建模块
        /// </summary>
        /// <param name="webid"></param>
        /// <param name="moduledto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void CreateModule(Guid webid,ModuleDTO moduledto);
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="moduledto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void EditModule(ModuleDTO moduledto);
        /// <summary>
        /// 删除一个模块
        /// </summary>
        /// <param name="webid"></param>
        /// <param name="moduleid"></param>
        void DeleteModule(Guid webid, Guid moduleid);
    }
}
