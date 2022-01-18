using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeManagement.Data.Implementaion
{
    public class Repository<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly EmployeeManagementContext _context;
        internal DbSet<T> dbSet;

        public Repository(EmployeeManagementContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }


        /// <summary>
        /// Add To T type entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// It returns all the data in the table according to the parameters we have given. If we do not give parameters, it returns all the data in the table.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        /// <summary>
        /// It returns the first data in the table according to the parameters we have given. If we do not give a parameter, it returns the first data in the table.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault(); ;
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
