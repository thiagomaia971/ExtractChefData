using CheffyExtractData.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace CheffyExtractData.ApiApplication.Controllers
{
    public class ExtractDataController : BaseController 
    {
        [HttpGet]
        public IActionResult Get([FromRoute] ExtractDataCommand sampleCommand) 
            => HandleResult(Mediator.Send(sampleCommand).GetAwaiter().GetResult());
    }
}