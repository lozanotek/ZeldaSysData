namespace Zelda.SysData {
    using System.Data.Linq;
    using System.Linq;

    public class DataContextRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class {
        public DataContextRepository(DataContext context) {
            Context = context;
        }

        public override void Add(TEntity entity) {
            if (entity == null) return;
            EntityTable.InsertOnSubmit(entity);
        }

        public override void Remove(TEntity entity) {
            if (entity == null) return;
            EntityTable.DeleteOnSubmit(entity);
        }

        public override void Update(TEntity entity) {
            //Not needed            
        }

        public override IQueryable<TEntity> Linq() {
            return EntityTable;
        }

        public DataContext Context { get; set; }

        public Table<TEntity> EntityTable {
            get { return Context.GetTable<TEntity>(); }
        }
    }
}