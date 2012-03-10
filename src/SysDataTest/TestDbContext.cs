namespace ConsoleApplication3 {
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class TestDbContext : DbContext {
        public TestDbContext()
            : base("ConsoleApplication3.Properties.Settings.TestConnectionString") {
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}