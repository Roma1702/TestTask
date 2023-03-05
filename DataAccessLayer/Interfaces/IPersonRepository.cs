using DataAccessLayer.DTO;

namespace DataAccessLayer.Interfaces
{
    public interface IPersonRepository
    {
        Task CreateTable();
        Task CreateAsync(ShortPersonDto personDto);
        Task<IEnumerable<PersonDto>> GetUniqueFields();
    }
}
