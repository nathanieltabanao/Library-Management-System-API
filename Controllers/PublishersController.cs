using Library_Management_System_.API.DataAccess;
using Library_Management_System_.API.Models;
using Library_Management_System_.API.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library_Management_System_.API.Controllers
{
    [Route("publishers")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private LMSDBContext _LMSDBContext;

        public PublishersController(LMSDBContext lMSDBContext)
        {
            _LMSDBContext = lMSDBContext;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var publishers = _LMSDBContext.Publishers.Where(p => !p.IsDeleted).ToList();

            return Ok(publishers);
        }

        [HttpPost]
        public IActionResult NewPublisher([FromBody]Publisher _publisher)
        {
            Publishers publisher = new Publishers
            {
                Id = new Guid(),
                Name = _publisher.name,
                IsDeleted = false
            };
            _LMSDBContext.Publishers.Add(publisher);
            _LMSDBContext.SaveChanges();
            return Ok("Publisher successfully created.");
        }

        [Route("{publisherId}")]
        [HttpPut]
        public IActionResult EditPublisher(Guid publisherId, [FromBody] Publisher _publisher)
        {
            var publisher = _LMSDBContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
            publisher.Name = _publisher.name;
            _LMSDBContext.Publishers.Update(publisher);
            _LMSDBContext.SaveChanges();
            return Ok("Publisher successfully updated.");
        }

        [Route("{publisherId}")]
        [HttpDelete]
        public IActionResult DeletePublisher(Guid publisherId)
        {
            var publisher = _LMSDBContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
            publisher.IsDeleted = true;
            _LMSDBContext.Publishers.Update(publisher);
            _LMSDBContext.SaveChanges();
            return Ok("Publisher successfully deleted.");
        }
    }
}
