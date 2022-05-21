using Microsoft.AspNetCore.Mvc;

namespace CancelaAntesDeConsumir.Controllers;

[ApiController]
public class CepController : ControllerBase
{
    private readonly ILogger<CepController> _logger;

    public CepController(ILogger<CepController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetEndereco/{cep}")]
    public async Task<IActionResult> GetEndereco([FromServices]ICepService cepService, string cep, CancellationToken cancellationToken)
    {
        var result = await cepService.GetEnderecoAsync(cep, cancellationToken);
        return result is null ? NotFound() :  Ok(result);
    }
}