using ContactApp.Core.Entities;
using ContactsApp.Infrastructure.Services;

namespace ContactsApp.WebApplication.Pages.Counteragents
{
    public class EditModel : CounteragentsBasePageModel
    {
        public EditModel(CounteragentsService counteragentsService) : base(counteragentsService) { }

        public Counteragent? FoundCounteragent { get; set; }

        public string? SuccessMessage { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task OnGet(int id)
        {
            var result = await CounteragentsService.FindCounteragent(id);

            if(result.Success)
            {
                FoundCounteragent = result.Value;
                return;
            }

            ErrorMessage = result.Message;
        }

        public async Task OnPost(int id, string counteragentName)
        {
            var counteragent = new Counteragent()
            {
                Name = counteragentName
            };

            var result = await CounteragentsService.UpdateCounteragent(id, counteragent);

            if(result.Success)
            {
                SuccessMessage = result.Message;
                await OnGet(id);
            }
            else
            {
                ErrorMessage = result.Message;
            }
        }
    }
}
