using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using (var context = new SignalRContext())
			{
				return context.Orders.Where(a => a.Description == "Müşteri masada").Count();
			}
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();

			return context.Orders.OrderByDescending(a => a.OrderId).Take(1).Select(b => b.TotalPrice).FirstOrDefault();

		}

		public decimal TodayTotalPrice()
		{DateTime dt=DateTime.Now;
			using(var context = new SignalRContext())
			{
				return context.Orders.Where(a => a.Date.Date == dt.Date).Sum(b => b.TotalPrice);
			}
		}

		public int TotalOrderCount()
		{
			using (var context = new SignalRContext())
			{
				return context.Orders.Count();
			}
		}
	}
}
