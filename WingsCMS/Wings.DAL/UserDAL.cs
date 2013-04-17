using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Model;
using System.Collections;

namespace Wings.DAL
{
    public class UserDAL
    {
        private readonly EntityControl<Users> control;

        public UserDAL()
        {
            control = CommonDatabaseOperation<Users>.Instance.GetEntityControl("Wings.Model");
        }
        //添加用户
        public int Add(Users user)
        {
            return control.SaveOrUpdate(user);
        }
        //修改用户
        public int Update(Users user)
        {
            return control.UpdateEntity(user);
        }
        //删除用户
        public int Delete(Users user)
        {
            return control.DeleteEntity(user);
        }
        //获取用户实体
        public IList GetUsers()
        {
            string sql = "From Wings.Model.Users";
            //var test= control.GetSQLEntities("SELECT [LogonId] as loginid,[Name] as name,[Password] as password,[EmailAddress] as emailaddress,[LastLogon] FROM [JustTest_DB].[dbo].[Users] GO",null);
            //return test;
            var test2= control.GetEntities(sql, null);
            return test2;
        }
        /// <summary>
        /// 获取用户 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="num"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList GetUsers(int pageIndex, int pageSize, out int num,Dictionary<string,string> where) 
        {
            string sql = "From Wings.Model.Users";
            return control.GetEntities(sql, where, pageIndex, pageSize, out num);
        }
        //获取一个用户实体
        public Users GetUserById(string id)
        {
            Dictionary<string, string> where = new Dictionary<string, string>();
            where.Add("UserId", id);
            return (Users)control.GetEntitie("From Wings.Model.Users where LogonId=:UserId", where);
        }
    }
}
