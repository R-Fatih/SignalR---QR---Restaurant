using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationsByFalse")]
		public IActionResult GetAllNotificationsByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationsByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			_notificationService.TAdd(new Notification()
			{
				Date = DateTime.UtcNow.AddHours(3),
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Status = false,
				Type = createNotificationDto.Type
			});
			return Ok("Bildirim başarıyla eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim başarıyla silindi.");

		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			_notificationService.TUpdate(new Notification()
			{
				Date = updateNotificationDto.Date,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
				NotificationId = updateNotificationDto.NotificationId
			});
			return Ok("Bildirim başarıyla güncellendi.");
		}
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Bildirim başarıyla güncellendi.");

		}
		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Bildirim başarıyla güncellendi.");

		}
	}
}
