using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data;
using ModelingAgency.Data.Service;

namespace ModelingAgency.Views.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientData repos;
        private readonly IEventData eventData;

        public ClientsController(IClientData repos, IEventData eventData)
        {
            this.repos = repos;
            this.eventData = eventData;
        }

        //TODO: Zet alle authorize attributes op de juiste methods in de juiste controllers
        //      Wie mag waar toegang to hebben?
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
            ViewBag.EventsListCreate = eventData.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,AddressNumber,Postalcode,City,KVKNumber,BTWNumber,Aproved,Events")] Client client)
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

            ViewBag.EventsListEdit = eventData.GetAll();
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,AddressNumber,Postalcode,City,KVKNumber,BTWNumber,Aproved")] Client client)
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
