using Har.Archive.Backend.Data.Services;
using Har.Archive.Backend.Data.Services.DtoModels;
using Har.Archive.Backend.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarFileController : Controller
    {
        private readonly IHarFileService harFileService;

        public HarFileController(IHarFileService harFileService)
        {
            this.harFileService = Guard.GetNotNullArgument(harFileService, nameof(harFileService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HarFile>>> Get()
        {
            // TODO: pagination and sorting
            var result = await this.harFileService.All();

            if (result == null)
            {
                return NoContent();
            }

            // TODO: fix result code in middleware
            return Ok(result);
        }
    }
}
