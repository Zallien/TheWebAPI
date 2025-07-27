using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthbayWebAPI.ItemModels;
using NorthbayWebAPI.Models;

namespace NorthbayWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private NorthbayCompanyPosinventoryContext _db;

        public ProductController(NorthbayCompanyPosinventoryContext db)
        {
            _db = db;
        }

        [HttpGet("GetProducts")]
        public async Task<List<ProductList>> Getproduct()
        {
            List<ProductList> products = new List<ProductList>();
            products = await _db.ProductLists.ToListAsync();

            return products;


        }

        [HttpPost("AddProduct")]
        public async Task<bool> Addproduct([FromBody] iProducts products)
        {
            bool IsProductAdded = false;
            ProductList pd = new();
            pd.ProductName = products.Productname;
            pd.ProductPrice = products.Productprice;
            pd.IsActive = true;
            pd.ProductId = Guid.NewGuid();
            pd.ProductQuanity = 10;
            pd.Datecreated = DateTime.Now;

            try
            {
                await _db.AddAsync(pd);
                await _db.SaveChangesAsync();
                IsProductAdded = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return IsProductAdded;

        }

        [HttpPost("DeleteProduct")]
        public async Task<bool> DeleteProduct([FromBody] ProductID productID)
        {
            bool Isproductdeleted = false;

            try
            {

                var product = await _db.ProductLists.FirstOrDefaultAsync(p => p.ProductId == productID.Productid);

                if(product != null)
                {
                    _db.ProductLists.Remove(product);
                    await _db.SaveChangesAsync();
                    Isproductdeleted = true;
                }


            }
            catch (Exception e)
            {


            }


            

            return Isproductdeleted;

        }

        [HttpPost("UpdateProduct")]
        public async Task<bool> UpdateProduct([FromBody] UpdateItem updateItem)
        {
            bool IsUpdated = false;

            try
            {

                var product = await _db.ProductLists.FirstOrDefaultAsync(p => p.ProductId == updateItem.ProductId);

                if (product != null)
                {
                    product.ProductName = updateItem.ProductName;
                    product.ProductPrice = updateItem.ProductPrice;

                    await _db.SaveChangesAsync();
                    IsUpdated = true;

                }


            }
            catch (Exception e)
            {


            }




            return IsUpdated;

        }


    }
}
