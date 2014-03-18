using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wings.DataObjects;
using Wings.Framework.Infrastructure;
using Wings.Framework;

namespace Wings.Contracts
{
    /// <summary>
    /// 标示“用户相关的应用层服务契约”
    /// </summary>
    [ServiceContract(Name = "http://www.wings.com")]
    public interface IUserService : ICoreServiceContract
    {
        /// <summary>
        /// 验证用户名和密码是否在正确
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool CheckPassword(string UserName, string Password);
        /// <summary>
        /// 账号是否已经存在
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool IsExistsAccount(string Account);
        /// <summary>
        /// 添加一个新用户
        /// </summary>
        /// <param name="user"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTOList CreateUser(UserDTOList user);
        /// <summary>
        /// 编辑一个用户的个人信息
        /// </summary>
        /// <param name="user"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTOList EidtUser(UserDTOList user);
        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="UserID"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteUser(IDList UserIDs);
        /// <summary>
        /// 通过id获取一个用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTO GetUserByID(Guid UserID);
        /// <summary>
        /// 获取用户的分页
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        DataObjectListWithPagination<UserDTOList> GetUsersByPage(Pagination pagination);
        /// <summary>
        /// 获取所有用户已经拥有的模块
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ModuleDTOList GetUserPermission(Guid UserID);
        /// <summary>
        /// 分配特殊用户模块
        /// 已经拥有则不修改 没有则添加 原来有现在没有则标记取消授权
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="moduleids"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTO AssignUserPermission(Guid userid,IDList moduleids);

        #region 用户角色
        /// <summary>
        /// 创建一个角色
        /// </summary>
        /// <param name="role"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        RoleDTOList CreateRole(RoleDTOList role);
        /// <summary>
        /// 编辑一个角色
        /// </summary>
        /// <param name="role"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        RoleDTOList EditRole(RoleDTOList role);
        /// <summary>
        /// 删除一个角色 角色id
        /// </summary>
        /// <param name="roleid"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteRole(IDList roleid);
        /// <summary>
        /// 根据角色id获取所有该角色下的用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTOList GetUserListByRole(Guid roleid);
        /// <summary>
        /// 分配角色权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="moduleids"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        RoleDTO AssignRolePermission(Guid roleid, IDList moduleids);
        /// <summary>
        /// 获取角色的分页
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        DataObjectListWithPagination<RoleDTOList> GetRolesByPage(Pagination pagination);
        /// <summary>
        /// 重新分配给用户角色
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="roles">角色id</param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTO AssignUserRole(Guid userid,IDList roleids);
        #endregion
        #region 用户分组
        /// <summary>
        /// 分配给用户用户组
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="groupids">角色id列表</param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTO AssignUserGroup(Guid userid, IDList groupids);
        /// <summary>
        /// 添加一个新的分组
        /// </summary>
        /// <param name="group"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        GroupDTOList CreateGroup(GroupDTOList group);
        /// <summary>
        /// 编辑一个分组
        /// </summary>
        /// <param name="group"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        GroupDTOList EditGroup(GroupDTOList group);
        /// <summary>
        /// 删除一个分组
        /// </summary>
        /// <param name="groupid"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteGroup(IDList groupid);

        #endregion
    }
}
