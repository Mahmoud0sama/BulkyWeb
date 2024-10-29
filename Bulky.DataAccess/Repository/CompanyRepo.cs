using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CompanyRepo : Repository<Company>, ICompanyRepo
    {
        private readonly AppDbContext _db;
        public CompanyRepo(AppDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
