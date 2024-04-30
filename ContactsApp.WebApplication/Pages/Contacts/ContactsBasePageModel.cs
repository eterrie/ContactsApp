using ContactsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactsApp.WebApplication.Pages.Contacts
{
    public class ContactsBasePageModel : PageModel
    {
        private readonly ContactsService contactsService;

        protected ContactsService ContactsService => contactsService;

        public ContactsBasePageModel(ContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

    }
}
