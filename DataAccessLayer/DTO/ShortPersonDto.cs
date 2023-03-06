using static Bogus.DataSets.Name;

namespace DataAccessLayer.DTO
{
    public class ShortPersonDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Gender? Gender { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, FullName: {FullName}, BirthDate: {BirthDate}, Gender: {Gender}";
        }
    }
}
