namespace DataAccessLayer.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string? Gender { get; set; }
    }
}
