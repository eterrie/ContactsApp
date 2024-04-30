using ContactApp.Core.Entities;
using ContactsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactsApp.WebApplication.Pages.Contacts
{
    public class CreateModel : ContactsBasePageModel
    {
        private readonly CounteragentsService counteragentsService;

        public CreateModel(ContactsService contactsService, CounteragentsService counteragentsService) : base(contactsService)
        {
            this.counteragentsService = counteragentsService;
        }

        public Counteragent[]? Counteragents { get; private set; }

        public string? ErrorMessage { get; private set; }
        public string? SuccessMessage { get; private set; }

        public async Task OnGet()
        {
            var response = await counteragentsService.ListCounteragents();

            if (response.Success)
            {
                Counteragents = response.Value;
                return;
            }

            ErrorMessage = response.Message;
        }

        public async Task OnPost(Contact contact, int counteragentId)
        {
            var response = await ContactsService.CreateContact(contact, counteragentId);

            if(response.Success)
            {
                SuccessMessage = response.Message;
                return;
            }

            ErrorMessage = response.Message;
            await OnGet();
        }
    }
}
