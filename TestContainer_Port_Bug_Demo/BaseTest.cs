using Testcontainers.PostgreSql;

namespace TestContainer_Port_Bug_Demo
{
    [TestFixture]
    public class BaseTest
    {
        protected PostgreSqlContainer _postgres;

        protected string _connectionString;


        [OneTimeSetUpAttribute]
        public virtual async Task OneTimeSetUpAttribute()
        {
            _postgres = new PostgreSqlBuilder()
                .WithImage("postgres:alpine")
                .WithPortBinding("3033", "5432") // Commenting this line out will let both tests pass.
                .Build();
            await _postgres.StartAsync();

            _connectionString = _postgres.GetConnectionString();
        }

        [OneTimeTearDownAttribute]
        public virtual async Task OneTimeTearDownAttribute()
        {
            await _postgres.DisposeAsync();
        }
    }
}