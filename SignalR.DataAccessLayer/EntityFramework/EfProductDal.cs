using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values = context.Products.Include(a => a.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
using (var context=new SignalRContext())
            {
                return context.Products.Count();
            }
		}

		public int ProductCountByCategoryNameDrink()
		{
            using var context=new SignalRContext();
            return context.Products.Where(a=>a.CategoryId==(context.Categories.Where(b=>b.CategoryName=="İçecek").Select(c=>c.CategoryId).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(a => a.CategoryId == (context.Categories.Where(b => b.CategoryName == "Hamburger").Select(c => c.CategoryId).FirstOrDefault())).Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(a => a.Price == (context.Products.Max(a => a.Price))).Select(b => b.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(a => a.Price == (context.Products.Min(a => a.Price))).Select(b => b.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
using var context=new SignalRContext();
            return context.Products.Average(a => a.Price);
		}
	}
}
