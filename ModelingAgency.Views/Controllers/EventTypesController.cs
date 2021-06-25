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
    public class EventTypesController : Controller
    {
        private readonly ITypeEventData _repos;

        public EventTypesController(ITypeEventData repos)
        {
            _repos = repos;
        }
    
        public IActionResult Index()
        {
            var eventType = _repos.GetAll();
            return View(eventType);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = _repos.Get(id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _repos.Create(eventType);
                _repos.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(eventType);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = _repos.Get(id);
            if (eventType == null)
            {
                return NotFound();
            }
            return View(eventType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description")] EventType eventType)
        {
            if (id != eventType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repos.Edit(eventType);
                    _repos.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTypeExists(eventType.Id))
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
            return View(eventType);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = _repos.Get(id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var eventType = _repos.Get(id);
            _repos.Delete(id);
            _repos.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        private bool EventTypeExists(int id)
        {
            var eventType = _repos.Get(id);
            if (eventType != null)
                return true;

            return false;
        }
    }
}
