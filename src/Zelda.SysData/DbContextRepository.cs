namespace Zelda.SysData {
    using System.Data.Entity;
    using System.Linq;

    public class DbContextRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class {
        
        public DbContextRepository(DbContext context) {
            Context = context;
        }

        public override void Add(TEntity entity) {
            if (entity == null) return;
            EntitySet.Add(entity);
        }

        public override void Remove(TEntity entity) {
            if (entity == null) return;
            EntitySet.Remove(entity);
        }

        public override void Update(TEntity entity) {
            //Not needed
        }

        public override IQueryable<TEntity> Linq() {
            return EntitySet;
        }

        public DbContext Context { get; private set; }

        public IDbSet<TEntity> EntitySet {
            get { return Context.Set<TEntity>(); }
        }
    }
}