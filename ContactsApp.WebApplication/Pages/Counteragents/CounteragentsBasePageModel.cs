using ContactsApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactsApp.WebApplication.Pages.Counteragents
{
    public class CounteragentsBasePageModel : PageModel
    {
        private readonly CounteragentsService counteragentsService;
        protected CounteragentsService CounteragentsService => counteragentsService;

        public CounteragentsBasePageModel(CounteragentsService counteragentsService)
        {
            this.counteragentsService = counteragentsService;
        }

    }
}
