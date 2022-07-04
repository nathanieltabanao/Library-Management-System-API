using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System_.API.DataAccess;
using Library_Management_System_.API.Models;
using Library_Management_System_.API.Models.Base;
using System;
using System.Linq;

namespace Library_Management_System_.API.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private LMSDBContext _LMSDBContext;

        public CategoriesController(LMSDBContext lMSDBContext)
        {
            _LMSDBContext = lMSDBContext;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _LMSDBContext.Categories.Where(c => !c.IsDeleted).ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult NewCategory([FromBody] Category _category)
        {
            Categories category = new Categories
            {
                Id = new Guid(),
                Name = _category.Name,
                IsDeleted = false
            };
            _LMSDBContext.Categories.Add(category);
            _LMSDBContext.SaveChanges();
            return Ok("Category successfully created.");
        }

        [Route("{categoryId}")]
        [HttpPut]
        public IActionResult EditCategory(Guid categoryId, [FromBody] Category _category)
        {
            var category = _LMSDBContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            category.Name = _category.Name;
            _LMSDBContext.Categories.Update(category);
            _LMSDBContext.SaveChanges();
            return Ok("Category successfully updated.");
        }

        [Route("{categoryId}")]
        [HttpDelete]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var category = _LMSDBContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            category.IsDeleted = true;
            _LMSDBContext.Categories.Update(category);
            _LMSDBContext.SaveChanges();
            return Ok("Category successfully deleted.");
        }
    }
}
