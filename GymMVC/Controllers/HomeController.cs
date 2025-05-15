using GymMVC.Models;
using GymMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChooseProgramService _chooseProgramService;
        public HomeController()
        {
            _chooseProgramService = new ChooseProgramService();
        }
        public IActionResult Index()
        {
            List<ChooseProgram> choosePrograms = _chooseProgramService.GetAllChooseProgram();
            return View(choosePrograms);
        }
    }
}
