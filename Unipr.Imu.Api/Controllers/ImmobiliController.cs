using Imu.Business.Abstraction;
using Imu.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Imu.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ImmobiliController(IBusiness business, ILogger<ImmobiliController> logger) : ControllerBase
{
    [HttpPost(Name = "AssociaAnagraficaImmobile")]
    public async Task<ActionResult> AssociaAnagraficaImmobile(AssociaAnagraficaImmobileDto associaAnagraficaImmobileDto)
    {
        await business.AssociaAnagraficaImmobileAsync(associaAnagraficaImmobileDto);

        return Ok();
    }

    [HttpPost(Name = "CreateCategoriaCatastale")]
    public async Task<ActionResult> CreateCategoriaCatastale(CategoriaCatastaleInsertDto categoriaCatastaleInsertDto)
    {
        await business.CreateCategoriaCatastaleAsync(categoriaCatastaleInsertDto);

        return Ok();
    }

    [HttpPost(Name = "CreateImmobile")]
    public async Task<ActionResult> CreateImmobile(ImmobileInsertDto immobileInsertDto)
    {
        await business.CreateImmobileAsync(immobileInsertDto);

        return Ok();
    }
}
