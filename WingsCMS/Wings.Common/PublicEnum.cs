using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Reflection;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Wings.Common.Cache;

namespace Wings.Common
{
    /// <summary>
    /// 创建目的：枚举类，列举一些枚举类型
    /// </summary>
    public class PublicEnum
    {
        /// <summary>
        /// 金钱类型：0银两 1绑定银两 2元宝 3绑定元宝 
        /// </summary>
        public enum TMoneyEnum
        {
            /// <summary>
            /// 0银两
            /// </summary>
            eMoney = 0,
            /// <summary>
            /// 1绑定银两
            /// </summary>
            eBindMoney = 1,
            /// <summary>
            /// 2元宝
            /// </summary>
            eYuanBao = 2,
            /// <summary>
            /// 3绑定元宝 
            /// </summary>
            eBindYuanBao = 3
        }
        /// <summary>
        /// 操作类型：0无 1产出 2流通 3消耗
        /// </summary>
        public enum TMoneyOperEnum
        {
            /// <summary>
            /// 0无
            /// </summary>
            eNone = 0,
            /// <summary>
            /// 1产出
            /// </summary>
            eProduce = 1,
            /// <summary>
            /// 2流通
            /// </summary>
            eCirculate = 2,
            /// <summary>
            /// 3消耗
            /// </summary>
            eExpend = 3
        }
    }
}
