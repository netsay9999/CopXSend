using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace H.Saas.Tools
{
    public static partial class Extensions
    {
        public static double toDouble(this object str)
        {
            return Convert.ToDouble(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="num"></param>
        /// <param name="type">0:四舍五入，1:向下舍去小数点</param>
        /// <returns></returns>
        public static decimal? NumX(this object m, int num = 2, int type = 0)
        {
            decimal mt = 0;
            decimal.TryParse(m.ToString(), out mt);
            if (type == 1)
                return Convert.ToDecimal(Math.Round(Convert.ToDouble(mt), num, MidpointRounding.ToNegativeInfinity));
            return Convert.ToDecimal(Math.Round(Convert.ToDouble(mt), num, MidpointRounding.AwayFromZero));
        }
        public static int? toInt(this object str)
        {
            return Convert.ToInt32(str);
        }

        public static T ToObj<T>(this string str)
        {
            try
            {
                T t = JsonConvert.DeserializeObject<T>(str);
                return t;
            }
            catch
            {
                return default(T);
            }
        }


        public static List<T> ToList<T>(this DataTable dt)
        {
            var str = JsonConvert.SerializeObject(dt);
            return str.ToObject<List<T>>();
        }
        public static T FirstOrDefault<T>(this DataTable dt)
        {
            var str = JsonConvert.SerializeObject(dt);
            return JsonConvert.DeserializeObject<List<T>>(str).FirstOrDefault();
        }
        /// <summary>
        /// 将DataTable 转换成 List<dynamic>
        /// reverse 反转：控制返回结果中是只存在 FilterField 指定的字段,还是排除.
        /// [flase 返回FilterField 指定的字段]|[true 返回结果剔除 FilterField 指定的字段]
        /// FilterField  字段过滤，FilterField 为空 忽略 reverse 参数；返回DataTable中的全部数
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <param name="reverse">
        /// 反转：控制返回结果中是只存在 FilterField 指定的字段,还是排除.
        /// [flase 返回FilterField 指定的字段]|[true 返回结果剔除 FilterField 指定的字段]
        ///</param>
        /// <param name="FilterField">字段过滤，FilterField 为空 忽略 reverse 参数；返回DataTable中的全部数据</param>
        /// <returns>List<dynamic></returns>
        public static List<dynamic> ToDyList(this DataTable table, bool reverse = true, params string[] FilterField)
        {
            var modelList = new List<dynamic>();
            foreach (DataRow row in table.Rows)
            {
                dynamic model = new ExpandoObject();
                var dict = (IDictionary<string, object>)model;
                foreach (DataColumn column in table.Columns)
                {
                    if (FilterField.Length != 0)
                    {
                        if (reverse == true)
                        {
                            if (!FilterField.Contains(column.ColumnName))
                            {
                                var x = row[column].GetType();
                                dict[column.ColumnName] = row[column].ToString();
                            }
                        }
                        else
                        {
                            if (FilterField.Contains(column.ColumnName))
                            {
                                dict[column.ColumnName] = row[column].ToString();
                            }
                        }
                    }
                    else
                    {
                        var x = row[column].GetType();
                        if (x.Name.ToLower().Contains("int") || x.Name.ToLower().Contains("dec"))
                            dict[column.ColumnName] = row[column] == null ? 0 : row[column];
                        else
                            dict[column.ColumnName] = row[column].ToString();
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }

        public static dynamic ToDynamic(this List<dynamic> list)
        {
            return list.FirstOrDefault();
        }

        public static dynamic ToDynamic(this DataTable dt)
        {
            return dt.ToDyList().FirstOrDefault();
        }
    }
}
