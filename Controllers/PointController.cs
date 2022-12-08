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
    public IActionResult HomePage()
    {
        return View();
    }
        
    [HttpGet]
    public async Task<JsonResult> GetPoints()
    {
        return Json(await _repository.GetPoints());
    }

    [HttpPost]
    public async Task<JsonResult> DeletePoint(int id)
    {
        if (await _repository.DeletedPoint(id))
        {
            return Json(true);
        }
        return Json(false);
    }

}