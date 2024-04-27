namespace ContactApp.Core
{
    public class Contact
    {
        public string Email { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;

        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; set; }
    }
}
