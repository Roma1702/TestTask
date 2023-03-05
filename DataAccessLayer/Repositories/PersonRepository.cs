using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Person> _dbSet;
        private readonly IMapper _mapper;

        public PersonRepository(ApplicationContext context,
            IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<Person>();
            _mapper = mapper;
        }

        public async Task CreateAsync(ShortPersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            await _dbSet.AddAsync(person);

            await _context.SaveChangesAsync();
        }

        public async Task CreateTable()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task<IEnumerable<PersonDto>> GetUniqueFields()
        {
            var uniquePerson = await _dbSet
                .GroupBy(p => new {p.FullName, p.BirthDate})
                .Select(g => g.First())
                .ToListAsync();

            var personDto = _mapper.Map<IEnumerable<Person>, IEnumerable <PersonDto>>(uniquePerson);

            return personDto;
        }
    }
}
