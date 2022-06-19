using eStore.BackendLibrary.Bs.ContentManagement;
using eStore.BackendLibrary.TypeLibrary.ContentManagement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            CartBs cartBs = new CartBs();
            var cart = cartBs.QueryAll();
            return cart;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(Guid key)
        {
            CartBs cartBs = new CartBs();
            Cart cart = cartBs.QueryByUserKey(key);
            return cart;

        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] Cart cart)
        {
            CartBs cartBs = new CartBs();
            cartBs.Insert(cart);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Cart cart)
        {
            CartBs cartBs = new CartBs();
            cartBs.Update(cart);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            CartBs cartBs = new CartBs();
            cartBs.Delete(id);
        }
    }
}
