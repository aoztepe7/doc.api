namespace doc.api.Context
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public System.Data.IDbConnection CreateConnection() => new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
    }
}
