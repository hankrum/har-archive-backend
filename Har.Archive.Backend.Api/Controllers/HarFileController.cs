using Har.Archive.Backend.Data.Services.DtoModels;
using Har.Archive.Backend.Data.Services.Services;
using Har.Archive.Backend.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Api.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
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
        public async Task<ActionResult<IEnumerable<HarFile>>> Get(string path)
        {
            // TODO: pagination and sorting
            var result = await this.harFileService.AllByPath(path);

            if (result == null)
            {
                return NoContent();
            }

            // TODO: fix result code in middleware
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(HarFile harFile)
        {
            await this.harFileService.Create(harFile);

            return Ok();
        }

        [EnableCors("CorsPolicy")]
        [HttpPost ("harfiles")]
        public async Task<ActionResult> AddHarFiles([FromBody]IEnumerable<HarFile> harFiles)
        {
            await this.harFileService.AddHarFiles(harFiles);

            return Ok();
        }
    }
}
