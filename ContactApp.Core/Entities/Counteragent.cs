namespace ContactApp.Core.Entities
{
    public class Counteragent
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }

        public ICollection<Contact> Contacts { get; } = new List<Contact>();
    }
}
