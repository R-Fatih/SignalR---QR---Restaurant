using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate= DateTime.Now,
				NameSurname=createMessageDto.NameSurname,
				Phone=createMessageDto.Phone,
				Status=false,
				Subject=createMessageDto.Subject,
			};
			_messageService.TAdd(message);
			return Ok("Message has been added succesfully.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Message has been removed succesfully.");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message
			{
				Subject = updateMessageDto.Subject,
				Status = updateMessageDto.Status,
				Phone = updateMessageDto.Phone,
				NameSurname = updateMessageDto.NameSurname,
				MessageSendDate =updateMessageDto.MessageSendDate,
				MessageContent=updateMessageDto.MessageContent,
				Mail=updateMessageDto.Mail,
				MessageId=updateMessageDto.MessageId,
			};
			_messageService.TUpdate(message);
			return Ok("Message has been updated succesfully.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);
			return Ok(value);
		}
	}
}
