using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Domain.Events;
using Wings.Framework.Log;
using Wings.Framework.Utils;

namespace Wings.Events.Handlers
{
    /// <summary>
    /// 标示发送邮件的时间处理器
    /// </summary>
    [HandlesAsynchronously]
    public class SendEmailHandler : IEventHandler<UserForbiddenEvent>
    {
        /// <summary>
        /// 实例禁用用户事件
        /// </summary>
        /// <param name="evnt"></param>
        public void Handle(UserForbiddenEvent evnt)
        {
            try
            {


                Email.Send(evnt.UserEmail, "您的账号被禁用", string.Format("您的账号由于一些原因已经被管理员禁用，如果您有任何疑问请和管理员联系。{0}", evnt.ForbinddenDate));
            }
            catch (Exception ex)
            {
                new Log().Error(ex);
            }
        }
    }
}
