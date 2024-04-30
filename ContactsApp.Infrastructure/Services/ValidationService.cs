namespace ContactsApp.Infrastructure.Services
{
    public class ValidationService
    {
        public bool ValidateStrings(params string[] args)
        {
            foreach (var arg in args)
            {
                if (string.IsNullOrWhiteSpace(arg))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
