using eProject3.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class ServiceController : ControllerBase
    {
        private readonly DbConnection? _Db;
        public ServiceController(DbConnection? Db)
        {
            _Db = Db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Service>> ListService()
        {
            if(_Db.Services == null)
            {
                return NotFound();
            }
            return _Db.Services.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewService(Service service)
        {
            Boolean flag = true;
            if(service == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(Dupplicated(service.Ser_name))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedServiceName", "Service name is dupplicated!");
                return Ok(ModelState);
            }
            if(flag)
            {
                _Db.Services.Add(service);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.Services);
        }

        private Boolean Dupplicated(string name)
        {
            Boolean flag = false;
            List<Service> services = _Db.Services.Where(s => s.Ser_name.ToLower().Equals(name.ToLower())).ToList();
            if(services.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<Service> UpdateService(int id, Service newService)
        {
            Service service = _Db.Services.Find(id);
            Boolean flag = true;
            if(service == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(flag)
            {
                service.Ser_name = newService.Ser_name;
                service.Ser_device = newService.Ser_device;
                service.Ser_price = newService.Ser_price;
                _Db.Services.Update(service);
                _Db.SaveChanges();
            }
            return Ok(_Db.Services);
        }

        [HttpDelete] 
        public ActionResult DeleteService(int id) {
            Service service = _Db.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound($"Could not find service with id = {id}");
            }

            _Db.Services.Remove(service);
            _Db.SaveChanges();
            return Ok(_Db.Services);
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceById(int id)
        {
            Service service = _Db.Services.FirstOrDefault(c => c.Id == id);
            if (service == null)
            {
                return NotFound($"Could not find service with id = {id}");
            }
            return Ok(service);
        }
    }
}
