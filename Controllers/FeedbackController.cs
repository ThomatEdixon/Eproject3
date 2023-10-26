using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class FeedbackController : ControllerBase
    {
        private readonly DbConnection? _Db;
        public FeedbackController(DbConnection? db)
        {
            _Db = db;
        }
        [HttpGet]
        public IEnumerable<Feedback> ListFeedBack()
        {
            return _Db.Feedbacks.ToArray();
        }
        [HttpPost]
        public IActionResult AddFeedBack(Feedback feedback)
        {
            if(feedback is null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid) {
                return Ok(ModelState);
            }
            _Db.Feedbacks.Add(feedback);
            _Db.SaveChanges();
            return Ok(feedback);
        }
        [HttpPut]
        public IActionResult EditFeedBack(Feedback newfeedback)
        {
            Feedback? feedback = _Db.Feedbacks.Find(newfeedback.Id); 
            if(feedback is null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return Ok(ModelState);
            }
            feedback.Rating = newfeedback.Rating;
            feedback.Content = newfeedback.Content;
            feedback.Product_id = newfeedback.Product_id;
            _Db.Feedbacks.Update(feedback);
            _Db.SaveChanges();
            return Ok(newfeedback);
        }
        [HttpDelete]
        public IActionResult DeleteFeedBack(Feedback feedback)
        {
            Feedback? oldfeedback = _Db.Feedbacks.Find(feedback.Id);
            if(oldfeedback is null)
            {
                return NotFound();
            }
            _Db.Feedbacks.Remove(feedback);
            _Db.SaveChanges();
            return Ok(_Db.Feedbacks);
        }
        [HttpGet]
        public IActionResult GetListFeedbackByProductId(int id)
        {
            var listFeedback = (from f in _Db.Feedbacks
                                join p in _Db.Products on f.Product_id equals p.Id 
                                where p.Id == id
                                select new
                                {
                                    p.Prd_name,
                                    p.Prd_price,
                                    f.Rating,
                                    f.Content
                                });
            return Ok(listFeedback);
        }
        
    }
}
