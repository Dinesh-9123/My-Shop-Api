using Dapper.Contrib.Extensions;
using MyShopsData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace MyShopsData.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        private IDbConnection _dbContext;
        public BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public string TableName
        {
            get
            {
                var tableAttributes = typeof(T).GetCustomAttributes(typeof(TableAttribute), false);
                if (tableAttributes != null && tableAttributes.Length > 0)
                {
                    var tableAttribute = (TableAttribute)tableAttributes[0];
                    if (tableAttribute != null)
                    {
                        return tableAttribute.Name;
                    }
                }
                return string.Empty;
            }
        }

        protected IDbConnection DataContext
        {
            get { return _dbContext ??= DatabaseFactory.Get(); }
        }

        public virtual long Add(T entity)
        {
            return DataContext.Insert(entity);
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            return await DataContext.InsertAsync(entity);
        }

        public virtual long Add(IEnumerable<T> entities)
        {
            return DataContext.Insert(entities);
        }

        public virtual async Task<long> AddAsync(IEnumerable<T> entities)
        {
            return await DataContext.InsertAsync(entities);
        }

        public virtual bool Update(T entity)
        {
            return DataContext.Update(entity);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            return await DataContext.UpdateAsync(entity);
        }

        public virtual bool Delete(T entity)
        {
            return DataContext.Delete(entity);
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            return await DataContext.DeleteAsync(entity);
        }

        public virtual T Get(object id)
        {
            return DataContext.Get<T>(id);
        }

        public virtual async Task<T> GetAsync(object id)
        {
            return await DataContext.GetAsync<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DataContext.GetAll<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DataContext.GetAllAsync<T>();
        }
    }
}
