using BigonApp.Data.Contexts;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IColorRepository _repository;

        public ColorsController(AppDbContext context, IColorRepository repository)
        {
            _db = context;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var colors = _repository.GetWhere(x => x.DeletedAt == null);
            return View(colors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            color.CreatedAt = DateTime.Now;
            _db.Colors.Add(color);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var color = _db.Colors.FirstOrDefault(x => x.Id == id);
            if (color == null)
                return BadRequest();
            _db.Colors.Remove(color);
            await _db.SaveChangesAsync();


            var colors = _db.Colors.Where(x => x.DeletedAt == null);

            return PartialView("_Body", colors);
        }






        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var color = _db.Colors.FirstOrDefault(x => x.Id == id);
            return View(color);
        }
        [HttpPost]
        public IActionResult Edit(Color color)
        {
            if (color == null) return NotFound();

            var editedColor = _db.Colors.Find(color.Id);
            if (editedColor != null)
            {
                editedColor.Name = color.Name;
                editedColor.HaxCode = color.HaxCode;
                color.UpdatedAt = DateTime.Now;
                color.UpdatedBy = color.Id;
                _db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var getColor = _db.Colors.Find(id);



            return View(getColor);
        }

        //public IActionResult Reflesh()
        //{
        //    return PartialView("_Body.cshtml");
        //}


        //public IActionResult Delete(int id)
        //{
        //    var data = _db.Colors.Find(id);
        //    if (data == null)
        //    {
        //        return Json(new
        //        {
        //            error = true,
        //            message = "Data not found"
        //        });
        //    }

        //    _db.Colors.Remove(data);
        //    _db.SaveChanges();

        //    return Ok(new
        //    {
        //        error = false,
        //        message = "Data deleted"
        //    });

        //}
    }
}
