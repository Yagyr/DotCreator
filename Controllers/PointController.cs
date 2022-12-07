using LamartTest.Context;
using LamartTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace LamartTest.Controllers;

public class PointController : Controller
{
    private readonly IRepository _repository;

    public PointController(IRepository repository)
    {
        _repository = repository;
    }
        
    [HttpGet]
    public async Task<JsonResult> GetPoints()
    {
        return Json(await _repository.GetPoints());
    }
    public IActionResult HomePage()
    {
        return View();
    }

    // [HttpPost]
    // public IActionResult RemovePoint()
    // {
    //     //TODO Delete points
    // }

}