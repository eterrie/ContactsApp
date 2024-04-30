namespace ContactApp.Core.Exceptions
{
    public class NotFoundException : ContactsAppException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
