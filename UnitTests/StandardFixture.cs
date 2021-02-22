namespace UnitTests
{

    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Infrastructure.Authentication;
    using Infrastructure;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: "PtesAloneDatabase")
               .Options;

            this.Context = new DataContext(options);
            this.Context
                .Database
                .EnsureCreated();
            this.PetRepository = new PetRepository(this.Context);
            this.UnitOfWork = new UnitOfWork(Context);
            this.EntityFactory = new EntityFactory();
            this.TestUserService = new TestUserService();
        }

        public EntityFactory EntityFactory { get; }

        public DataContext Context { get; }

        public PetRepository PetRepository { get; }

        public UnitOfWork UnitOfWork { get; }

        public TestUserService TestUserService { get; }
    }
}