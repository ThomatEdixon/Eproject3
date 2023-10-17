
using eProject3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceMarketingSystem.Data;
using System.IO;

namespace eProject3.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class ProductController : ControllerBase
    {
        private readonly DataConnection? _Db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(DbConnection? Db, IWebHostEnvironment hostEnvironment)
        {
            _Db = Db;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> ListProduct()
        {
            if (_Db.Products == null)
            {
                return NotFound();
            }
            return _Db.Products.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromForm] Product product)
        {
            Boolean flag = true;
            Vendor vendor = _Db.Vendors.Find(product.Vendor_id);
            if (product == null)
            {
                flag = false;
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            if (Dupplicated(product.Prd_name))
            {
                flag = false;
                ModelState.AddModelError("DupplicatedProductName", "Product Name is dupplicated!");
                return Ok(ModelState);
            }
            if (vendor is null)
            {
                flag = false;
                ModelState.AddModelError("VendorNotFound", "Vendor is not found!");
                return Ok(ModelState);
            }
            if (product.Avatar != null && product.Avatar.Length > 0)
            {
                string id = Guid.NewGuid().ToString();
                string folderPath = "Images";
                string filePath = Path.Combine(folderPath, id + product.Avatar.FileName);
                product.ImagePath = filePath;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    product.Avatar.CopyTo(stream);
                }
            }
            if (flag)
            {
                _Db.Products.Add(product);
                await _Db.SaveChangesAsync();
            }
            return Ok("ok");
        }

        private Boolean Dupplicated(string name)
        {
            Boolean flag = false;
            List<Product> products = _Db.Products.Where(p => p.Prd_name.ToLower().Equals(name.ToLower())).ToList();
            if (products.Any())
            {
                flag = true;
            }
            return flag;
        }

        [HttpPut]
        public ActionResult<Product> UpdateProduct([FromForm] Product newProduct)
        {
            Boolean flag = true;
            Product product = _Db.Products.Where(c => c.Id == newProduct.Id).FirstOrDefault();
            if (product == null)
            {
                flag = false;
                return NotFound($"Could not find product with id = {newProduct.Id}");
            }
            if (!ModelState.IsValid)
            {
                flag = false;
                return Ok(ModelState);
            }
            string existingImagePath = product.ImagePath; // Update with the actual path
            IFormFile newImageFile = newProduct.Avatar /* Get the new image file from the client or elsewhere */;

            if (newImageFile != null)
            {
                // Read the new image data from the IFormFile
                using (var stream = new MemoryStream())
                {
                    newImageFile.CopyTo(stream);
                    byte[] newImageData = stream.ToArray();

                    // Check if the existing image file exists
                    if (System.IO.File.Exists(existingImagePath))
                    {
                        // Delete the existing image
                        System.IO.File.Delete(existingImagePath);

                        // Save the new image with the same name as the existing image
                        using (var fileStream = new FileStream(existingImagePath, FileMode.Create))
                        {
                            fileStream.Write(newImageData, 0, newImageData.Length);
                        }

                        // The image has been updated
                    }
                    else
                    {
                        // Handle the case where the existing image does not exist
                    }
                }
            }
            if (flag)
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
        public ActionResult DeleteProduct(int id)
        {
            Product product = _Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
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
            return Ok(new
            {
                ProductId = product.Id,
                ProductName = product.Prd_name,
                ProductAvatar = GetProductImage(product.ImagePath),
                ProductPrice = product.Prd_price,
                VendorId = product.Vendor_id
            });
        }

        [HttpGet]
        public IActionResult GetListProductWithVendor()
        {
            var results = from p in _Db.Products
                          join v in _Db.Vendors on p.Vendor_id equals v.Id
                          select new
                          {
                              ProductId = p.Id,
                              ProductName = p.Prd_name,
                              ProductAvatar = GetProductImage(p.ImagePath),
                              ProductPrice = p.Prd_price,
                              VendorName = v.Vendor_name,
                              VendorPhone = v.Vendor_phone,
                              VendorEmail = v.Vendor_email,
                              VendorAddress = v.Vendor_address,


                          };
            return Ok(results);
        }

        public static byte[] GetProductImage(string imagePath)
        {

            try
            {
                string folderPath = imagePath;

                using (var stream = new FileStream(folderPath, FileMode.Open))
                {
                    // Read the image content and convert it to a byte array
                    byte[] imageBytes = new byte[stream.Length];
                    stream.Read(imageBytes, 0, (int)stream.Length);
                    return imageBytes;
                }
            }
            catch (IOException)
            {
                // File is in use, wait for a short time and then retry
                //Thread.Sleep(1000); // Wait for 1 second before retrying
                return null;
            }

        }
    }
}
