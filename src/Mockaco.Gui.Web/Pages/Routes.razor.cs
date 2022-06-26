using Mockaco.Gui.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mockaco.Gui.Web.Pages
{
    public partial class Routes
    {
        private IEnumerable<RoutesListItemModel> _routes;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _routes = new List<RoutesListItemModel>
            {
                new RoutesListItemModel
                {
                    Method = "GET",
                    Route = "pets"
                },
                new RoutesListItemModel
                {
                    Method = "GET",
                    Route = "pets/{id}"
                },
                new RoutesListItemModel
                {
                    Method = "POST",
                    Route = "pets"
                },
                new RoutesListItemModel
                {
                    Method = "PUT",
                    Route = "pets/{id}"
                },
                new RoutesListItemModel
                {
                    Method = "DELETE",
                    Route = "pets/{id}"
                }
            };
        }
    }
}
