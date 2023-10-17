using eProject3.Data;
using eProject3.Model;
using Microsoft.AspNetCore.Mvc;

namespace eProject3.Controllers
{
    [ApiController]
    [Route("/Api/[Controller]/[Action]")]
    public class ProductController : ControllerBase
    {
        private readonly DataConnection? _Db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(DataConnection? Db,  IWebHostEnvironment hostEnvironment)
        {
            _Db = Db;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> ListProduct()
        {
            if(_Db.Products == null)
            {
                return NotFound();
            }
            return _Db.Products.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromForm]Product product)
        {
            Boolean flag = true;
            Vendor vendor = _Db.Vendors.Find(product.Vendor_id);
            if(product == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(Dupplicated(product.Prd_name))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedProductName", "Product Name is dupplicated!");
                return Ok(ModelState);
            }
            if(vendor is null)
            {
                flag = false;
                ModelState.AddModelError("VendorNotFound", "Vendor is not found!");
                return Ok(ModelState);
            }
            if(flag)
            {
                product.Avatar = await SaveImage(product.ImageFile);
                _Db.Products.Add(product);
                await _Db.SaveChangesAsync();
            }
            return Ok(_Db.Products);
        }

        private Boolean Dupplicated(string name)
        {
            Boolean flag = false;
            List<Product> products = _Db.Products.Where(p => p.Prd_name.ToLower().Equals(name.ToLower())).ToList();
            if(products.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product newProduct)
        {
            Boolean flag = true;
            Product product = _Db.Products.Where(c => c.Id == newProduct.Id).FirstOrDefault();
            if(product == null)
            {
                flag = false;
                return NotFound($"Could not find customer with id = {newProduct.Id}");
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if(flag)
            {
                product.Prd_name = newProduct.Prd_name;
                product.Prd_price = newProduct.Prd_price;
                product.Vendor_id = newProduct.Vendor_id;
                _Db.Products.Update(product);
                _Db.SaveChanges();
            }
            return Ok(_Db.Products);
        }

        [HttpDelete] 
        public ActionResult DeleteProduct(int id) {
            Product product = _Db.Products.FirstOrDefault(x => x.Id == id);
            if(product == null )
            {
                return NotFound($"Could not find product with id = {id}");
            }

            _Db.Products.Remove(product);
            _Db.SaveChanges();
            return Ok(_Db.Products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product product = _Db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Could not find product with id = {id}");
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetListProductWithVendor()
        {

            //var results = _Db.Products
            //    .GroupBy(p => p.Vendor_id)
            //    .Select(selector => new
            //    {
            //        VendorId = selector.Key,
            //        ProductName = _Db.Products.Single(p => p.Vendor_id == selector.Key).Prd_name,
            //        ProductPrice = _Db.Products.Single(p => p.Vendor_id == selector.Key).Prd_price,
            //        VendorName = _Db.Vendors.Single(v => v.Id == selector.Key).Vendor_name,
            //        VendorPhone = _Db.Vendors.Single(v => v.Id == selector.Key).Vendor_phone,
            //        VendorEmail = _Db.Vendors.Single(v => v.Id == selector.Key).Vendor_email,
            //        VendorAddress = _Db.Vendors.Single(v => v.Id == selector.Key).Vendor_address,
            //    });
            var results = from p in _Db.Products
                          join v in _Db.Vendors on p.Vendor_id equals v.Id
                          select new
                          {
                              ProductId= p.Id,
                              ProductName = p.Prd_name,
                              ProductAvatar = p.Avatar,
                              ProductPrice = p.Prd_price,
                              VendorName = v.Vendor_name,
                              VendorPhone = v.Vendor_phone,
                              VendorEmail = v.Vendor_email,
                              VendorAddress = v.Vendor_address,
                          };
            return Ok(results);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff")+ Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
