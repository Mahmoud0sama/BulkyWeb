using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        private readonly AppDbContext _db;

        public ProductRepo(AppDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(Product obj)
        {
            _db.Update(obj);
        }


    }
}
