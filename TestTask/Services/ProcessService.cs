using DataAccessLayer.DTO;
using DataAccessLayer.Interfaces;
using FluentValidation;
using System.Diagnostics;
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
                    await ExecuteTask1();
                    break;
                case "2":
                    await ExecuteTask2(args);
                    break;
                case "3":
                    await ExecuteTask3();
                    break;
                case "4":
                    await ExecuteTask4();
                    break;
                case "5":
                    await ExecuteTask5();
                    break;
                default:
                    Console.WriteLine("Undefined command.");
                    break;
            }
        }

        private async Task ExecuteTask1()
        {
            await _personRepository.CreateTable();
        }

        private async Task ExecuteTask2(string[] args)
        {
            if (args.Length != 4)
            {
                await Console.Out.WriteLineAsync("Please enter the full name, birth date and gender!");
                return;
            }
            try
            {
                var shortPersonDto = _personBinder.BindPerson(args);

                var personDto = _validator.Validate(shortPersonDto);

                if (!personDto.IsValid)
                {
                    foreach (var failure in personDto.Errors)
                    {
                        await Console.Out.WriteLineAsync("Property " + failure.PropertyName +
                            " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                    await _personRepository.CreateAsync(shortPersonDto);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        private async Task ExecuteTask3()
        {
            var uniquePeople = await _personRepository.GetUniqueFieldsAsync();

            foreach (var person in uniquePeople)
            {
                await Console.Out.WriteLineAsync(person.ToString());
            }
        }

        private async Task ExecuteTask4()
        {
            await _personRepository.GenerateMillionPeopleAsync();

            await _personRepository.GenerateHundredPeopleAsync();
        }

        private async Task ExecuteTask5()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var filteredPeople = await _personRepository.FindByConditionAsync();

            stopwatch.Stop();

            foreach (var person in filteredPeople)
            {
                await Console.Out.WriteLineAsync(person.ToString());
            }

            await Console.Out.WriteLineAsync($"Duration: {stopwatch.ElapsedMilliseconds / 1000.0} seconds");
        }
    }
}
