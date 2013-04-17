using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Collections;
using System.Data;
using NHibernate.Criterion;

namespace Wings.DLL
{
        public class EntityControl<T>
        {
            #region 私有变量
            private ISession session;
            #endregion

            #region 内部成员变量
            private string _assemblyName;
            private string _nhibernateConfigName;
            private string _connectionString;
            #endregion

            #region 构造函数
            /// <summary>
            /// 默认的构造函数
            /// </summary>
            public EntityControl()
            {
            }
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="assemblyName">程序集名称</param>
            /// <param name="nhibernateConfigName">NHibernate 的配置文件名称</param>
            /// <param name="connectionString">数据路字符串连接</param>
            public EntityControl(string assemblyName, string nhibernateConfigName, string connectionString)
            {
                session = SessionFactory.Instance.OpenSession(assemblyName, nhibernateConfigName, connectionString);
                _assemblyName = assemblyName;
                _nhibernateConfigName = nhibernateConfigName;
                _connectionString = connectionString;
            }

            private void StartSession()
            {
                try
                {
                    if (!session.IsConnected)
                        session.Reconnect();
                    session.Clear();
                }
                catch
                {
                    RestartSession();
                    StartSession();
                }
            }

            private void RestartSession()
            {
                //session.Close();
                SessionFactory.Instance.CloseSession(_assemblyName);
                session = SessionFactory.Instance.OpenSession(_assemblyName, _nhibernateConfigName, _connectionString);
            }

            private void CloseSession()
            {
                if (session.IsConnected)
                    session.Disconnect();
            }
            #endregion

            #region 属性
            /// <summary>
            /// 程序集名称
            /// </summary>
            public string AssemblyName
            {
                get
                {
                    return _assemblyName;
                }
                set
                {
                    if (_assemblyName == value)
                        return;
                    _assemblyName = value;
                }
            }

            /// <summary>
            /// NHibernate 的配置文件名称
            /// </summary>
            public string NhibernateConfigName
            {
                get
                {
                    return _nhibernateConfigName;
                }
                set
                {
                    if (_nhibernateConfigName == value)
                        return;
                    _nhibernateConfigName = value;
                }
            }

            /// <summary>
            /// 数据路字符串连接
            /// </summary>
            public string ConnectionString
            {
                get
                {
                    return _connectionString;
                }
                set
                {
                    if (_connectionString == value)
                        return;
                    _connectionString = value;
                }
            }
            #endregion

