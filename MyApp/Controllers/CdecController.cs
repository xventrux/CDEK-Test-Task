using Microsoft.AspNetCore.Mvc;
using MyApp.AppServices.Services.SdecServices;
using MyApp.Contracts.DTOs;
using Sdek.SDK.DTOs;
using Sdek.SDK.Models;

namespace MyApp.Controllers;


/// <summary>
/// ���������� ��� ������ �� "����"
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CdecController : ControllerBase
{
    private readonly ICdecService _cdecService;
    private readonly ILogger<CdecController> _logger;

    public CdecController(ILogger<CdecController> logger, ICdecService cdecService)
    {
        _logger = logger;
        _cdecService = cdecService;
    }

    /// <summary>
    /// ������ ��������� ��������
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("CalculateDelivery")]
    public async Task<IActionResult> CalculateDelivery(CalculateDeliveryRequest request)
    {
        try
        {
            var result = await _cdecService.CalculateDeliveryAsync(request);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}
