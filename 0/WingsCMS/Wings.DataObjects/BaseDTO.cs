using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    [Serializable]
    public class BaseDTO
    {
        /// <summary>
        /// 唯一标示
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 创建者标示
        /// </summary>
        public Guid? Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime EditDate { get; set; }
        /// <summary>
        ///  状态
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 版本号 数据版本控制
        /// </summary>
        public byte[] Version { get; set; }
    }
    public enum Status:int
    {
        /// <summary>
        /// 已经删除
        /// </summary>
        Deleted=-1,
        /// <summary>
        /// 禁用，隐藏
        /// </summary>
        Forbidden=0,
        /// <summary>
        /// 正常使用
        /// </summary>
        Active=1,
        /// <summary>
        /// 未激活
        /// </summary>
        UnActivated=2
        
    }
}
