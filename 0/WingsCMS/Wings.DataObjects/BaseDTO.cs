using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Data
{
    [Serializable]
    public class BaseDTO
    {
        /// <summary>
        /// 唯一标示
        /// </summary>
        public Guid ID { get; set; }
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
        /// 版本号
        /// </summary>
        public byte[] Version { get; set; }
    }
}
