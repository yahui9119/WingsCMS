﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{
    /// <summary>
    /// 数据列表分页数据信息
    /// </summary>
    /// <typeparam name="T">数据列表</typeparam>
    public class DataObjectListWithPagination<T> where T:List<BaseDTO>,new()
    {
        public DataObjectListWithPagination()
        {
            pagination = new Pagination();
            pagination.PageSize = 10;
            pagination.PageNumber = 1;
            DataObjectList = new T();;
        }
        /// <summary>
        /// 分页信息
        /// </summary>
        public Pagination pagination { get; set; }
        /// <summary>
        /// 数据列表
        /// </summary>
        public T DataObjectList { get; set; }
    }
}
