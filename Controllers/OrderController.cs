using eProject3.Data;
using eProject3.Model;
using Microsoft.AspNetCore.Mvc;

namespace eProject3.Controllers
{
    [ApiController]
    [Route("/Api/[COntroller]/[Action]")]
    public class OrderController : ControllerBase
    {
        private readonly DataConnection _Db;
        public OrderController(DataConnection db)
        {
            _Db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> ListOrder()
        {
            if(_Db.Orders == null)
            {
                return NotFound();
            }
            return _Db.Orders.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrder(Order order)
        {
            Boolean flag = true;
            Product product = _Db.Products.Find(order.Product_id);
            Customer customer = _Db.Customers.Find(order.Customer_id);
            if(order == null)
            {
                flag = false;
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(product is null)
            {
                flag = false;
                ModelState.AddModelError("ProductNotFound", "Product is not found");
                return Ok(ModelState);
            }
            if (customer is null)
            {
                flag = false;
                ModelState.AddModelError("CustomerNotFound", "Customer is not found");
                return Ok(ModelState);
            }
            if(flag)
            {
                _Db.Orders.Add(order);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.Orders);
        }

        [HttpPut]
        public ActionResult<Order> UpdateOrder(int id, Order newOrder)
        {
            Order order = _Db.Orders.Find(id);
            Boolean flag = true;
            if(order == null)
            {
                flag = false;
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(flag)
            {
                order.Status = newOrder.Status;
                order.Order_date = newOrder.Order_date;
                order.Product_id = newOrder.Product_id;
                order.Customer_id = newOrder.Customer_id;
                order.Quantity = newOrder.Quantity;
                _Db.Orders.Update(order);
                _Db.SaveChanges();
            }
            return Ok(_Db.Orders);
        }

        [HttpDelete]
        public ActionResult DeleteOrder(int id)
        {
            Order order = _Db.Orders.FirstOrDefault(o => o.Id == id);

            if(order == null)
            {
                return NotFound($"Could not find order with id = {id}");
            }

            _Db.Orders.Remove(order);
            _Db.SaveChanges();
            return Ok(_Db.Orders);
        }

    }
}
