using ContactApp.Core.Entities;
using ContactsApp.Infrastructure.Helpers;
using ContactsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactsApp.WebApplication.Pages.Contacts
{
    public class IndexModel : ContactsBasePageModel
    {
        private readonly CounteragentsService counteragentsService;

        public IndexModel(ContactsService contactsService, CounteragentsService counteragentsService) : base(contactsService)
        {
            this.counteragentsService = counteragentsService;
        }

        [BindProperty(SupportsGet = true)]
        public int? CounteragentId { get; set; }

        public Counteragent[]? Counteragents { get; private set; }

        public Contact[]? Contacts { get; private set; }

        public string? ErrorMessage { get; private set; }

        public async Task OnGet()
        {
            var counteragentsResponse = await counteragentsService.ListCounteragents();

            if(counteragentsResponse.Success)
            {
                Counteragents = counteragentsResponse.Value;
            }
            else
            {
                ErrorMessage = counteragentsResponse.Message;
            }

            Response<Contact[]>? contactResponse;

            if(CounteragentId == null)
            {
                contactResponse = await ContactsService.ListContacts();
            }
            else
            {
                contactResponse = await ContactsService.ListContactsAtCounteragent(CounteragentId.Value);
            }

            if(contactResponse.Success)
            {
                Contacts = contactResponse.Value;
            }
            else
            {
                ErrorMessage = contactResponse.Message;
            }
        }
    }
}
