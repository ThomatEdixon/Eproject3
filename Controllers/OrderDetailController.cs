
using eProject3.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;

namespace eProject3.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly DbConnection? _Db;
        public OrderDetailController(DbConnection? Db)
        {
            _Db = Db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> ListOrderDetail()
        {
            if(_Db.OrderDetails == null)
            {
                return NotFound();
            }
            return _Db.OrderDetails.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrderDetail(OrderDetail orderDetail)
        {
            Boolean flag = true;
            Order order = _Db.Orders.Find(orderDetail.Order_id);
            if(orderDetail == null)
            {
                flag = false;
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(DupplicatedCode(orderDetail.Account_code))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedAccountCode", "Account Code is dupplicated!");
                return Ok(ModelState);
            }
            if(order == null)
            {
                flag = false;
                ModelState.AddModelError("OrderNotFound", "Order is not found");
                return Ok(ModelState);
            }
            if(flag)
            {
                _Db.OrderDetails.Add(orderDetail);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.OrderDetails);
        }

        private Boolean DupplicatedCode(string code)
        {
            Boolean flag = false;
            List<OrderDetail> orderDetails = _Db.OrderDetails.Where(od => od.Account_code.Equals(code)).ToList();
            if(orderDetails.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<OrderDetail> UpdateOrderDetail(int id, OrderDetail newOrderDetail)
        {
            OrderDetail orderDetail = _Db.OrderDetails.Find(id);
            Boolean flag = true;
            if(orderDetail == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if (flag)
            {
                orderDetail.Order_id = newOrderDetail.Order_id;
                orderDetail.Account_code = newOrderDetail.Account_code;
                orderDetail.Amount = newOrderDetail.Amount;
                orderDetail.Active = newOrderDetail.Active;
                _Db.OrderDetails.Update(orderDetail);
                _Db.SaveChanges();
            }
            return Ok(_Db.OrderDetails);
        }

        [HttpDelete]
        public ActionResult DeleteOrderDetail(int id)
        {
            OrderDetail orderDetail = _Db.OrderDetails.FirstOrDefault(od => od.Id == id);   
            if (orderDetail == null)
            {
                return NotFound($"Could not find order detail with id = {id}");
            }

            _Db.OrderDetails.Remove(orderDetail);
            _Db.SaveChanges();
            return Ok(_Db.OrderDetails);
        }
    }
}
