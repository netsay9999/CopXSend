using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace H.Saas.Tools
{
    public class ExcelHelper
    {
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="sWebRootFolder">webRoot文件夹</param>
        /// <param name="sFileName">文件名</param>
        /// <param name="sColumnName">自定义列名（不传默认dt列名）</param>
        /// <returns></returns>
        public static bool ExportExcel(DataTable dt, string paths, string fname, string[] sColumnName, ref string msg)
        {

            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    msg = "没有符合条件的数据！";
                    return false;
                }
                var path = Directory.GetCurrentDirectory() + "/" + paths + "/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileInfo file = new FileInfo(path + fname);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    //添加worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(fname.Split('.')[0]);

                    //添加表头
                    int column = 1;
                    if (sColumnName.Count() == dt.Columns.Count)
                    {
                        foreach (string cn in sColumnName)
                        {
                            worksheet.Cells[1, column].Value = cn.Trim();

                            worksheet.Cells[1, column].Style.Font.Bold = true;//字体为粗体
                            worksheet.Cells[1, column].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//水平居中
                            worksheet.Cells[1, column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;//设置样式类型
                            worksheet.Cells[1, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(159, 197, 232));//设置单元格背景色
                            column++;
                        }
                    }
                    else
                    {
                        int x = 0;
                        foreach (DataColumn dc in dt.Columns)
                        {

                            worksheet.Cells[1, column].Value = dc.ColumnName;
                            if (x > 4)
                            {
                                worksheet.Cells[1, column].Style.Numberformat.Format = "0.00";
                            }

                            worksheet.Cells[1, column].Style.Font.Bold = true;//字体为粗体
                            worksheet.Cells[1, column].Style.Font.Size = 12;
                            worksheet.Cells[1, column].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//水平居中
                            worksheet.Cells[1, column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;//设置样式类型
                            worksheet.Cells[1, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(159, 197, 232));//设置单元格背景色
                            column++;
                        }
                    }

                    //添加数据
                    int row = 2;
                    foreach (DataRow dr in dt.Rows)
                    {
                        int col = 1;
                        var col1 = dr[0].ToString();
                        bool b = false;
                        if (col1.Contains("-----"))
                        {
                            b = true;
                            dr[0] = dr[0].ToString().Replace("-----", "");
                        }
                        foreach (DataColumn dc in dt.Columns)
                        {
                            worksheet.Cells[row, col].Value = dr[col - 1].ToString();
                            if (b)
                            {
                                worksheet.Cells[row, col].Style.Font.Bold = true;//字体为粗体
                                worksheet.Cells[row, col].Style.Font.Size = 9;
                                worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//水平居中
                                worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;//设置样式类型
                                worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(239, 242, 170));//设置单元格背景色
                            }
                            col++;
                        }
                        row++;
                    }

                    //自动列宽
                    worksheet.Cells.AutoFitColumns();

                    //保存workbook.
                    package.Save();
                }
                msg = "导出成功";
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(JsonConvert.SerializeObject(ex));
                msg = "生成Excel失败：" + ex.Message;
                return false;
            }

        }


        public static void ExcelPath(string name, string path, DataTable dt)
        {
            FileInfo newFile = new FileInfo(path);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(path);
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(name);
                int k = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    if (k == 1)
                    {
                        int i = 1;
                        foreach (DataColumn dc in dt.Columns)
                        {
                            worksheet.Cells[k, i].Value = dc.ColumnName;
                            worksheet.Column(i).Width = 30;
                            i++;
                        }
                    }
                    k++;
                }
                k = 2;
                foreach (DataRow dr in dt.Rows)
                {
                    int m = 1;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        worksheet.Cells[k, m].Value = dr[m - 1].ToString();
                        m++;
                    }
                    k++;
                }
                package.Save();
            }

        }

        public static void ExcelPath<T>(string name, string path, List<T> list)
        {
            FileInfo newFile = new FileInfo(path);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(path);
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(name);
                int k = 1;
                foreach (T item in list)
                {
                    int i = 1;
                    var props = typeof(T).GetProperties();
                    foreach (var d in props)
                    {
                        worksheet.Cells[k, i].Value = d.GetValue(item);
                        worksheet.Column(i).Width = 30;
                        i++;
                    }
                    k++;
                }
                package.Save();
            }

        }

        public static DataTable LoadExcel(string path)
        {
            try
            {
                using (ExcelPackage pack = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorksheet sheet = pack.Workbook.Worksheets[1];
                    var rowCount = sheet.Dimension.End.Row;
                    var columnCount = sheet.Dimension.End.Column;

                    DataTable dt = new DataTable();
                    for (int j = 1; j <= columnCount; j++)
                    {
                        dt.Columns.Add("A" + j.ToString());
                    }
                    for (int i = 1; i <= rowCount; i++)
                    {
                        dt.Rows.Add(dt.NewRow());
                        for (int j = 1; j <= columnCount; j++)
                        {
                            dt.Rows[i - 1][j - 1] = sheet.Cells[i, j].Value;
                        }
                    }
                    return dt;
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
