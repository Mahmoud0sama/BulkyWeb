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
	public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
	{
		private readonly AppDbContext _db;

		public ApplicationUserRepo(AppDbContext db) : base(db)
		{
			_db = db;

		}
		public void Update(ApplicationUser obj)
		{
			_db.Update(obj);
		}



	}
}
