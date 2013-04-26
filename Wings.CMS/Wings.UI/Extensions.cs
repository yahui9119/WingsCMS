using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings.UI
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
    public static class UiExtensions
    {
        public static void Raize(this Exception ex)
        {
            if (HttpContext.Current == null)
                ErrorLog.GetDefault(null).Log(new Error(ex));
            else
                ErrorSignal.FromCurrentContext().Raise(ex);
        }
    }
}