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
    public class OrderDetailRepo : Repository<OrderDetail>, IOrderDetailRepo
    {
        private readonly AppDbContext _db;

        public OrderDetailRepo(AppDbContext db) : base(db)
        {
            _db = db;

        }
		public void Update(OrderDetail obj)
		{
			_db.OrderDetails.Update(obj);
		}


	}
}
