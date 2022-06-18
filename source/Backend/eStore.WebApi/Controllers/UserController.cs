using eStore.BackendLibrary.Bs.Common;
using eStore.BackendLibrary.TypeLibrary.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            UsersBs usersBs = new UsersBs();
            var users = usersBs.QueryAll();
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Users Get(Guid userKey)
        {
            UsersBs usersBs = new UsersBs();
            var users = usersBs.QueryByUsersKey(userKey);
            return users;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] Users user)
        {
            UsersBs usersBs = new UsersBs();
            usersBs.Insert(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users user)
        {
            UsersBs usersBs = new UsersBs();
            usersBs.Update(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid userKey)
        {
            UsersBs usersBs = new UsersBs();
            usersBs.Delete(userKey);
        }
    }
}
