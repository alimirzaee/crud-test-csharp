using Mc2.CrudTest.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Pages
{
    public partial class CustomerDeleteMv : ComponentBase
    {
        public Customer  customer { get; set; } = new Customer();


        [Inject]
        public HttpClient _http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }



        [Parameter]
        public int customerId { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            customer = await _http.GetFromJsonAsync<Customer>("/customers/" + Convert.ToInt32(customerId));
        }
        protected async Task RemoveCustomer(int customerID)
        {
            await _http.DeleteAsync("/customers/" + customerId);
            NavigationManager.NavigateTo("/customer/list");
        }
       public void Cancel()
        {
            NavigationManager.NavigateTo("/customer/list");
        }
    }
}
