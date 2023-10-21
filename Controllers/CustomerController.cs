using eProject3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceMarketingSystem.Data;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class CustomerController : ControllerBase
    {
        private readonly DbConnection _Db;

        public CustomerController(DbConnection db)
        {
            _Db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> ListCustomer()
        {
            if(_Db.Customers == null)
            {
                return NotFound();
            }
            return _Db.Customers.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer([FromBody] Customer newCustomer)
        {
            Boolean flag = true;
            bool existedEmail = await _Db.Customers.AnyAsync(c=> c.Cus_email.Equals(newCustomer.Cus_email));
            if (newCustomer == null)
            {
                flag = false;
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if (DupplicatedCode(newCustomer.Cus_code))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedCustomerCode", "Customer Code is dupplicated");
                return Ok(ModelState);
            }
            if (Dupplicated(newCustomer.Cus_name))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedCustomerName", "Customer Name is dupplicated");
                return Ok(ModelState);
            }
            Customer customer = new Customer();
            if(flag && !existedEmail)
            {
                customer.Cus_name = newCustomer.Cus_name;
                customer.Cus_code = newCustomer.Cus_code;
                customer.Cus_phone = newCustomer.Cus_phone;
                customer.Cus_address = newCustomer.Cus_address;
                customer.Cus_email = newCustomer.Cus_email;
                customer.Password = BCrypt.Net.BCrypt.HashPassword(newCustomer.Password);
                _Db.Customers.Add(customer);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.Customers);
        }

        private Boolean Dupplicated(string? name)
        {
            Boolean flag = false;
            List<Customer> customers = _Db.Customers.Where(c => c.Cus_name.ToLower().Equals(name.ToLower())).ToList();
            if(customers.Any())
            {
                flag = true;
            }
            return flag;
        }

        private Boolean DupplicatedCode(string? code)
        {
            Boolean flag = false;
            List<Customer> customers = _Db.Customers.Where(c => c.Cus_code.Equals(code)).ToList();
            if (customers.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<Customer> UpdateCustomer(Customer newCustomer)
        {
            Customer customer = _Db.Customers.Where(c => c.Id == newCustomer.Id).FirstOrDefault();
            Boolean flag = true;
            if(customer == null)
            {
                flag = false;
                return NotFound($"Could not find customer with id = {newCustomer.Id}");
            }
            if(!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(flag)
            {
                customer.Cus_name = newCustomer.Cus_name;
                customer.Cus_code = newCustomer.Cus_code;
                customer.Cus_phone = newCustomer.Cus_phone;
                customer.Cus_address = newCustomer.Cus_address;
                customer.Cus_email = newCustomer.Cus_email;
                customer.Password = BCrypt.Net.BCrypt.HashPassword(newCustomer.Password);
                _Db.Customers.Update(customer);
                _Db.SaveChanges();
            }
            return Ok(_Db.Customers);
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = _Db.Customers.FirstOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound($"Could not find customer with id = {id}");
            }

            _Db.Customers.Remove(customer);
            _Db.SaveChanges();
            
            return Ok(_Db.Customers);

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            Customer customer = _Db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound($"Could not find customer with id = {id}");
            }
            return Ok(customer);
        }
    }
}
