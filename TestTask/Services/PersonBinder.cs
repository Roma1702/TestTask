using DataAccessLayer.DTO;
using TestTask.Interfaces;
using static Bogus.DataSets.Name;

namespace TestTask.Services
{
    public class PersonBinder : IPersonBinder
    {
        public ShortPersonDto BindPerson(string?[] data)
        {
            if (DateTimeOffset.TryParse(data[2], out DateTimeOffset birthDate)
                && Enum.TryParse(data[3], true, out Gender gender))
            {
                return new ShortPersonDto
                {
                    FullName = data[1],
                    BirthDate = birthDate,
                    Gender = gender,
                };
            }

            throw new NotImplementedException("Error of binding data");
        }
    }
}