            #region 方法
            #region 添加数据
            /// <summary>
            /// 添加数据
            /// </summary>
            /// <param name="entity"></param>
            public int AddEntity(Object entity)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        int newID = (int)session.Save(entity);
                        transaction.Commit();
                        return newID;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }
            /// <summary>
            /// 添加数据
            /// </summary>
            /// <param name="entity"></param>
            public object AddObjEntity(Object entity)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        object newID = session.Save(entity);
                        transaction.Commit();
                        return newID;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// 批量添加数据
            /// </summary>
            /// <param name="obj">实体列表</param>
            public int AddEntitys(IList<object> obj)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var o in obj)
                            session.Save(o);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }
            #endregion

            #region 更新数据
            /// <summary>
            /// 更新数据
            /// </summary>
            /// <param name="entity"></param>
            public int UpdateEntity(Object entity)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// 批量更新数据
            /// </summary>
            /// <param name="obj">实体列表</param>
            public int UpdateEntitys(IList<object> obj)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var o in obj)
                            session.Update(o);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// HQL语句批量更新
            /// </summary>
            /// <param name="sql">HQL</param>
            /// <returns></returns>
            public int UpdateHQL(string sql)
            {
                int obj;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    obj = iq.ExecuteUpdate();
                }
                catch (HibernateException ex)
                {
                    obj = 0;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// HQL语句批量更新
            /// </summary>
            /// <param name="sql">HQL</param>
            /// <param name="valueArr">参数</param>
            /// <returns></returns>
            public int UpdateHQL(string sql, Dictionary<string, string> valueArr)
            {
                int obj;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            if (k.Key.IndexOf("bool") > -1)
                                iq.SetBoolean(k.Key, Boolean.Parse(k.Value));
                            else
                                iq.SetString(k.Key, k.Value);
                        }
                    }
                    obj = iq.ExecuteUpdate();
                }
                catch (HibernateException ex)
                {
                    obj = 0;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// 更新数据
            /// </summary>
            /// <param name="entity">对象</param>
            /// <param name="key">主键</param>
            public int UpdateEntity(Object entity, Object key)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity, key);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// 添加或更新数据
            /// </summary>
            /// <param name="obj">实体列表</param>
            public int SaveOrUpdate(Object entity)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(entity);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// 批量添加或更新数据
            /// </summary>
            /// <param name="obj">实体列表</param>
            public int SaveOrUpdate(IList<object> obj)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var o in obj)
                            session.SaveOrUpdate(o);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }
            #endregion

            #region 删除数据
            /// <summary>
            /// 删除数据
            /// </summary>
            /// <param name="entity"></param>
            public int DeleteEntity(object entity)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// 批量删除数据
            /// </summary>
            /// <param name="obj">实体列表</param>
            public int DeleteEntitys(IList<object> obj)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var o in obj)
                            session.Delete(o);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }

            /// <summary>
            /// 批量删除数据
            /// </summary>
            /// <param name="obj">实体列表</param>
            public int DeleteEntitys(string sql)
            {
                StartSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(sql);
                        transaction.Commit();
                        return 1;
                    }
                    catch (HibernateException ex)
                    {
                        transaction.Rollback();
                        RestartSession();
                        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                        return 0;
                    }
                    finally
                    {
                        CloseSession();
                    }
                }
            }
            #endregion

            #region 查询数据
            public object GetEntitie(string sql)
            {
                Object obj;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    obj = iq.List();
                }
                catch (HibernateException ex)
                {
                    obj = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// 查询返回数据实体（实体类）
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public object GetEntitie(string sql, Dictionary<string, string> valueArr)
            {
                Object obj;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    obj = iq.UniqueResult();
                }
                catch (HibernateException ex)
                {
                    obj = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// 查询返回数据实体（实体类）
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public object GetSQLEntitie(string sql, Dictionary<string, string> valueArr)
            {
                Object obj;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    obj = iq.SetMaxResults(1).UniqueResult();
                }
                catch (HibernateException ex)
                {
                    obj = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// 查询返回数据实体（实体类）
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public object GetEntitie(string sql, Dictionary<string, string> valueArr, Dictionary<string, string> dateArr)
            {
                Object obj;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    if (dateArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in dateArr)
                        {
                            iq.SetDateTime(k.Key, Convert.ToDateTime(k.Value));
                        }
                    }
                    obj = iq.UniqueResult();
                }
                catch (HibernateException ex)
                {
                    obj = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sql, Dictionary<string, string> valueArr)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = iq.List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <param name="row">行数</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sql, Dictionary<string, string> valueArr, int row)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = iq.SetMaxResults(row).List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetHSQLEntities(string sql, Dictionary<string, string> valueArr)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = (IList)iq.Enumerable();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetSQLEntities(string sql, Dictionary<string, string> valueArr)
            {
                IList lst;
                StartSession();
                try
                {
                    ISQLQuery iq = session.CreateSQLQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = iq.List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetViewEntities(string sql, Dictionary<string, string> valueArr)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = iq.List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <param name="valueArr">日期参数值</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sql, Dictionary<string, string> valueArr, Dictionary<string, string> dateArr)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    if (dateArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in dateArr)
                        {
                            iq.SetDateTime(k.Key, Convert.ToDateTime(k.Value));
                        }
                    }
                    lst = iq.List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询返回数据列表
            /// </summary>
            /// <param name="tableName">表名</param>
            /// <param name="whereArr">一般条件</param>
            /// <param name="whereLikeArr">like条件</param>
            /// <param name="orderArr">排序</param>
            /// <returns></returns>
            public IList GetEntities(string tableName, Dictionary<string, string> whereArr, Dictionary<string, string> whereLikeArr, Dictionary<string, string> orderArr, Dictionary<string, string> groupArr)
            {
                IList lst;
                StartSession();
                try
                {
                    ICriteria ic = session.CreateCriteria(tableName);
                    if (whereArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in whereArr)
                        {
                            ic.Add(Restrictions.Eq(k.Key, k.Value));
                        }
                    }
                    if (whereLikeArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in whereLikeArr)
                        {
                            ic.Add(Restrictions.Like(k.Key, k.Value));
                        }
                    }
                    if (orderArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in orderArr)
                        {
                            ic.AddOrder(new NHibernate.Criterion.Order(k.Key, bool.Parse(k.Value)));
                        }
                    }
                    lst = ic.List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 查询分页数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <param name="pageIndex">页数</param>
            /// <param name="pageSize">行数</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sql, Dictionary<string, string> valueArr, int pageIndex, int pageSize, out int num)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    int count = iq.List().Count;
                    num = count;
                    if (pageIndex < 1)
                        pageIndex = 1;
                    if (pageSize < 1)
                        pageSize = 1;
                    lst = iq.SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();
                }
                catch (Exception ex)
                {
                    num = 0;
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }
            /// <summary>
            /// 查询分页数据列表
            /// 优化查询总行数的方法
            /// xzb，2012-06-01，修改
            /// </summary>
            /// <param name="sqlDate">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <param name="sqlCount">用于查询总行数</param>
            /// <param name="pageIndex">页数</param>
            /// <param name="pageSize">行数</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sqlDate, Dictionary<string, string> valueArr, string sqlCount, int pageIndex, int pageSize, out int num)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sqlDate);
                    IQuery iqCount = session.CreateQuery(sqlCount);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                            iqCount.SetString(k.Key, k.Value);
                        }
                    }

                    object obj = iqCount.UniqueResult();
                    int count = 0;
                    int.TryParse(obj.ToString(), out count);
                    num = count;
                    if (pageIndex < 1)
                        pageIndex = 1;
                    if (pageSize < 1)
                        pageSize = 1;

                    lst = iq.SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    num = 0;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }
            /// <summary>
            /// 查询分页数据列表
            /// 优化查询总行数的方法,增加一个统计语句
            /// xzb，2012-07-26，修改
            /// </summary>
            /// <param name="sqlDate">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <param name="sqlCount">用于查询总行数</param>
            /// <param name="pageIndex">页数</param>
            /// <param name="pageSize">行数</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sqlDate, Dictionary<string, string> valueArr, string sqlCount, string sqlMoney, int pageIndex, int pageSize, out int num, out int moneyAll)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sqlDate);
                    IQuery iqCount = session.CreateQuery(sqlCount);
                    IQuery iqMoney = session.CreateQuery(sqlMoney);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                            iqCount.SetString(k.Key, k.Value);
                            iqMoney.SetString(k.Key, k.Value);
                        }
                    }

                    num = 0;
                    object objCount = iqCount.UniqueResult();
                    if (objCount != null)
                    {
                        int.TryParse(objCount.ToString(), out num);
                    }

                    moneyAll = 0;
                    object objMoney = iqMoney.UniqueResult();
                    if (objMoney != null)
                    {
                        int.TryParse(objMoney.ToString(), out moneyAll);
                    }

                    if (pageIndex < 1)
                        pageIndex = 1;
                    if (pageSize < 1)
                        pageSize = 1;

                    lst = iq.SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    num = 0;
                    moneyAll = 0;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }
            /// <summary>
            /// 查询分页数据列表
            /// </summary>
            /// <param name="sql">数据语句（注意：只能写单张表查询，不能关联多张表查询)</param>
            /// <param name="valueArr">参数值</param>
            /// <param name="pageIndex">页数</param>
            /// <param name="pageSize">行数</param>
            /// <returns>例如[select * ]from Ferry.Model.ferrySysModules m where m.moduleID=:mid(注意用冒号)</returns>
            public IList GetEntities(string sql, Dictionary<string, string> valueArr, string[] arr, int pageIndex, int pageSize, out int num)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.CreateQuery(sql);
                    if (arr != null)
                    {
                        string key = arr[arr.Length - 1];
                        string[] parm = arr.Take(arr.Length - 1).ToArray();
                        iq.SetParameterList(key, parm);
                    }
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    int count = iq.List().Count;
                    num = count;
                    if (pageIndex < 1)
                        pageIndex = 1;
                    if (pageSize < 1)
                        pageSize = 1;
                    lst = iq.SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    num = 0;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }


            /// <summary>
            /// 获取用户权限
            /// </summary>
            /// <param name="uid">用户ID</param>
            /// <returns></returns>
            //public IList<Ferry.Model.ferrySysPermissions> GetPerms(int uid)
            //{
            //    IList<Ferry.Model.ferrySysPermissions> Permissions;
            //    if (!session.IsConnected)
            //        session.Reconnect();
            //    session.Clear();
            //    try
            //    {
            //        //用户组权限
            //        IList<Ferry.Model.ferrySysPermissions> il = session.CreateCriteria("Ferry.Model.ferrySysPermissions")
            //            .Add(Restrictions.Eq("permissionsType", true))
            //            .CreateCriteria("OURelations")
            //            .Add(Restrictions.Eq("uid", uid))
            //            .List<Ferry.Model.ferrySysPermissions>();
            //        //用户角色权限
            //        IList<Ferry.Model.ferrySysPermissions> il2 = session.CreateCriteria("Ferry.Model.ferrySysPermissions")
            //            .Add(Restrictions.Eq("permissionsType", false))
            //            .CreateCriteria("Roles")
            //            .CreateCriteria("OURelations")
            //            .Add(Restrictions.Eq("uid", uid))
            //            .List<Ferry.Model.ferrySysPermissions>();
            //        Permissions = new List<Ferry.Model.ferrySysPermissions>();
            //        foreach (Ferry.Model.ferrySysPermissions p in il)
            //            Permissions.Add(p);
            //        foreach (Ferry.Model.ferrySysPermissions p in il2)
            //            Permissions.Add(p);
            //    }
            //    catch (HibernateException ex)
            //    {
            //        Permissions = null;
            //        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
            //    }
            //    finally
            //    {
            //        session.Disconnect();
            //    }
            //    return Permissions;
            //}

            /// <summary>
            /// 获取获块用户数
            /// </summary>
            /// <param name="mid">模块ID</param>
            /// <returns></returns>
            //public void GetModuleUsers(int mid, out IList<Ferry.Model.ferrySysPermissions> il, out IList<Ferry.Model.ferrySysPermissions> il2)
            //{
            //    //IList<Ferry.Model.ferrySysUsers> users;
            //    if (!session.IsConnected)
            //        session.Reconnect();
            //    session.Clear();
            //    try
            //    {
            //        //用户组权限
            //        il = session.CreateCriteria("Ferry.Model.ferrySysPermissions")
            //            .Add(Restrictions.Eq("permissionsType", true))
            //            .Add(Restrictions.Eq("moduleID", mid))
            //            .List<Ferry.Model.ferrySysPermissions>();
            //        //用户角色权限
            //        il2 = session.CreateCriteria("Ferry.Model.ferrySysPermissions")
            //            .Add(Restrictions.Eq("permissionsType", false))
            //            .Add(Restrictions.Eq("moduleID", mid))
            //            .List<Ferry.Model.ferrySysPermissions>();
            //        //users = new List<Ferry.Model.ferrySysUsers>();
            //        //foreach (Ferry.Model.ferrySysPermissions p in il)
            //        //    users.Add(p.OURelations.Users);
            //        //foreach (Ferry.Model.ferrySysPermissions p in il2)
            //        //{
            //        //    foreach (Ferry.Model.ferrySysOURelations psub in p.Roles.OURelations)
            //        //        users.Add(psub.Users);
            //        //}
            //    }
            //    catch (HibernateException ex)
            //    {
            //        il = null;
            //        il2 = null;
            //        //users = null;
            //        //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
            //    }
            //    finally
            //    {
            //        session.Disconnect();
            //    }
            //    //return users;
            //}

            /// <summary>
            /// 执行存储过程
            /// </summary>
            /// <param name="name">存储过程名称</param>
            /// <param name="valueArr">参数</param>
            /// <returns></returns>
            public object GetEntStorage(string name, Dictionary<string, string> valueArr)
            {
                Object obj;
                StartSession();
                try
                {
                    IQuery iq = session.GetNamedQuery(name);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    obj = iq.UniqueResult();
                }
                catch (HibernateException ex)
                {
                    obj = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return obj;
            }

            /// <summary>
            /// 执行存储过程
            /// </summary>
            /// <param name="name">存储过程名称</param>
            /// <param name="valueArr">参数</param>
            /// <returns></returns>
            public IList GetStorage(string name, Dictionary<string, string> valueArr)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.GetNamedQuery(name);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = iq.List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }

            /// <summary>
            /// 执行存储过程
            /// </summary>
            /// <param name="name">存储过程名称</param>
            /// <param name="valueArr">参数</param>
            /// <returns></returns>
            public IList<object> GetStorageOfDataTable(string name, Dictionary<string, string> valueArr)
            {
                IList lst;
                IList<object> o = null;
                StartSession();
                try
                {
                    IQuery iq = session.GetNamedQuery(name);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    lst = iq.List();

                    o = lst.Cast<object>().ToList();
                }
                catch (HibernateException ex)
                {
                    lst = null;

                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return o;
            }

            /// <summary>
            /// 执行存储过程
            /// </summary>
            /// <param name="name">存储过程名称</param>
            /// <param name="valueArr">参数</param>
            /// <returns></returns>
            public IList GetStorage(string name, Dictionary<string, string> valueArr, int pageIndex, int pageSize, out int num)
            {
                IList lst;
                StartSession();
                try
                {
                    IQuery iq = session.GetNamedQuery(name);
                    if (valueArr != null)
                    {
                        foreach (KeyValuePair<string, string> k in valueArr)
                        {
                            iq.SetString(k.Key, k.Value);
                        }
                    }
                    num = iq.List().Count;
                    if (pageIndex < 1)
                        pageIndex = 1;
                    if (pageSize < 1)
                        pageSize = 1;
                    lst = iq.SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();
                }
                catch (HibernateException ex)
                {
                    lst = null;
                    num = 0;
                    RestartSession();
                    //SysExceptionLog.InputLog(ex, typeof(EntityControl<T>), Url.ClientIPAddress, Identity.Current.Account);
                }
                finally
                {
                    CloseSession();
                }
                return lst;
            }
            #endregion
            #endregion




            /// <summary>
            /// 将IList转化为dataset 
            /// </summary>
            /// <param name="list"></param>
            /// <returns></returns>
            private static DataSet ConvertToDataSet<Temp>(IList<Temp> list)
            {
                if (list == null || list.Count <= 0)
                {
                    return null;
                }

                DataSet ds = new DataSet();
                DataTable dt = new DataTable(typeof(Temp).Name);
                DataColumn column;
                DataRow row;

                System.Reflection.PropertyInfo[] myPropertyInfo = typeof(Temp).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                foreach (Temp t in list)
                {
                    if (t == null)
                    {
                        continue;
                    }

                    row = dt.NewRow();

                    for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                    {
                        System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                        string name = pi.Name;

                        if (dt.Columns[name] == null)
                        {
                            column = new DataColumn(name, pi.PropertyType);
                            dt.Columns.Add(column);
                        }

                        row[name] = pi.GetValue(t, null);
                    }

                    dt.Rows.Add(row);
                }

                ds.Tables.Add(dt);

                return ds;

            }
        }
}
