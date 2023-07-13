using Microsoft.AspNetCore.Mvc;
using Tourism.DataAccess;
using Tourism.Models;

namespace Tourism.Controllers
{
    public class StatesController : Controller
    {
        private readonly TourismContext _context;

        public StatesController(TourismContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var states = _context.States.ToList();
            return View(states);
        }

        [Route("/states/{id:int}")]
        public IActionResult Show(int id)
        {
            var state = _context.States.Find(id);
            return View(state);
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Create(State model)
        {
            //_context.States.Add(new State { model.UserInput });
            //_context.States.Add(model.UserInput);
            return Redirect("/confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
