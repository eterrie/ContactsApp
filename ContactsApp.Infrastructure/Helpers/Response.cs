namespace ContactsApp.Infrastructure.Helpers
{
    public class Response
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public string[]? InternalErrorMessages { get; init; }
    }

    public class Response<T> : Response
    {
        public T? Value { get; init; }
    }
}
