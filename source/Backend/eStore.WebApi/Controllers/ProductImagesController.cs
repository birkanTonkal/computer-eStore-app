using eStore.BackendLibrary.Bs.ContentManagement;
using eStore.BackendLibrary.TypeLibrary.ContentManagement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        // GET: api/<ProductImages>
        [HttpGet]
        public IEnumerable<ProductImages> Get()
        {
            ProductImagesBs productBs = new ProductImagesBs();
            var posts = productBs.QueryAll();
            return posts;
        }

        // GET api/<ProductImages>/5
        [HttpGet("{id}")]
        public ProductImages Get(Guid id)
        {
            ProductImagesBs productBs = new ProductImagesBs();
            var posts = productBs.QueryByProductImageKey(id);
            return posts;
        }

        // POST api/<ProductImages>
        [HttpPost]
        public void Post([FromBody] ProductImages productImage)
        {
            ProductImagesBs productBs = new ProductImagesBs();
            productBs.Insert(productImage);
        }

        // PUT api/<ProductImages>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductImages productImage)
        {
            ProductImagesBs productBs = new ProductImagesBs();
            productBs.Update(productImage);
        }

        // DELETE api/<ProductImages>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            ProductImagesBs productBs = new ProductImagesBs();
            productBs.Delete(id);
        }
    }
}
