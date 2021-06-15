using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ModelingAgency.Data;
using ModelingAgency.Data.Service;
using ModelingAgency.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelingAgency.Views.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientData clientData;
        private readonly LinkGenerator link;

        public ClientController(ClientData clientData, LinkGenerator link)
        {
            this.clientData = clientData;
            this.link = link;
        }

        // TODO: Automapper gebruiken voor ClientViewModel
        public ActionResult Index()
        {
            var model = clientData.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = clientData.Get(id);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            // "Client" kan zo geschreven worden, maar "ClientController" ook ?
            var location = link.GetPathByAction("Details", "Client", new { Id = client.Id });
            // TODO: maak de view die de badrequest opvangt
            if (string.IsNullOrWhiteSpace(location)) return BadRequest($"Couldn't create client: {client.Name}");

            // TODO: Map Client naar client viewmodel
            clientData.Create(client);
            if (clientData.SaveChanges())
            {
                return Created($"Client/Details/{client.Id}", client);
            }

            return BadRequest($"Couldn't create client: {client.Name}");
        }

        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            var oldClient = clientData.Get(client.Id);
            // TODO: maak de view die de notfound opvangt
            if (oldClient == null) return NotFound($"Couldn't find client: {client.Name}");

            if(clientData.SaveChanges())
            {
                return RedirectToPage("Details", client.Id);
            }

            return BadRequest($"Couldn't save client: {client.Name} in database");
        }

        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var oldClient = clientData.Get(id);
            if (oldClient == null) return NotFound($"Couldn't find client");

            if (clientData.SaveChanges())
            {
                return RedirectToPage("Details", id);
            }

            return BadRequest($"Couldn't delete client from database");
        }
    }
}
