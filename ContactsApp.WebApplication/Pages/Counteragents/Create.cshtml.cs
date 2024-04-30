using ContactApp.Core.Entities;
using ContactsApp.Infrastructure.Helpers;
using ContactsApp.Infrastructure.Services;

namespace ContactsApp.WebApplication.Pages.Counteragents
{
    public class CreateModel : CounteragentsBasePageModel
    {
        public CreateModel(CounteragentsService counteragentsService) : base(counteragentsService) { }

        private Response? response;
        
        public string? SuccessMessage { get; private set; }
        public string? ErrorMessage { get; private set; }

        public async Task OnPost(string counteragentName)
        {
            var counteragent = new Counteragent()
            {
                Name = counteragentName
            };

            response = await CounteragentsService.CreateCounteragent(counteragent);

            if(response.Success)
            {
                SuccessMessage = response.Message;
            }
            else
            {
                ErrorMessage = response.Message;
            }
        }
    }
}
