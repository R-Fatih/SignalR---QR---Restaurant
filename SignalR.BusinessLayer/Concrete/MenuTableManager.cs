using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;

		public MenuTableManager(IMenuTableDal menuTableDal)
		{
			_menuTableDal = menuTableDal;
		}

		public int TMenuTableCount()
		{
		return _menuTableDal.MenuTableCount();
		}

		void IGenericService<MenuTable>.TAdd(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		void IGenericService<MenuTable>.TDelete(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		MenuTable IGenericService<MenuTable>.TGetById(int id)
		{
			throw new NotImplementedException();
		}

		List<MenuTable> IGenericService<MenuTable>.TGetListAll()
		{
			throw new NotImplementedException();
		}

		void IGenericService<MenuTable>.TUpdate(MenuTable entity)
		{
			throw new NotImplementedException();
		}
	}
}
