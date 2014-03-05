using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework.Config
{
    /// <summary>
    /// 表示对wings配置信息进行读取的单例类型
    /// </summary>
    public class WingsConfigurationReader
    {
        private readonly WingsConfigurationSection configuration;
        private static WingsConfigurationReader instance = new WingsConfigurationReader();
        public static WingsConfigurationReader Instance
        {
            get
            {
                return instance;
            }
        }
        static WingsConfigurationReader() { }
        private WingsConfigurationReader()
        {
            string EmailHost = WingsConfigurationSection.Instance.EmailClient.Host;

            this.configuration = WingsConfigurationSection.Instance;
            if (this.configuration == null)
            {
                throw new System.Configuration.ConfigurationErrorsException("当前应用程序的配置文件不存在与Wings相关的配置信息。");
            }
        }
        public int ProductsPerPage
        {
            get { return configuration.Pressentation.ProductsPageSize; }
        }
        #region  邮件相关
        public string EmailHost
        {
            get { return configuration.EmailClient.Host; }
        }
        public int EmailPort
        {
            get { return configuration.EmailClient.Port; }
        }
        public string EmailUserName
        {
            get { return configuration.EmailClient.UserName; }
        }
        public string EmailPassword
        {
            get { return configuration.EmailClient.Password; }
        }
        public string EmailSender
        {
            get { return configuration.EmailClient.Sender; }
        }
        public bool EmailEnableSsl
        {
            get
            {
                return configuration.EmailClient.EnableSsl;
            }
        }
        #endregion
        /// <summary>
        /// 获取一个<see cref="Boolean"/>值，该值表示指定的角色名称是否已在配置信息中注册。
        /// </summary>
        /// <param name="roleName">所需判断的角色名称。</param>
        /// <returns>如果指定的角色名称已经存在于配置信息中，则返回true，否则返回false。</returns>
        public bool RoleNameRegistered(string roleName)
        {
            
            foreach (PermissionkeyElement pke in this.configuration.PermissionKeys)
                if (pke.RoleName == roleName)
                    return true;
            return false;
        }
    }
}