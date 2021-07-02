using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelingAgency.Data;
using ModelingAgency.Data.Service;

namespace ModelingAgency.Web.Pages.Model
{
    public class RegisterModel : PageModel
    {
        private readonly IModelData modelData;
        private readonly IPersonData personData;

        public bool Check { get; set; }
        [BindProperty]
        public string Name { get; set; }
        public bool NameAvailable => personData.NameFree(Name);
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public int AddressNumber { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public Int16 Age { get; set; }
        [BindProperty]
        public int TelephoneNumber { get; set; }
        [BindProperty]
        public string EMailAdress { get; set; }
        [BindProperty]
        public string Description { get; set; }

        public RegisterModel(IModelData modelData, IPersonData personData)
        {
            this.modelData = modelData;
            this.personData = personData;
        }

        public IActionResult OnGet()
        {
            Check = false;
            return Page();
        }

        public IActionResult OnPost()
        {
            Check = true;
            if (!Valid())
            {
                return Page();
            }
            Data.Model model = new() { Name = Name, Password = Password, AddressNumber = AddressNumber, PostalCode = PostalCode, City = City, Age = Age, TelephoneNumber = TelephoneNumber, EMailAdress = EMailAdress, Description = Description, Aproved = false, Role = Role.Model };
            modelData.Create(model);
            return RedirectToPage("./Register");
        }

        public bool Valid()
        {
            return (!string.IsNullOrWhiteSpace(Name) && NameAvailable && !string.IsNullOrWhiteSpace(Password)&&!string.IsNullOrWhiteSpace(EMailAdress));
        }
    }
}
