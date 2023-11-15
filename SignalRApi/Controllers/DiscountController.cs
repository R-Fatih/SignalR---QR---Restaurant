using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
               Amount = createDiscountDto.Amount,
               Description  = createDiscountDto.Description,
               ImageUrl = createDiscountDto.ImageUrl,
               Title = createDiscountDto.Title,
               Status=false

            });
            return Ok("Discount has been added succesfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Discount has been removed succesfully.");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            
            _discountService.TUpdate(new Discount()
            {
            
                Amount = updateDiscountDto.Amount,
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                DiscountId=updateDiscountDto.DiscountId,
                Status=updateDiscountDto.Status
            });
            return Ok("Discount has been updated succesfully.");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }
		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Discount has been updated to false succesfully.");
		}
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Discount has been updated to true succesfully.");
		}
		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue()
		{
			
			return Ok(_discountService.TGetListByStatusTrue());
		}
	}
}
