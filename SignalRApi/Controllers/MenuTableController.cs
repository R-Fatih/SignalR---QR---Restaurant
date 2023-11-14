using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}
		[HttpGet("MenuTableCount")]
		public ActionResult MenuTableCount()
		{
			return Ok( _menuTableService.TMenuTableCount());
		}
		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable
			{
				Name = createMenuTableDto.Name,
				Status = false,
			};
			_menuTableService.TAdd(MenuTable);
			return Ok("MenuTable has been added succesfully.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("MenuTable has been removed succesfully.");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable
			{
				MenuTableId = updateMenuTableDto.MenuTableId,
				Status = true,
				Name = updateMenuTableDto.Name,
			};
			_menuTableService.TUpdate(MenuTable);
			return Ok("MenuTable has been updated succesfully.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(value);
		}
	}
}
