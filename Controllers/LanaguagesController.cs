using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System_.API.DataAccess;
using Library_Management_System_.API.Models;
using Library_Management_System_.API.Models.Base;
using System;
using System.Linq;

namespace Library_Management_System_.API.Controllers
{
    [Route("languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private LMSDBContext _LMSDBContext;

        public LanguagesController(LMSDBContext lMSDBContext)
        {
            _LMSDBContext = lMSDBContext;
        }

        [HttpGet]
        public IActionResult GetLanguages()
        {
            var languages = _LMSDBContext.Languages.Where(l => !l.IsDeleted);
            return Ok(languages);
        }

        [HttpPost]
        public IActionResult NewLanguage([FromBody]Language _language)
        {
            Languages language = new Languages
            {
                Id = new Guid(),
                Name = _language.name,
                Code = _language.languageCode,
                IsDeleted = false
            };

            _LMSDBContext.Languages.Add(language);
            _LMSDBContext.SaveChanges();
            return Ok("Language successfully created.");
        }

        [Route("{languageId}")]
        [HttpPut]
        public IActionResult EditLanguage(Guid languageId, [FromBody]Language _language)
        {
            var language = _LMSDBContext.Languages.Where(l=> l.Id==languageId).FirstOrDefault();
            language.Name = _language.name;
            language.Code = _language.languageCode;
            _LMSDBContext.Languages.Update(language);
            _LMSDBContext.SaveChanges();
            return Ok("Language successfully updated.");

        }

        [Route("{languageId}")]
        [HttpDelete]
        public IActionResult DeleteLanguage(Guid languageId)
        {
            var language = _LMSDBContext.Languages.Where(l => l.Id == languageId).FirstOrDefault();
            language.IsDeleted = true;
            _LMSDBContext.Languages.Update(language);
            _LMSDBContext.SaveChanges();
            return Ok("Language successfully deleted.");
        }
    }
}
