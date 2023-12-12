using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UoN.ExpressiveAnnotations.Net8Sample.Models;

namespace UoN.ExpressiveAnnotations.Net8Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // POST api/Default/Save
        [HttpPost]
        public async Task<ActionResult> Save(Query model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await Task.Delay(1);
            return Ok();
        }
    }
}
