using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
              
              
                Title=createTestimonialDto.Title,
                Comment=createTestimonialDto.Comment,
                ImageUrl=createTestimonialDto.ImageUrl,
                Name=createTestimonialDto.Name,
                Status=createTestimonialDto.Status

            });
            return Ok("Testimonial has been added succesfully.");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial has been removed succesfully.");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            
            _testimonialService.TUpdate(new Testimonial()
            {
            
                
        
                Title=updateTestimonialDto.Title,   
                Comment=updateTestimonialDto.Comment,   
                Status=updateTestimonialDto.Status
                ,Name=updateTestimonialDto.Name
                ,ImageUrl=updateTestimonialDto.ImageUrl
                ,TestimonialId=updateTestimonialDto.TestimonialId
            });
            return Ok("Testimonial has been updated succesfully.");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
