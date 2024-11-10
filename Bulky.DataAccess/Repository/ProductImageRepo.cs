using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductImageRepo : Repository<ProductImage>, IProductImageRepo
    {
        private readonly AppDbContext _db;

        public ProductImageRepo(AppDbContext db) : base(db)
        {
            _db = db;

        }
		public void Update(ProductImage obj)
		{
			_db.Update(obj);
		}


	}
}
