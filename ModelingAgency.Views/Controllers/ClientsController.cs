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
    public class ClientsController : Controller
    {
        private readonly IClientData repos;

        public ClientsController(IClientData repos)
        {
            this.repos = repos;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,AddressNumber,Postalcode,City,KVKNumber,BTWNumber,Aproved")] Client client)
        {
            if (ModelState.IsValid)
            {
                repos.Create(client);
                repos.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
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
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,AddressNumber,Postalcode,City,KVKNumber,BTWNumber,Aproved")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repos.Edit(client);
                    repos.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
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

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = repos.Get(id);
            repos.Delete(id);
            repos.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            var client = repos.Get(id);
            if (client != null)
                return true;

            return false;
        }
    }
}
