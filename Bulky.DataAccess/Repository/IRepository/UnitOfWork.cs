﻿using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _db;

		public ICategoryRepo Category { get; private set; }

        public IProductRepo Product { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;

			Category= new CategoryRepo(_db);
			Product= new ProductRepo(_db);
        }
        

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
