using Microsoft.AspNetCore.Mvc;
using SampleApi.SampleExceptions;

namespace SampleApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return "pong";
        }

        [Route("unknown-error")]
        [HttpGet]
        public void ThrowUnexpectedException()
        {
            //This will result in a 404:
            throw new UnexpectedException("Something unexpected happened.");
        }

        [Route("not-found")]
        [HttpGet]
        public void ThrowNotFoundException()
        {
            //This will result in a 500:
            throw new SomethingNotFoundException("Something was not found.");
        }
    }
}
