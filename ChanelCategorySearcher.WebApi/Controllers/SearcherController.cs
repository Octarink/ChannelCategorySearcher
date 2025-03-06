using System.Text;
using ChanelCategorySearcher.BusinessLogic;
using ChanelCategorySearcher.DAI;
using Microsoft.AspNetCore.Mvc;

namespace ChanelCategorySearcher.Controllers;

[ApiController]
[Route("api/v1")]
public class SearcherController : ControllerBase
{
    private readonly IChanelService _chanelService;
    
    public SearcherController(IChanelService chanelService)
    {
        _chanelService = chanelService;
    }
    
    [HttpGet("channels")]
    public IResult GetAllChannel()
    {
        var response = _chanelService.GetAll();
        return Results.Json(response);
    }
    
    [HttpGet("categories")]
    public IResult GetAllCategory()
    {
        var response = _chanelService.GetAllCategory();
        return Results.Json(response);
    }

    [HttpGet("category/{category}")]
    public IResult GetByCategory(string category)
    {
        var response = _chanelService.GetByCategory(category);
        return Results.Json(response);
    }

    [HttpPost("create")]
    public async Task<Chanel> CreateChannel(Chanel chanelInput)
    {
        var chanel = await _chanelService.CreateChanel(chanelInput.Name,chanelInput.Category,chanelInput.Link);
        return chanel;
    }
}