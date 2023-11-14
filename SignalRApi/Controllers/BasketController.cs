using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;
using System.Net.Http;
using System.Text;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            return Ok(_basketService.TGetBasketByMenuTableNumber(id));
        }
        [HttpGet("BasketListByMenuTableNumberWithProductName")]
        public IActionResult BasketListByMenuTableNumberWithProductName(int id)
        {
            using var context = new SignalRContext();
            return Ok(context.Baskets.Include(a => a.Product).Where(b => b.MenuTableId == id).Select(c => new ResultBasketListWithProducts
            {
                BasketId = c.BasketId,
                MenuTableId = c.MenuTableId,
                Count = c.Count,
                Price = c.Price,
                ProductId = c.ProductId,
                ProductName = c.Product.ProductName,
                TotalPrice = c.TotalPrice


            }).ToList());
        }

        [HttpPost]
        public IActionResult AddBasket(CreateBasketDto createBasketDto)
        {
            var context = new SignalRContext();
            _basketService.TAdd(new Basket
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = 4,
                Price = context.Products.Where(a => a.ProductId == createBasketDto.ProductId).Select(b => b.Price).FirstOrDefault(),
                TotalPrice = 0,
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki seçilen ürün silindi");
        }

    }
}
