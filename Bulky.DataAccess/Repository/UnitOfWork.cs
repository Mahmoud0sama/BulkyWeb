using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public ICategoryRepo Category { get; private set; }

        public IProductRepo Product { get; private set; }
        public ICompanyRepo Company { get; private set; }

        public IShoppingCartRepo ShoppingCart { get; private set; }

        public IApplicationUserRepo ApplicationUser { get; private set; }
        public IOrderHeaderRepo OrderHeader { get; private set; }
        public IOrderDetailRepo OrderDetail { get; private set; }

        public IProductImageRepo ProductImage { get; private set; }


        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepo(_db);
            ShoppingCart = new ShoppingCartRepo(_db);
            Category = new CategoryRepo(_db);
            Product = new ProductRepo(_db);
            Company = new CompanyRepo(_db);
            OrderHeader = new OrderHeaderRepo(_db);
            OrderDetail = new OrderDetailRepo(_db);
            ProductImage = new ProductImageRepo(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
