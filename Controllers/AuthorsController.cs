using Library_Management_System_.API.DataAccess;
using Library_Management_System_.API.Models;
using Library_Management_System_.API.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library_Management_System_.API.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private LMSDBContext _LMSDBContext;

        public AuthorsController(LMSDBContext lMSDBContext)
        {
            _LMSDBContext = lMSDBContext;
        }


        [HttpGet]
        public IActionResult GetAuthorsList()
        {
            var authorsList = _LMSDBContext.Authors.Where(a => !a.IsDeleted).ToList();

            return Ok(authorsList);
        }

        [HttpPost]
        public IActionResult NewAuthor([FromBody] Author _author)
        {
            try
            {
                Authors author = new Authors
                {
                    Id = new Guid(),
                    FirstName = _author.firstName,
                    LastName = _author.lastName,
                    IsDeleted = false
                };

                _LMSDBContext.Authors.Add(author);
                _LMSDBContext.SaveChanges();
                return Ok("Author successfully created.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Route("{authorId}")]
        [HttpPut]
        public IActionResult EditAuthor(Guid authorId, [FromBody]Author _author)
        {
            try
            {
                var author = _LMSDBContext.Authors.FirstOrDefault(a => a.Id == authorId);
                author.FirstName = _author.firstName;
                author.LastName = _author.lastName;
                _LMSDBContext.Authors.Update(author);
                _LMSDBContext.SaveChanges();
                return Ok("Author succesfully updated.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


        }

        [Route("{authorId}")]
        [HttpDelete]
        public IActionResult DeleteAuthor(Guid authorId)
        {
            try
            {
                var author = _LMSDBContext.Authors.FirstOrDefault(a => a.Id == authorId);
                author.IsDeleted = true;
                _LMSDBContext.Authors.Update(author);
                _LMSDBContext.SaveChanges();
                return Ok("Author succesfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
