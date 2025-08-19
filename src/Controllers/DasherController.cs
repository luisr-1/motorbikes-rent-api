using Microsoft.AspNetCore.Mvc;
using motorbikes_rent_api.Core.Model;
using motorbikes_rent_api.Service;

namespace motorbikes_rent_api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/[controller]")]
public class DasherController : ControllerBase
{
    private readonly IDasherService _dasherService;

    public DasherController(IDasherService dasherService)
    {
        _dasherService = dasherService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Dasher> CreateDasher([FromBody] Dasher dasher)
    {
        return _dasherService.CreateDasher(dasher) != null ? Created() : BadRequest("Dados inválidos");
    }
}