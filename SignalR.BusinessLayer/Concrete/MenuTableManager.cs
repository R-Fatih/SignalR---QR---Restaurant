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
			_menuTableDal.Add(entity);
		}

		void IGenericService<MenuTable>.TDelete(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
		}

		MenuTable IGenericService<MenuTable>.TGetById(int id)
		{
			return _menuTableDal.GetById(id);
		}

		List<MenuTable> IGenericService<MenuTable>.TGetListAll()
		{
			return _menuTableDal.GetListAll();
		}

		void IGenericService<MenuTable>.TUpdate(MenuTable entity)
		{
			_menuTableDal.Update(entity);
		}
	}
}
