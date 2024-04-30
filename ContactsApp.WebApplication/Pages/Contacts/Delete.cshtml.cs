using ContactsApp.Infrastructure.Services;

namespace ContactsApp.WebApplication.Pages.Contacts
{
    public class DeleteModel : ContactsBasePageModel
    {
        public DeleteModel(ContactsService contactsService) : base(contactsService) { }

        public string? ErrorMessage { get; private set; }
        public string? SuccessMessage { get; private set; }

        public async Task OnGet(int id)
        {
            var result = await ContactsService.RemoveContact(id);

            if (result.Success)
            {
                SuccessMessage = result.Message;
                return;
            }

            ErrorMessage = result.Message;
        }
    }
}
