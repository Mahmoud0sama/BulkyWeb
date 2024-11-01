using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IOrderHeaderRepo:IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);
		void UpdateStatus(int id, string orderStatus, string? paymentStatus=null);
		void UpdateStipePaymentId(int id, string sessionId,string paymentIntentId);
	}
}
