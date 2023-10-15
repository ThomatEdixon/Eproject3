using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class RoleController : ControllerBase
    {
        private readonly DbConnection _Db;
        public RoleController(DbConnection _db)
        {
            _Db = _db;
        }
        [HttpPost]
        public IActionResult Add(Roles r)
        {
            bool flag = true;
            if (r is null)
            {
                flag = false;
                return NotFound();
            }
            if (flag)
            {
                _Db.Roles.Add(r);
                _Db.SaveChanges();
            }
            return Ok(r);
        }
        [HttpGet]
        [Route("id")]
        public IActionResult GetById(int id)
        {
            Roles r = _Db.Roles.Find(id);
            if (r == null)
            {
                return NotFound();
            }
            return Ok(r);
        }
    }
}
