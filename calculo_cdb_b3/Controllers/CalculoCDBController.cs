using calculo_cdb.Application.Interfaces;
using calculo_cdb.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace calculo_cdb_b3.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class CalculoCDBController : ControllerBase
{
    private readonly ICalcularRetornoCDB _calcularRetornoCDB;

    public CalculoCDBController(ICalcularRetornoCDB calcularRetornoCDB)
    {
        _calcularRetornoCDB = calcularRetornoCDB ?? throw new ArgumentNullException(nameof(_calcularRetornoCDB));
    }

    [HttpPost]
    public async Task<ActionResult<InvestmentResult>> CalculateInvestment([FromBody] InvestmentData data)
    {
        if (data == null)
        {
            return BadRequest(HttpStatusCode.BadRequest);
        }

        try
        {
            var resultado = await _calcularRetornoCDB.CalculaRetornoCDB(data);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}