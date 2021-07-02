using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelingAgency.Data.Service;

namespace ModelingAgency.Web.Pages.Model
{
    public class EditModel : PageModel
    {
        private readonly IPersonData personData;

        private readonly IModelData modelData;

        public EditModel(IPersonData personData, IModelData modelData)
        {
            this.personData = personData;
            this.modelData = modelData;
        }

        [BindProperty]
        public int Id {get; set;}
        [BindProperty]
        public string Name { get; set; }
        public bool NameAvailable => !personData.Get(Id).Name.Equals(Name) || personData.NameFree(Name);
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

        public void OnGet(int modelId)
        {
            Data.Model model = modelData.Get(modelId);
            Id = modelId;
            Name = model.Name;
            Password = model.Password;
            AddressNumber = model.AddressNumber;
            PostalCode = model.PostalCode;
            City = model.City;
            Age = model.Age;
            TelephoneNumber = model.TelephoneNumber;
            EMailAdress = model.EMailAdress;
            Description = model.Description;
        }
        public IActionResult OnPost()
        {
            Data.Model origionalModel = modelData.Get(Id);
            Data.Model editedModel = new()
            {
                Name = Name,
                Password = Password,
                AddressNumber = AddressNumber,
                Age = Age,
                Aproved = false,
                City = City,
                Description = Description,
                EditOf = origionalModel,
                EMailAdress = EMailAdress,
                PostalCode = PostalCode,
                Role = origionalModel.Role,
                TelephoneNumber = TelephoneNumber
            };
            //editedModel.EditOf = origionalModel;
            modelData.Create(editedModel);
            return RedirectToPage("./Index");
        }
    }
}
