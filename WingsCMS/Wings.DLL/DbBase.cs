using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Wings.Security;
using Wings.Common;
using System.Collections.Specialized;
public class Config
{
    public const string ConnectionKey = "ConnectionString";
    public Config()
    {

    }
}
public class DbBase : IDisposable
{
    private SqlConnection Connection = null;
    private SqlCommand Command = new SqlCommand();
    private SqlDataAdapter Adapter = new SqlDataAdapter();
    private string strConnectionKey = Config.ConnectionKey;
    public string ConnectionKey { set { strConnectionKey = value; } get { return strConnectionKey; } }
    private string strError = string.Empty;
    public string Error { get { return strError; } }
    public DbBase()
    {
        InitConnect(new DESEncrypt().Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings[strConnectionKey].ConnectionString, null));
    }
    public void Dispose()
    {
        if (Command != null) { Command.Dispose(); }
        if (Connection != null) { Connection.Dispose(); }
        GC.SuppressFinalize(this);
    }
    ~DbBase()
    {
        Dispose();
    }
    /// <summary>
    /// 获取解密字符串
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetDecConnectionByKey(string key)
    {
        return new DESEncrypt().Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString, null);
    }
    public DbBase(string ConnectionString)
    {
        InitConnect(ConnectionString);
    }
    /// <summary>
    /// 初始化连接对象
    /// </summary>
    /// <param name="ConnectionString"></param>
    private void InitConnect(string ConnectionString)
    {
        Command.CommandTimeout = 600;
        if (Connection == null)
        {
            Connection = new SqlConnection(ConnectionString);
        }
    }
    /// <summary>
    /// 执行语句返回受影响行数
    /// </summary>
    /// <param name="SqlText"></param>
    /// <returns></returns>
    public int ExecuteNonQuery(string SqlText)
    {
        strError = string.Empty;
        Command.Connection = Connection;
        Command.CommandType = CommandType.Text;
        Command.CommandText = SqlText;
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        int i = 0;
        try
        {
            i = Command.ExecuteNonQuery();
        }
        catch (Exception ex) { strError = ex.Message; }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return i;
    }
    /// <summary>
    /// 执行语句返回受影响行数
    /// xzb,2012-06-20,增加
    /// </summary>
    /// <param name="SqlText"></param>
    /// <returns></returns>
    public int ExecuteNonQuery(string SqlText, string conn)
    {
        strError = string.Empty;
        Command.Connection = Connection;
        Command.CommandType = CommandType.Text;
        Command.CommandText = SqlText;
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        int i = 0;
        try
        {
            i = Command.ExecuteNonQuery();
        }
        catch (Exception ex) { strError = ex.Message; }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return i;
    }
    /// <summary>
    /// 执行语句，返回结果的第一行第一列
    /// </summary>
    /// <param name="SqlText"></param>
    /// <returns></returns>
    public object ExecuteScalar(string SqlText)
    {
        Command.Connection = Connection;
        Command.CommandText = SqlText;
        Command.CommandType = CommandType.Text;
        strError = string.Empty;
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        object obj = null;
        try
        {
            obj = Command.ExecuteScalar();
        }
        catch (Exception ex) { strError = ex.Message; }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return obj;
    }
    /// <summary>
    /// 执行语句，返回数据集
    /// </summary>
    /// <param name="SqlText"></param>
    /// <returns></returns>
    public DataSet ExecuteFill(string SqlText)
    {
        Command.Connection = Connection;
        Command.CommandText = SqlText;
        Command.CommandType = CommandType.Text;
        strError = string.Empty;
        DataSet ds = new DataSet();
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        Adapter.SelectCommand = Command;
        try
        {
            Adapter.Fill(ds);
        }
        catch (Exception ex) { strError = ex.Message; }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return ds;
    }
    /// <summary>
    /// 执行语句，返回数据视图
    /// </summary>
    /// <param name="SqlText"></param>
    /// <returns></returns>
    public DataView ExecuteDataView(string SqlText)
    {
        Command.Connection = Connection;
        Command.CommandText = SqlText;
        Command.CommandType = CommandType.Text;
        strError = string.Empty;
        DataSet ds = new DataSet();
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        Adapter.SelectCommand = Command;
        DataView dv = new DataView();
        try
        {
            Adapter.Fill(ds);
            dv = ds.Tables[0].DefaultView;
        }
        catch (Exception ex) { strError = ex.Message; }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return dv;
    }
    /// <summary>
    /// 执行存储过程，返回数据视图
    /// </summary>
    /// <param name="proName">存储过程名称</param>
    /// <param name="Params"参数></param>
    /// <returns>数据视图</returns>
    public DataView ExecuteProduce(string proName, params System.Data.SqlClient.SqlParameter[] Params)
    {
        Command.Connection = Connection;
        Command.CommandText = proName;
        strError = string.Empty;
        Command.CommandType = CommandType.StoredProcedure;
        DataSet ds = new DataSet();
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        if (Params != null)
        {
            Command.Parameters.Clear();
            foreach (System.Data.SqlClient.SqlParameter param in Params)
            {
                Command.Parameters.Add(param);
            }
        }
        Adapter.SelectCommand = Command;
        DataView dv = new DataView();
        try
        {
            Adapter.Fill(ds);
            dv = ds.Tables[0].DefaultView;
        }
        catch (Exception ex) { strError = ex.Message; }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return dv;
    }
    /// <summary>
    /// 执行存储过程，返回数据集
    /// </summary>
    /// <param name="proName"></param>
    /// <param name="Params"></param>
    /// <returns></returns>
    public DataSet ExecuteProduceFillDataSet(string proName, params System.Data.SqlClient.SqlParameter[] Params)
    {

        Command.Connection = Connection;
        Command.CommandText = proName;
        strError = string.Empty;
        Command.CommandType = CommandType.StoredProcedure;
        DataSet ds = new DataSet();
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }
        if (Params != null)
        {
            Command.Parameters.Clear();
            foreach (System.Data.SqlClient.SqlParameter param in Params)
            {
                Command.Parameters.Add(param);
            }
        }
        Adapter.SelectCommand = Command;
        try
        {
            Adapter.Fill(ds);
        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }
        finally
        {
            Connection.Close();
            Command.Dispose();
        }
        return ds;
    }

    /// <summary>
    /// 取得配置文件中的字符串KEY
    /// xzb,2012-06-20
    /// </summary>
    /// <param name="SectionName">节点名称</param>
    /// <param name="key">KEY名</param>
    /// <returns>返回KEY值</returns>
    public static string GetConfigString(string SectionName, string key)
    {
        string returnVal = "";
        if (SectionName != "")
        {
            try
            {
                NameValueCollection cfgName = (NameValueCollection)ConfigurationManager.GetSection(SectionName);
                if (cfgName[key] != null)
                {
                    returnVal = cfgName[key];
                }
                cfgName = null;
            }
            catch { }
        }
        return new DESEncrypt().Decrypt(returnVal, null);
    }
}
