using Microsoft.AspNetCore.Mvc;

namespace LamartTest.Controllers;

public class PointController : Controller
{
    [HttpGet]
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