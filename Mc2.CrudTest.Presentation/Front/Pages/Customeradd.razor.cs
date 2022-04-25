using Mc2.CrudTest.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Pages
{
    public partial class Customeraddvm : ComponentBase
    {
        [Inject]
        public HttpClient _http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Customer _customer { get; set; }
        [Parameter]
        public int customerId { get; set; }
        protected string Title = "Add";
        protected Customer customer = new();
        protected string ErrorMessage { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            _customer = new Customer();
        }



        protected override async Task OnParametersSetAsync()
        {
            if (customerId != 0)
            {
                Title = "Edit";
                customer = await _http.GetFromJsonAsync<Customer>("/customers/" + customerId);
            }
        }
        protected async Task SaveCustomer()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            
            if (customer.Id != 0)
            {
                response = await _http.PutAsJsonAsync("customers", customer);                
            }
            else
            {
                response = await _http.PostAsJsonAsync("customers", customer);            
            }
            if (response.IsSuccessStatusCode)
                Cancel();
            
            ErrorMessage =await  response.Content.ReadAsStringAsync();

        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/customer/list");
        }
    }
}
