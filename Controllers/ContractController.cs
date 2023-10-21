using eProject3.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;

namespace eProject3.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class ContractController : Controller
    {
        private readonly DbConnection? _Db;
        public ContractController(DbConnection? db)
        {
            _Db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contract>> ListContract()
        {
            if(_Db.Contracts == null)
            {
                return NotFound();
            }
            return _Db.Contracts.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewContract(Contract contract)
        {
            Boolean flag = true;
            Service service = _Db.Services.Find(contract.Ser_id);
            Customer customer = _Db.Customers.Find(contract.Cus_id);
            if(contract == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(DupplicatedCode(contract.Contract_code))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedContractCode", "Contract Code is dupplicated!");
                return Ok(ModelState);
            }
            if(service is null)
            {
                flag = false;
                ModelState.AddModelError("ServiceNotFound", "Service is not found!");
                return Ok(ModelState);
            }
            if (customer is null)
            {
                flag = false;
                ModelState.AddModelError("CustomerNotFound", "Customer is not found!");
                return Ok(ModelState);
            }
            if(flag)
            {
                _Db.Contracts.Add(contract);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.Contracts);
        }

        private Boolean DupplicatedCode(string code)
        {
            Boolean flag = false;
            List<Contract> contracts = _Db.Contracts.Where(c => c.Contract_code.Equals(code)).ToList();
            if(contracts.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<Contract> UpdateContract(Contract newContract)
        {
            Boolean flag = true;
            Contract contract = _Db.Contracts.Where(c => c.Id == newContract.Id).FirstOrDefault();
            if (contract == null)
            {
                flag = false;
                return NotFound($"Could not find service with id = {newContract.Id}");
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if (flag)
            {
                contract.Contract_code = newContract.Contract_code;
                contract.Contract_date = newContract.Contract_date;
                contract.Expire_date = newContract.Expire_date;
                contract.Total_amount = newContract.Total_amount;
                contract.Cus_id = newContract.Cus_id;
                contract.Ser_id = newContract.Ser_id;   
                contract.Deposit = newContract.Deposit;
                _Db.Contracts.Update(contract);
                _Db.SaveChanges();
            }
            return Ok(_Db.Contracts);
        }

        [HttpDelete] 
        public ActionResult DeleteContract(int id) {
            Contract contract = _Db.Contracts.FirstOrDefault(x => x.Id == id);
            if(contract == null)
            {
                return NotFound($"Could not find contract with id = {id}");
            }
            
            _Db.Contracts.Remove(contract);
            _Db.SaveChanges();
            return Ok(_Db.Contracts);
        }

        [HttpGet]
        public async Task<IActionResult> GetContractById(int id)
        {
            Contract contract = _Db.Contracts.FirstOrDefault(c => c.Id == id);
            if (contract == null)
            {
                return NotFound($"Could not find contract with id = {id}");
            }
            return Ok(contract);
        }
    }
}
