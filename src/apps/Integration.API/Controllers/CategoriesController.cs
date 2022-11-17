using Integration.Application.Catalog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllCategoriesAsync();
        return Ok(result);
    }
}