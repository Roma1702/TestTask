using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Bogus.DataSets.Name;

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

            await _context.Database.EnsureCreatedAsync();
        }

        public async Task<IEnumerable<ShortPersonDto>> FindByConditionAsync()
        {
            var people = await _dbSet.Where(x => x.Gender!.Value == Gender.Male && x.FullName!.StartsWith("F"))
                .ToListAsync();

            var personDto = _mapper.Map<IEnumerable<ShortPersonDto>>(people);

            return personDto;
        }

        public async Task GenerateHundredPeopleAsync()
        {
            var people = FakeData.GenerateHundredPeople();

            await _dbSet.AddRangeAsync(people);

            await _context.SaveChangesAsync();
        }

        public async Task GenerateMillionPeopleAsync()
        {
            var people = FakeData.GenerateMillionPeople();

            await _dbSet.AddRangeAsync(people);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonDto>> GetUniqueFieldsAsync()
        {
            var uniquePerson = await _dbSet.GroupBy(p => new {p.FullName, p.BirthDate})
                .Select(g => g.First())
                .ToListAsync();

            var personDto = _mapper.Map<IEnumerable<Person>, IEnumerable <PersonDto>>(uniquePerson);

            return personDto;
        }
    }
}
