using eStore.BackendLibrary.Bs.ContentManagement;
using eStore.BackendLibrary.TypeLibrary.ContentManagement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            ProductBs productBs = new ProductBs();
            var posts = productBs.QueryAll();
            return posts;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(Guid productKey)
        {
            ProductBs productBs = new ProductBs();
            Product product = productBs.QueryByProductKey(productKey);
            return product;

        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            ProductBs productBs = new ProductBs();
            productBs.Insert(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            ProductBs productBs = new ProductBs();
            productBs.Update(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            ProductBs productBs = new ProductBs();
            productBs.Delete(id);
        }
    }
}
