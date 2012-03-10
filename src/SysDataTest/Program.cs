namespace ConsoleApplication3 {
    using System;
    using System.Data.Linq;
    using System.Linq;
    using Zelda;
    using Zelda.SysData;

    class Program {
        static void Main(string[] args) {
            using (var context = new TestClassesDataContext()) {
                RepositoryTests(new DataContextRepository<Person>(context), () => context.SubmitChanges());
            }

            using (var context = new TestDbContext()) {
                RepositoryTests(new DbContextRepository<Person>(context), () => context.SaveChanges());
            }

            Console.ReadKey(true);
            Console.WriteLine("Press <ENTER>...");
        }

        private static void RepositoryTests(IRepository<Person> personRepo, Action commitChanges) {
            Console.WriteLine("Testing with '{0}' ", personRepo);

            var id = Guid.NewGuid();
            var person = new Person {
                Id = id,
                Name = id.ToString()
            };

            personRepo.Add(person);

            // Commit the changes depending on the provider
            commitChanges();

            var found = personRepo.Where(p => p.Id == id)
                .FirstOrDefault();

            Console.Write(found.Name);
        }
    }
}
