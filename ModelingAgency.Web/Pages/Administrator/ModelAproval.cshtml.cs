using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelingAgency.Data;
using ModelingAgency.Data.Service;

namespace ModelingAgency.Web.Pages.Administrator
{
    public class ModelAprovalModel : PageModel
    {
        private IModelData modelData;

        public ModelModel Model { get; private set; }
        public ModelModel ModelUpdate { get; private set; }
        public bool AlreadyAproved { get; private set; }

        public ModelAprovalModel(IModelData modelData)
        {
            this.modelData = modelData;
        }

        public void OnGet(int Id)
        {
            Data.Model modelFromDatabase = modelData.Get(Id);
            if(modelFromDatabase.Aproved == true)
            {
                AlreadyAproved = true;
            }
            else
            {
                if (modelFromDatabase.EditOf == null)
                {
                    Model = new(modelFromDatabase);
                    ModelUpdate = null;
                }
                else
                {
                    Model = new(modelFromDatabase.EditOf);
                    ModelUpdate = new(modelFromDatabase);
                }
            }
        }

        public class ModelModel
        {
            public ModelModel(Data.Model model)
            {
                Id = model.Id;
                Name = model.Name;
                Password = model.Password;
                Role = model.Role;
                AddressNumber = model.AddressNumber;
                PostalCode = model.PostalCode;
                City = model.City;
                Age = model.Age;
                TelephoneNumber = model.TelephoneNumber;
                EMailAdress = model.EMailAdress;
                Description = model.Description;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
            public int AddressNumber { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public Int16 Age { get; set; }
            public int TelephoneNumber { get; set; }
            public string EMailAdress { get; set; }
            public string Description { get; set; }
        }
    }
}
