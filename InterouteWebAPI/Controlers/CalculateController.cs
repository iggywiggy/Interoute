using System.Web.Http;

namespace InterouteWebAPI.Controlers
{
    [RoutePrefix("api/calculate")]
    public class CalculateController : ApiController
    {
        [HttpPost]
        [Route("addTwoIntegers")]
        public IHttpActionResult AddTwoIntegers(string integerOne, string integerTwo)
        {
            return Ok();
        }
    }
}