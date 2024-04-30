using ContactApp.Core.Entities;
using ContactsApp.Infrastructure.Helpers;
using ContactsApp.Infrastructure.Services;
using ContactsApp.WebApplication.Pages.Counteragents;

namespace ContactsApp.Pages.Counteragents
{
    public class IndexPageModel : CounteragentsBasePageModel
    {
        public IndexPageModel(CounteragentsService counteragentsService) : base(counteragentsService) { }

        private Response<Counteragent[]>? response;

        public Counteragent[]? Counteragents { get; private set; }

        public string? ErrorMessage { get; private set; }

        public async Task OnGet()
        {
            response = await CounteragentsService.ListCounteragents();

            if (response.Success)
            {
                Counteragents = response.Value;
                return;
            }

            ErrorMessage = response.Message;
        }
    }
}
