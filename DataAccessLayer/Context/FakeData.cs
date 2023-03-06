using DataAccessLayer.Entities;

namespace DataAccessLayer.Context
{
    public static class FakeData
    {
        static IEnumerable<string> surnames = new List<string>()
        {
            "Ferguson", "Foster", "Franklin", "Fleming", "Fitzgerald",
            "Ford", "Fisher", "Fitzpatrick", "Foley", "Fitzsimmons",
            "Flanagan", "Flynn", "Forbes", "Fontaine", "Fortier",
            "Fortune", "Fournier", "Fowler", "Fox", "Fraser", "Freeman",
            "French", "Frost", "Fry", "Fuller", "Fulton", "Funk", "Furman",
            "Fitzgibbons", "Farnsworth", "Friedman", "Foley", "Figueroa",
            "Finley", "Finnegan", "Fischer", "Flagg", "Flanders", "Flint",
            "Flood", "Flowers", "Flynt", "Foley", "Follett", "Fontenot",
            "Foote", "Forbes", "Forde", "Foss", "Fosse", "Fountain",
        };

        public static IEnumerable<Person> GenerateMillionPeople()
        {
            var faker = new Bogus.Faker<Person>()
                .RuleFor(u => u.Gender, f => f.PickRandom<Bogus.DataSets.Name.Gender>())
                .RuleFor(u => u.FullName, (f, u) => $"{f.Name.LastName(u.Gender)} {f.Name.FirstName(u.Gender)}")
                .RuleFor(u => u.BirthDate, f => f.Date.Past(50));

            var people = faker.GenerateLazy(1000000);

            return people!;
        }

        public static IEnumerable<Person> GenerateHundredPeople()
        {
            var faker = new Bogus.Faker<Person>()
                .RuleFor(u => u.Gender, Bogus.DataSets.Name.Gender.Male)
                .RuleFor(u => u.FullName, (f, u) => $"{f.PickRandom(surnames)} {f.Name.FirstName(u.Gender)}")
                .RuleFor(u => u.BirthDate, f => f.Date.Past(50));

            var people = faker.Generate(100);

            return people!;
        }
    }
}
