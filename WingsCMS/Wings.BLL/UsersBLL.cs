using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DAL;
using System.Collections;
using Wings.Model;

namespace Wings.BLL
{
    public class UsersBLL
    {
        private UserDAL dal;
        public UsersBLL()
        {
            dal = new UserDAL();
        }
        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <returns>IList</returns>
        public IList GetUsers()
        {
            return dal.GetUsers();
        }
        //删除用户
        public int DeleteUser(Users user)
        {
            return dal.Delete(user);
        }
        //修改用户
        public int Update(Users user)
        {
            return dal.Update(user);
        }
        //添加用户
        public int Add(Users user)
        {
            return dal.Add(user);
        }
        public Users GetUserById(string id)
        {
            return dal.GetUserById(id);
        }
    }
}
