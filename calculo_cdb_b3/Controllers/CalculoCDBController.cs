using calculo_cdb.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace calculo_cdb_b3.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculoCDBController : ControllerBase
{
    private readonly ICalcularRetornoCDB _calcularRetornoCDB;

    public CalculoCDBController(ICalcularRetornoCDB calcularRetornoCDB)
    {
        _calcularRetornoCDB = calcularRetornoCDB ?? throw new ArgumentNullException(nameof(_calcularRetornoCDB));
    }


    public async Task<ActionResult>
}