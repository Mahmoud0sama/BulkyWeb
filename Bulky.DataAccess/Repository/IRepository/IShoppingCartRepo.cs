using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IShoppingCartRepo:IRepository<ShoppingCart>
	{
		void Update(ShoppingCart obj);
	}
}
