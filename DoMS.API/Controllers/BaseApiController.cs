using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
namespace DoMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private ISender? _sender;
        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
