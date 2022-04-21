using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAuthApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProtectedController : ControllerBase
    {

        [HttpGet("Data")]

        public string GetProdtectedData()
        {
            return "This string is protected by JWT Bearer token.";
        }
        
    }
}