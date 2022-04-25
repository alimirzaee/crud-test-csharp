using Mc2.CrudTest.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Pages
{
    public partial class CustomersListVM : ComponentBase
    {
        [Inject]
        public HttpClient _http { get; set; }

        public Customer[] _customers { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _customers = await _http.GetFromJsonAsync<Customer[]>("customers");
        }

 
    }
}
