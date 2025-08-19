using Microsoft.AspNetCore.Mvc;
using motorbikes_rent_api.Core.DTOs;
using motorbikes_rent_api.Core.Model;
using motorbikes_rent_api.Service;

namespace motorbikes_rent_api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/entregadores")]
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
    public async Task<ActionResult<Dasher>> CreateDasher([FromBody] Dasher dasher)
    {
        if (!ModelState.IsValid) return BadRequest("Dados inválidos");

        try
        {
            var createdDasher = await _dasherService.CreateDasher(dasher);
            return CreatedAtAction(nameof(GetById), new { id = createdDasher.Id }, null);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Dasher> GetById(string id)
    {
        try
        {
            var dasher = _dasherService.GetDasherById(id);
            return Ok(dasher);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("{id}/cnh")]
    public async Task<ActionResult<Dasher>> AddCnh([FromRoute] string id, [FromBody] CnhImageDto cnh)
    {
        var dasher = await _dasherService.AddCnhImageAsync(id, cnh);
        if (dasher == null)
            return NotFound();

        return Ok(dasher);
    }
}