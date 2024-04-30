namespace ContactApp.Core.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;

        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }

        public int CounteragentId { get; set; }
        public Counteragent Counteragent { get; set; } = null!;

        public string GetShortName()
        {
            return $"{Lastname} {Name[0]}. {Patronymic[0]}.";
        }
    }
}
