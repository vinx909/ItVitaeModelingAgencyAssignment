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
    public class EventsController : Controller
    {
        private readonly IEventData repos;
        private readonly IModelData modelData;

        public EventsController(IEventData repos, IModelData modelData)
        {
            this.repos = repos;
            this.modelData = modelData;
        }

        public IActionResult Index()
        {
            var model = repos.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = repos.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public IActionResult Create()
        {
            ViewBag.ModelsListCreate = modelData.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,AddressNumber,Postalcode,StartTime,Duration,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                repos.Create(@event);
                repos.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = repos.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            ViewBag.ModelsListEdit = modelData.GetAll();
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,AddressNumber,Postalcode,StartTime,Duration,Description")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repos.Edit(@event);
                    repos.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = repos.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            ViewBag.ModelsListDelete = modelData.GetAll();
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var @event = repos.Get(id);
            repos.Delete(id);
            repos.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            var @event = repos.Get(id);
            if (@event != null)
                return true;

            return false;
        }
    }
}
