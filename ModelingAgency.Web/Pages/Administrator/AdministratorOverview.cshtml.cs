using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelingAgency.Data.Service;

namespace ModelingAgency.Web.Pages.Administrator
{
    public class AdministratorOverviewModel : PageModel
    {
        private readonly IClientData clientData;
        private readonly IModelData modelData;

        private const TablesToView startTablesToView = TablesToView.none;
        private const ViewType startViewType = ViewType.nothing;

        public enum TablesToView
        {
            none,
            client,
            model
        }
        public enum ViewType
        {
            nothing,
            all,
            unaproved
        }

        [BindProperty]
        public TablesToView SelectedTableToView { get; set; }
        [BindProperty]
        public ViewType SelectedViewType { get; set; }
        public IEnumerable<ModelModel> Models {get; private set;}

        public AdministratorOverviewModel(IClientData clientData, IModelData modelData)
        {
            this.clientData = clientData;
            this.modelData = modelData;

            SelectedTableToView = startTablesToView;
            SelectedViewType = startViewType;
        }

        public void OnGet(TablesToView SelectedTableToView, ViewType SelectedViewType)
        {
            this.SelectedTableToView = SelectedTableToView;
            this.SelectedViewType = SelectedViewType;

            if (SelectedTableToView == TablesToView.model)
            {
                List<ModelModel> models = new();

                Func<Data.Model, bool> searchQuiry;
                if (SelectedViewType == ViewType.all)
                {
                    searchQuiry = (model) => { return true; };
                }
                else if (SelectedViewType == ViewType.unaproved)
                {
                    searchQuiry = (model) => { return model.Aproved == false; };
                }
                else
                {
                    searchQuiry = (model) => { return false; };
                }

                foreach (Data.Model model in modelData.GetFromSeachQuiry(searchQuiry))
                {
                    models.Add(new() { Id = model.Id, Name = model.Name, Aproved = model.Aproved });
                }

                Models = models; 
            }
        }

        public class ModelModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Aproved { get; set; }
        }
    }
}
