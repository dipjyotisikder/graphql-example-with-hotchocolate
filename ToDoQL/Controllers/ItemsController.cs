using Microsoft.AspNetCore.Mvc;

namespace ToDoQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Running");
        }
    }
}
