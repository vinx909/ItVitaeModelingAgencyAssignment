using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data;
using ModelingAgency.Data.Service;
using ModelingAgency.Data.Service.Infrastructure.Sql;

namespace ModelingAgency.Views.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IModelData _repos;
        private readonly IEventData _eventData;

        public ModelsController(IModelData repos, IEventData eventData)
        {
            _repos = repos;
            _eventData = eventData;
        }

        public IActionResult Index()
        {
            var model = _repos.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _repos.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.EventsListCreate = _eventData.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,AddressNumber,Postalcode,City,Age,HairColor,EyeColor,Length,ClothingSize,TelephoneNumber,EMailAdress,Description,Aproved")] Model model)
        {
            if (ModelState.IsValid)
            {
                _repos.Create(model);
                _repos.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _repos.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            ViewBag.EventsListEdit = _eventData.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,AddressNumber,Postalcode,City,Age,HairColor,EyeColor,Length,ClothingSize,TelephoneNumber,EMailAdress,Description,Aproved")] Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repos.Edit(model);
                    _repos.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _repos.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = _repos.Get(id);
            _repos.Delete(id);
            _repos.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            var model = _repos.Get(id);
            if (model != null)
                return true;

            return false;
        }
    }
}
