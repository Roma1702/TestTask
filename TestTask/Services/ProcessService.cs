using DataAccessLayer.DTO;
using DataAccessLayer.Interfaces;
using FluentValidation;
using TestTask.Interfaces;

namespace TestTask.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IValidator<ShortPersonDto> _validator;
        private readonly IPersonBinder _personBinder;
        private readonly IPersonRepository _personRepository;

        public ProcessService(IValidator<ShortPersonDto> validator,
            IPersonBinder personBinder,
            IPersonRepository personRepository)
        {
            _validator = validator;
            _personBinder = personBinder;
            _personRepository = personRepository;
        }

        public async Task Process(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter the command.");
                return;
            }

            switch (args[0])
            {
                case "1":
                    await _personRepository.CreateTable();
                    break;
                case "2":
                    if (args.Length != 4)
                    {
                        await Console.Out.WriteLineAsync("Please enter the full name, birth date and gender!");
                        return;
                    }

                    var shortPersonDto = _personBinder.BindPerson(args);

                    var personDto = _validator.Validate(shortPersonDto);

                    if (!personDto.IsValid)
                    {
                        foreach (var failure in personDto.Errors)
                        {
                            await Console.Out.WriteLineAsync("Property " + failure.PropertyName +
                                " failed validation. Error was: " + failure.ErrorMessage);
                            return;
                        }
                    }

                    await _personRepository.CreateAsync(shortPersonDto);
                    break;
                case "3":
                    var uniquePerson = await _personRepository.GetUniqueFields();

                    foreach(var person in uniquePerson)
                    {
                        await Console.Out.WriteLineAsync(person.ToString());
                    }
                    break;
                default:
                    Console.WriteLine("Undefined command.");
                    break;
            }
        }
    }
}
