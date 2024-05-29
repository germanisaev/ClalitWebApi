using GetPatientInfo.Models;
using GetPatientInfo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GetPatientInfo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController: ControllerBase
{
    private readonly IResponseService _service;
    private readonly ILogger<PatientController> _logger;
    private readonly ICorrelationIdGenerators _correlationIdGenerator;

    public PatientController(ICorrelationIdGenerators correlationIdGenerator, ILogger<PatientController> logger, IResponseService service)
    {
        _service = service;
        _logger = logger;
        _correlationIdGenerator = correlationIdGenerator;
    }

    [HttpPost("GetPatientById")]
        public async Task<IActionResult> GetPatientById(MyApiRequestParameters parameters)
        {
            if(parameters == null)
            {
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("CorrelationId {correlationId}: Processing patient request",
            _correlationIdGenerator.Get());

                var response = await _service.GetPatientById(parameters);

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "IResponseService.GetPatientById encountered an exception.");
                throw;
            }
        }
}
