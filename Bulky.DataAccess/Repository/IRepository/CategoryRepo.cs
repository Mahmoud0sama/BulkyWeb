using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
	public class CategoryRepo : Repository<Category>,ICategoryRepo
	{
		private readonly AppDbContext _db;

        public CategoryRepo(AppDbContext db):base(db)
        {
			_db = db;
            
        }

		public void Update(Category obj)
		{
			_db.Update(obj);
		}
	}
}
