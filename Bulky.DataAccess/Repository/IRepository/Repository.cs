using BulkyWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _db;

		internal DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
			_db = db;
			this.dbSet= _db.Set<T>();
        }
        public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> querry=dbSet;
			querry=querry.Where(filter);
			return querry.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> querry=dbSet;
			return querry.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
