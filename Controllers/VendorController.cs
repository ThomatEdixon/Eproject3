using eProject3.Data;
using eProject3.Model;
using Microsoft.AspNetCore.Mvc;

namespace eProject3.Controllers
{
    [ApiController]
    [Route("/Api/[Controller]/[Action]")]
    public class VendorController : ControllerBase
    {
        private readonly DataConnection? _Db;
        public VendorController(DataConnection? Db)
        {
            _Db = Db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> ListVendor()
        {
            if(_Db.Vendors == null)
            {
                return NotFound();
            }
            return _Db.Vendors.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVendor(Vendor vendor)
        {
            Boolean flag = true;
            if(vendor == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(Dupplicated(vendor.Vendor_name))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedVendorName", "Vendor name is dupplicated!");
                return Ok(ModelState);
            }
            if(flag)
            {
                _Db.Vendors.Add(vendor);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.Vendors);
        }

        private Boolean Dupplicated(string name)
        {
            Boolean flag = false;
            List<Vendor> vendors = _Db.Vendors.Where(v => v.Vendor_name.ToLower().Equals(name.ToLower())).ToList();
            if(vendors.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<Vendor> UpdateVendor(Vendor newVendor) {
            Vendor vendor = _Db.Vendors.Where(c => c.Id == newVendor.Id).FirstOrDefault();
            Boolean flag = true;
            if(vendor == null)
            {
                flag = false;
                return NotFound($"Could not find vendor with id = {newVendor.Id}");
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(flag)
            {
                vendor.Vendor_name = newVendor.Vendor_name;
                vendor.Vendor_phone = newVendor.Vendor_phone;
                vendor.Vendor_address = newVendor.Vendor_address;
                vendor.Vendor_email = newVendor.Vendor_email;
                _Db.Vendors.Update(vendor);
                _Db.SaveChanges();
            }
            return Ok(_Db.Vendors);
        }

        [HttpDelete]
        public ActionResult DeleteVendor(int id)
        {
            Vendor vendor = _Db.Vendors.FirstOrDefault(v => v.Id == id);
            if(vendor == null)
            {
                return NotFound($"Could not find vendor with id = {id}");
            }

            _Db.Vendors.Remove(vendor);
            _Db.SaveChanges();
            return Ok(_Db.Vendors);
        }

        [HttpGet]
        public async Task<IActionResult> GetVendorById(int id)
        {
            Vendor vendor = _Db.Vendors.FirstOrDefault(c => c.Id == id);
            if (vendor == null)
            {
                return NotFound($"Could not find vendor with id = {id}");
            }
            return Ok(vendor);
        }
    }
}
