using ContactsApp.Infrastructure.Helpers;
using ContactsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactsApp.WebApplication.Pages.Counteragents
{
    public class DeleteModel : CounteragentsBasePageModel
    {
        public DeleteModel(CounteragentsService counteragentsService) : base(counteragentsService) { }

        public string? ErrorMessage { get; private set; }
        public string? SuccessMessage { get; private set; }


        public async Task OnGet(int id)
        {
            var result = await CounteragentsService.RemoveCounteragent(id);

            if (result.Success)
            {
                SuccessMessage = result.Message;
                return;
            }

            ErrorMessage = result.Message;
        }
    }
}
