﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Zxw.Framework.NetCore.IRepositories;
using Zxw.Framework.NetCore.IServices;
using Zxw.Framework.NetCore.Models;

namespace Zxw.Framework.NetCore.Services
{
    public abstract class BaseService<T, TKey> : IService<T, TKey> where T: class, IBaseModel<TKey>
    {
        protected IRepository<T, TKey> Repository;

        protected BaseService(IRepository<T, TKey> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public virtual int Count(Expression<Func<T, bool>> @where = null)
        {
            return Repository.Count(where);
        }

        public bool Exists(Expression<Func<T, bool>> @where = null)
        {
            return Repository.Exist(where);
        }

        public bool Exists<TProperty>(Expression<Func<T, bool>> @where = null, params Expression<Func<T, TProperty>>[] includes)
        {
            return Repository.Exist(where, includes);
        }

        public virtual T GetSingle(TKey key)
        {
            return Repository.GetSingle(key);
        }

        public T GetSingle<TProperty>(TKey key, params Expression<Func<T, TProperty>>[] includes)
        {
            return Repository.GetSingle(key, includes);
        }


        public virtual IList<T> Get(Expression<Func<T, bool>> @where = null)
        {
            return Repository.Get(where);
        }

        public IList<T> Get<TProperty>(Expression<Func<T, bool>> @where = null, params Expression<Func<T, TProperty>>[] includes)
        {
            return Repository.Get(where, includes);
        }

        public virtual IList<T> GetByPagination(Expression<Func<T, bool>> @where, int pageSize, int pageIndex, Expression<Func<T, T>> @orderby = null, bool asc = true)
        {
            return Repository.GetByPagination(where, pageSize, pageIndex, orderby, asc);
        }

        public IList<T> GetByPagination<TProperty>(Expression<Func<T, bool>> @where, int pageSize, int pageIndex, Expression<Func<T, T>> @orderby = null,
            bool asc = true, params Expression<Func<T, TProperty>>[] includes)
        {
            return Repository.GetByPagination(where, pageSize, pageIndex, orderby, asc, includes);
        }

        public virtual void Add(T entity)
        {
            /*return*/ Repository.Add(entity);
        }

        public virtual void AddRange(ICollection<T> entities)
        {
            /*return*/ Repository.AddRange(entities);
        }

        public virtual void Edit(T entity)
        {
            /*return*/ Repository.Edit(entity);
        }

        public virtual void EditRange(ICollection<T> entities)
        {
            /*return*/ Repository.EditRange(entities);
        }

        public virtual void Update(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateExp)
        {
            /*return*/ Repository.Update(@where, updateExp);

        }

        public virtual void Update(T model, params string[] updateColumns)
        {
            /*return*/ Repository.Update(model, updateColumns);
        }

        public virtual void Delete(TKey key)
        {
            /*return*/ Repository.Delete(key);
        }

        public virtual void Delete(Expression<Func<T, bool>> @where)
        {
            /*return*/ Repository.Delete(where);
        }

        public virtual int ExecuteSqlWithNonQuery(string sql, params object[] parameters)
        {
            return Repository.ExecuteSqlWithNonQuery(sql, parameters);
        }

        public virtual IList<TView> CustomQuery<TView>(string sql, params object[] parameters) where TView : class, new()
        {
            return Repository.SqlQuery<TView>(sql, parameters);
        }

        public virtual void Dispose()
        {
            Repository.Dispose();
        }
    }
}
