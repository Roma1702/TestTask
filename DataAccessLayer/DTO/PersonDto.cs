namespace DataAccessLayer.DTO
{
    public class PersonDto : ShortPersonDto
    {
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, FullName: {FullName}, BirthDate: {BirthDate}, Gender: {Gender}, Age: {Age}";
        }
    }
}
