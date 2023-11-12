﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public void TAdd(Order entity)
		{
		_orderDal.Add(entity);
		}

		public void TDelete(Order entity)
		{
	_orderDal.Delete(entity);
		}

		public Order TGetById(int id)
		{
		var value= _orderDal.GetById(id);
			return value;
		}

		public List<Order> TGetListAll()
		{
		var values=_orderDal.GetListAll();
			return values;
		}

		public void TUpdate(Order entity)
		{
		_orderDal.Update(entity);
		}
	}
}
