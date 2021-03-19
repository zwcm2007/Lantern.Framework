﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace HouHeng.Common.Data
{
    /// <summary>
    /// 列表字段排序条件
    /// </summary>
    public class SortCondition
    {
        /// <summary>
        /// 构造一个排序字段名称和排序方式的排序条件
        /// </summary>
        /// <param name="sortField">字段名称</param>
        /// <param name="listSortDirection">排序方式</param>
        public SortCondition(string sortField, ListSortDirection listSortDirection = ListSortDirection.Ascending)
        {
            SortField = sortField;
            ListSortDirection = listSortDirection;
        }

        /// <summary>
        /// 获取或设置 排序字段名称
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// 获取或设置 排序方向
        /// </summary>
        public ListSortDirection ListSortDirection { get; set; }
    }

    /// <summary>
    /// 支持泛型的列表字段排序条件
    /// </summary>
    /// <typeparam name="T">列表元素类型</typeparam>
    public class SortCondition<T> : SortCondition
    {
        /// <summary>
        /// 使用排序字段与排序方式 初始化一个<see cref="SortCondition"/>类型的新实例
        /// </summary>
        public SortCondition(Expression<Func<T, object>> keySelector, ListSortDirection listSortDirection = ListSortDirection.Ascending)
            : base(GetPropertyName(keySelector), listSortDirection)
        { }

        /// <summary>
        /// 从泛型委托获取属性名
        /// </summary>
        private static string GetPropertyName(Expression<Func<T, object>> keySelector)
        {
            string param = keySelector.Parameters.First().Name;
            string operand = (((dynamic)keySelector.Body).Operand).ToString();
            operand = operand.Substring(param.Length + 1, operand.Length - param.Length - 1);
            return operand;
        }
    }
}