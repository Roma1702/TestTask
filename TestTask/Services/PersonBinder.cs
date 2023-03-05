using DataAccessLayer.DTO;
using TestTask.Interfaces;

namespace TestTask.Services
{
    public class PersonBinder : IPersonBinder
    {
        public ShortPersonDto BindPerson(string?[] data)
        {
            if (DateTimeOffset.TryParse(data[2], out DateTimeOffset birthDate))
            {
                return new ShortPersonDto
                {
                    FullName = data[1],
                    BirthDate = birthDate,
                    Gender = data[3],
                };
            }

            throw new NotImplementedException("Error of binding data");
        }
    }
}
