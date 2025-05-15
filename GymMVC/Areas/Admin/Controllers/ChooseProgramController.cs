using GymMVC.Models;
using GymMVC.Services;
using GymMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChooseProgramController : Controller
    {
        private readonly ChooseProgramService _chooseProgramService;
        public ChooseProgramController()
        {
            _chooseProgramService = new ChooseProgramService();
        }
        public IActionResult Index()
        {
            List<ChooseProgram> choosePrograms = _chooseProgramService.GetAllChooseProgram();
            return View(choosePrograms);
        }
        [HttpGet]
        public IActionResult Info(int id) 
        {
            ChooseProgram chooseProgram = _chooseProgramService.GetChooseProgramById(id);
            
            return View(chooseProgram);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChooseProgramVM chooseProgram) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modeline baxx");
            }
            _chooseProgramService.CreateChooseProgram(chooseProgram);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id) 
        {
            ChooseProgram chooseProgram = _chooseProgramService.GetChooseProgramById(id);

            return View(chooseProgram);
        }
        [HttpPost]
        public IActionResult Update(int id,ChooseProgram chooseProgram) 
        {
            _chooseProgramService.UpdateChooseProgram(id, chooseProgram);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            _chooseProgramService.DeleteChooseProgram(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
