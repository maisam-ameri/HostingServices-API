
using Entities.LinkModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private LinkGenerator _linkGenerator;

        public RootController(LinkGenerator linkGenerator) =>
            _linkGenerator = linkGenerator;

        [HttpGet]
        public IActionResult GetRoot([FromHeader] string mediaType)
        {
            if (mediaType.Contains("application/vnd.mesism.apiroot"))
            {
                var list = new List<Link>
                {
                    new Link
                    {
                        Href = _linkGenerator.GetPathByName(HttpContext,nameof(GetRoot),new{ }),
                        Rel = "self",
                        Method = "GET",
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetPathByName(HttpContext,"GetHosts",new{ }),
                        Rel = "hosts",
                        Method = "GET",
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetPathByName(HttpContext,"CreateHost",new{ }),
                        Rel = "create-host",
                        Method = "POST",
                    }
                };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
