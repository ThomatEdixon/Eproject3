﻿using Microsoft.AspNetCore.Mvc;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class StoreController : ControllerBase
    {
        private readonly DbConnection _Db;
        public StoreController(DbConnection db)
        {
            _Db = db;
        }
        [HttpPost]
        public IActionResult AddNewStore(Stores store)
        {
            bool flag = true;
            if (store is null)
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
                _Db.Add(store);
                _Db.SaveChanges();
            }
            return Ok(store);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Stores>> ListStore()
        {
            if (_Db.Stores == null)
            {
                return NotFound();
            }
            return _Db.Stores.ToList();
        }
        [HttpDelete]
        public IActionResult DeleteStore(int id)
        {
            Stores? stores = _Db.Stores.Find(id);
            if (stores is null)
            {
                return NotFound();
            }
            _Db.Stores.Remove(stores);
            _Db.SaveChanges();
            return Ok(stores);
        }
        [HttpPut]
        public IActionResult UpdateStore(Stores store)
        {
            Stores? s = _Db.Stores.Find(store.Id);
            if (s is null)
            {
                return NotFound($"Could not find store with id = {store.Id}");
            }
            s.StoreAddress = store.StoreAddress;
            s.StoreName = store.StoreName;
            _Db.Stores.Update(s);
            _Db.SaveChanges();
            return Ok(store);
        }
        [HttpGet]
        public IActionResult GetStoreByName(string name)
        {
            Stores? store = _Db.Stores.SingleOrDefault(s => s.StoreName.Equals(name));
            if (store is null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpGet]
        public IActionResult GetStoreById(int id)
        {
            Stores store = _Db.Stores.FirstOrDefault(s => s.Id == id);
            if (store == null)
            {
                return NotFound($"Could not find store with id = {id}");
            }
            return Ok(store);
        }
    }
}