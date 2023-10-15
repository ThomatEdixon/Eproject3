using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class SlugController : ControllerBase
    {
        private readonly DbConnection _Db;
        public SlugController(DbConnection db)
        {
            _Db = db;
        }
        [HttpPost]
        public IActionResult Add(Slug slug)
        {
            bool flag = true;
            if (slug is null)
            {
                flag = false;
                return NotFound();
            }
            if (flag)
            {
                _Db.Slug.Add(slug);
                _Db.SaveChanges();
            }
            return Ok(slug);
        }
        [HttpGet]
        [Route("id")]
        public IActionResult GetById(int id)
        {
            Slug s = _Db.Slug.Find(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
    }
}
