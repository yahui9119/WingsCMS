﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 表示用户领域的值的对象
    /// </summary>
    public class User:AggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// QQ账号
        /// </summary>
        public string QQ{get;set;}
        /// <summary>
        /// 阿里旺旺账号
        /// </summary>
        public string ALiWangWang{get;set;}
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public string LastloginTime { get; set; }
    }
}
