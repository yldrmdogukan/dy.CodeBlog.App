using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.Core.Data.EF
{
    public class Repository<T, TContext> : IRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        TContext _context;
        public Repository(TContext context)
        {
            _context = context;
        }
        public bool Delete(T model)
        {
            try
            {
                model.IsActive = false;
                model.IsDelete = false;
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Get(Expression<Func<T, bool>> filter, params string[] includeList)
        {
            IQueryable<T> query = null;
            try
            {
                query = _context.Set<T>();
                if (includeList != null)
                {
                    foreach (var includeItem in includeList)
                    {
                        query = query.Include(includeItem);
                    }
                }
                return query.FirstOrDefault(filter);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter=null, params string[] includeList)
        {
            IQueryable<T> list = null;
            try
            {
                if (filter!=null)
                {
                    list = _context.Set<T>().Where(filter);
                }
                else
                {
                    list = _context.Set<T>();
                }
                if (includeList != null)
                {
                    foreach (var includeItem in includeList)
                    {
                        list = list.Include(includeItem);
                    }
                }

                return list.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(T model)
        {
            try
            {
                _context.Set<T>().Add(model);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T model)
        {
            try
            {
                model.Updated = DateTime.Now;
                _context.Entry(model).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
