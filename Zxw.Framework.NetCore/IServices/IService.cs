﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Zxw.Framework.NetCore.Models;

namespace Zxw.Framework.NetCore.IServices
{
    public interface IService<T, in TKey>: IDisposable where T:IBaseModel<TKey>
    {
        int Count(Expression<Func<T, bool>> where = null);

        bool Exists(Expression<Func<T, bool>> where = null);
        bool Exists<TProperty>(Expression<Func<T, bool>> where = null, params Expression<Func<T, TProperty>>[] includes);

        T GetSingle(TKey key);

        T GetSingle<TProperty>(TKey key, params Expression<Func<T, TProperty>>[] includes);

        IList<T> Get(Expression<Func<T, bool>> where = null);
        IList<T> Get<TProperty>(Expression<Func<T, bool>> where = null, params Expression<Func<T, TProperty>>[] includes);

        IList<T> GetByPagination(Expression<Func<T, bool>> where, int pageSize, int pageIndex,
            Expression<Func<T, T>> orderby = null, bool asc = true);
        IList<T> GetByPagination<TProperty>(Expression<Func<T, bool>> where, int pageSize, int pageIndex,
            Expression<Func<T, T>> orderby = null, bool asc = true, params Expression<Func<T, TProperty>>[] includes);
        void Add(T entity);

        void AddRange(ICollection<T> entities);

        void Edit(T entity);

        void EditRange(ICollection<T> entities);

        void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> updateExp);

        void Update(T model, params string[] updateColumns);

        void Delete(TKey key);

        void Delete(Expression<Func<T, bool>> where);

        int ExecuteSqlWithNonQuery(string sql, params object[] parameters);

        IList<TView> CustomQuery<TView>(string sql, params object[] parameters) where TView : class, new();
    }
}