using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data;
using ModelingAgency.Data.Service.Infrastructure.Sql;

namespace ModelingAgency.Views.Views.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly ModelingAgency.Data.Service.Infrastructure.Sql.ModelingAgencyContext _context;

        public DeleteModel(ModelingAgency.Data.Service.Infrastructure.Sql.ModelingAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Clients.FindAsync(id);

            if (Client != null)
            {
                _context.Clients.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
