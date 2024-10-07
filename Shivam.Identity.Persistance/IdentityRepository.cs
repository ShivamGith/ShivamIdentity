using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Shivam.Identity.Persistance
{
    public class IdentityRepository
    {
        private readonly string _connectionString;

        public IdentityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                using (SqlConnection connection = new(_connectionString))
                {
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Add more methods to interact with the database here
    }
}
