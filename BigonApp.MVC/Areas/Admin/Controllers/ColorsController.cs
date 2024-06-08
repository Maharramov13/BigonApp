using BigonApp.Business.Modules.ColorsModules.Commands.ColorsAddCommand.ColorsEditCommand;
using BigonApp.Business.Modules.ColorsModules.Commands.ColorsRemoveCommand;
using BigonApp.Business.Modules.ColorsModules.Queries.ColorsGet;
using BigonApp.Business.Modules.ColorsModules.Queries.ColorsGetAll;
using BigonApp.Data.Contexts;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace BigonApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly AppDbContext _db;

        private readonly IMediator _mediator;

        public ColorsController(AppDbContext context, IMediator mediator)
        {
            _db = context;
            _mediator = mediator;
        }



        [HttpGet]
        public async Task <IActionResult>Index(ColorsGetAllRequest request)
        {
            var response=await _mediator.Send(request);
           return View(response);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorsAddRequest request)
        {
           
            await _mediator.Send(request);
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






        public async Task< IActionResult> Edit(ColorsGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task < IActionResult> Edit(ColorsEditRequest request)
        {
            await _mediator.Send(request);
           
            return RedirectToAction(nameof(Index));
        }

        public async Task< IActionResult> Details(ColorsGetByIdRequest request)
        {
            var response=await _mediator.Send(request);



            return View(response);
        }

        //public IActionResult Reflesh()
        //{
        //    return PartialView("_Body.cshtml");
        //}


        public async Task<IActionResult> Delete(ColorsRemoveRequest request)
        {
            var response=await _mediator.Send(request);
            return PartialView("_Body",response);
            
        }
    }
}
