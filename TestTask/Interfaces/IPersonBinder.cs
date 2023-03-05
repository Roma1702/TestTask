using DataAccessLayer.DTO;

namespace TestTask.Interfaces
{
    public interface IPersonBinder
    {
        ShortPersonDto BindPerson(string?[] data);
    }
}
