using Npgsql;

namespace TestContainer_Port_Bug_Demo
{
    [TestFixture]
    public class TestClassTwo : BaseTest
    {

        // Helper method to verify connection
        private async Task<bool> VerifyConnection()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("SELECT 1", connection);
            var result = await command.ExecuteScalarAsync();

            return result != null;
        }

        [Test]
        public async Task DummyTestMethodTwo()
        {
            // Verify the connection by executing a simple query
            bool isConnected = await VerifyConnection();
            Assert.That(isConnected, Is.True, "Connection to PostgreSQL database failed.");
        }
    }
}
