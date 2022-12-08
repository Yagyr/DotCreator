using LamartTest.Context;
using LamartTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace LamartTest.Controllers;

public class PointController : Controller
{
    private readonly IPointRepository _pointRepository;

    public PointController(IPointRepository pointRepository)
    {
        _pointRepository = pointRepository;
    }

    public IActionResult HomePage()
    {
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetPoints()
    {
        var points = await _pointRepository.GetPoints();
        return Json(points);
    }

    [HttpPost]
    public async Task<ActionResult> DeletePoint(int id)
    {
        if (await _pointRepository.DeletePoint(id))
        {
            return Ok();
        }

        return BadRequest();
    }
    
    [HttpPost]
    public async Task<JsonResult> AddRandomPoint()
    {
        var point = await _pointRepository.AddRandomPoint();
        return Json(point);
    }
}