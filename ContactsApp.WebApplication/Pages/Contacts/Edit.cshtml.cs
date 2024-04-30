using ContactApp.Core.Entities;
using ContactsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactsApp.WebApplication.Pages.Contacts
{
    public class EditModel : ContactsBasePageModel
    {
        private readonly CounteragentsService counteragentsService;

        public EditModel(ContactsService contactsService, CounteragentsService counteragentsService) : base(contactsService)
        {
            this.counteragentsService = counteragentsService;
        }

        public Contact? FoundContact { get; private set; }
        public Counteragent[]? Counteragents { get; private set; }

        public string? ErrorMessage { get; private set; }
        public string? SuccessMessage { get; private set; }

        public async Task OnGet(int id)
        {
            var counteragentsResponse = await counteragentsService.ListCounteragents();

            if (counteragentsResponse.Success)
            {
                Counteragents = counteragentsResponse.Value;
            }
            else
            {
                ErrorMessage = counteragentsResponse.Message;
            }


            var contactResponse = await ContactsService.FindContact(id);

            if (contactResponse.Success)
            {
                FoundContact = contactResponse.Value;
                return;
            }

            ErrorMessage = contactResponse.Message;
        }

        public async Task OnPost(int id, int counteragentId, Contact contact)
        {
            var response = await ContactsService.UpdateContact(id, counteragentId, contact);

            if (response.Success)
            {
                SuccessMessage = response.Message;
            }
            else
            {
                ErrorMessage = response.Message;
            }

            await OnGet(id);
        }
    }
}
