using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using org.in2bits.MyXls;
using System.Collections;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Wings.Common
{
    /// <summary>
    /// 类名：输出Excel应用类
    /// </summary>
    public class PrintObj
    {
        public PrintObj() { }
        /// <summary>
        /// 导出Excel文件
        /// 创建人：flsun
        /// </summary>
        /// <param name="DataTD">数据</param>
        /// <param name="title">标题</param>
        /// <param name="saveName">保存名称</param>
        public static void PrintExcel(DataTable DataTD, string title, string saveName)
        {
            try
            {
                //生成Excel开始
                XlsDocument xls = new XlsDocument();//创建空xls文档
                #region
                xls.FileName = saveName;
                #endregion

                // Sheet标题样式  
                XF titleXF = xls.NewXF(); // 为xls生成一个XF实例，XF是单元格格式对象  
                titleXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中  
                titleXF.VerticalAlignment = VerticalAlignments.Centered; // 垂直居中  
                titleXF.UseBorder = true; // 使用边框  
                titleXF.TopLineStyle = 1; // 上边框样式  
                titleXF.TopLineColor = Colors.Black; // 上边框颜色  
                titleXF.LeftLineStyle = 1; // 左边框样式  
                titleXF.LeftLineColor = Colors.Black; // 左边框颜色  
                titleXF.RightLineStyle = 1; // 右边框样式  
                titleXF.RightLineColor = Colors.Black; // 右边框颜色  
                titleXF.Font.FontName = "宋体"; // 字体  
                titleXF.Font.Bold = true; // 是否加楚  
                titleXF.Font.Height = 12 * 20; // 字大小（字体大小是以 1/20 point 为单位的）  



                // 列标题样式  
                XF columnTitleXF = xls.NewXF(); // 为xls生成一个XF实例，XF是单元格格式对象  
                columnTitleXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中  
                columnTitleXF.VerticalAlignment = VerticalAlignments.Centered; // 垂直居中  
                columnTitleXF.UseBorder = true; // 使用边框  
                columnTitleXF.TopLineStyle = 1; // 上边框样式  
                columnTitleXF.TopLineColor = Colors.Black; // 上边框颜色  
                columnTitleXF.BottomLineStyle = 1; // 下边框样式  
                columnTitleXF.BottomLineColor = Colors.Black; // 下边框颜色  
                columnTitleXF.LeftLineStyle = 1; // 左边框样式  
                columnTitleXF.LeftLineColor = Colors.Black; // 左边框颜色  
                columnTitleXF.Pattern = 1; // 单元格填充风格。如果设定为0，则是纯色填充(无色)，1代表没有间隙的实色  
                columnTitleXF.PatternBackgroundColor = Colors.Red; // 填充的底色  
                columnTitleXF.PatternColor = Colors.Default2F; // 填充背景色  



                // 数据单元格样式  
                XF dataXF = xls.NewXF(); // 为xls生成一个XF实例，XF是单元格格式对象  
                dataXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中  
                dataXF.VerticalAlignment = VerticalAlignments.Centered; // 垂直居中  
                dataXF.UseBorder = true; // 使用边框  
                dataXF.LeftLineStyle = 1; // 左边框样式  
                dataXF.LeftLineColor = Colors.Black; // 左边框颜色  
                dataXF.BottomLineStyle = 1;  // 下边框样式  
                dataXF.BottomLineColor = Colors.Black;  // 下边框颜色  
                dataXF.Font.FontName = "宋体";
                dataXF.Font.Height = 9 * 20; // 设定字大小（字体大小是以 1/20 point 为单位的）  
                dataXF.UseProtection = false; // 默认的就是受保护的，导出后需要启用编辑才可修改  
                dataXF.TextWrapRight = true; // 自动换行  
                int pagerow = 60000;
                double pageNum = Math.Ceiling(Convert.ToDouble(DataTD.Rows.Count) / pagerow);
                for (int index = 0; index < 1; index++)
                {
                    Worksheet sheet = xls.Workbook.Worksheets.Add(string.Format("第{0}页", index + 1));//创建一个工作页
                    // 合并单元格  
                    MergeArea titleArea = new MergeArea(1, 1, 1, DataTD.Columns.Count); // 一个合并单元格实例(合并第1行、第1列 到 第1行、第4列)  
                    sheet.AddMergeArea(titleArea); //填加合并单元格      

                    // 开始填充数据到单元格  
                    Cells cells = sheet.Cells;

                    // Sheet标题行，行和列的索引都是从1开始的  
                    Cell cell = cells.Add(1, 1, title + "[为控制平台系统资源最大导出量为60000条，超过请从数据库中导出]", titleXF);
                    for (int i = 2; i <= DataTD.Columns.Count; i++)
                        cell = cells.Add(1, i, "", titleXF);

                    int colIndex = 0;
                    // 列标题行  
                    foreach (DataColumn dc in DataTD.Columns)
                    {
                        //设置文档列属性 
                        ColumnInfo cinfo = new ColumnInfo(xls, sheet);//设置xls文档的指定工作页的列属性
                        cinfo.Collapsed = true;
                        cinfo.ColumnIndexStart = ushort.Parse(colIndex.ToString()); // 起始列为第1列，索引从0开始  
                        cinfo.ColumnIndexEnd = ushort.Parse(colIndex.ToString()); // 终止列为第1列，索引从0开始  
                        cinfo.Width = 90 * 60;//列宽度
                        sheet.AddColumnInfo(cinfo);
                        colIndex++;
                        if (colIndex == DataTD.Columns.Count)
                        {
                            dataXF.RightLineStyle = 1;
                            dataXF.RightLineColor = Colors.Black;
                        }
                        cells.Add(2, colIndex, dc.Caption, columnTitleXF);
                    }
                    // 行索引  
                    int rowIndex = 3;

                    for (int i = index * pagerow; i < ((index + 1) * pagerow > DataTD.Rows.Count ? DataTD.Rows.Count : (index + 1) * pagerow); i++)
                    {

                        for (int j = 0; j < DataTD.Columns.Count; j++)
                        {
                            if (j == DataTD.Columns.Count - 1)
                            {
                                dataXF.RightLineStyle = 1;
                                dataXF.RightLineColor = Colors.Black;
                            }
                            if (DataTD.Rows[i][j].GetType() == System.Type.GetType("System.DateTime"))//判断类型
                            {
                                if (System.DBNull.Value.Equals(DataTD.Rows[i][j]))
                                    cells.Add(rowIndex, j + 1, null, dataXF);
                                else
                                    cells.Add(rowIndex, j + 1, (Convert.ToDateTime(DataTD.Rows[i][j])).ToString(), dataXF);//格式化字符串，否则在XLS的日期格式会不正确
                            }
                            else if (DataTD.Rows[i][j].GetType() == System.Type.GetType("System.Int32"))
                                cells.Add(rowIndex, j + 1, int.Parse(DataTD.Rows[i][j].ToString()), dataXF);
                            else
                                cells.Add(rowIndex, j + 1, DataTD.Rows[i][j].ToString(), dataXF);
                        }
                        // 行号递增  
                        rowIndex++;

                    }
                }



                System.Web.HttpContext.Current.Response.Charset = "UTF-8";//gb2312简体
                System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;// System.Text.Encoding.GetEncoding("UTF8");

                System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(xls.FileName, Encoding.UTF8));

                //System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveName)); ;
                xls.Save(System.Web.HttpContext.Current.Response.OutputStream);
                //xls.Send();//保存到服务器
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 创建目的：加载Excel文件
        /// 创建时间：2012-07-24
        /// 创建人：xzb
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataSet LoadDataFromExcel(string strConn, string tableName)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                String sql = "SELECT * FROM  [" + tableName + "$]";//表名称，比如sheet1，等等   

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                OleDaExcel.Fill(ds, "Sheet1");
                conn.Close();
                return ds;
            }
            catch (Exception err)
            {
                throw;
                //    MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return null;
            }
        }
    }
}
