using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace usb.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            //connectionString = "Server=(local); Database=MVVMLoginDb; Integrated Security=true";
            _connectionString = "Server=F1-LAPTOP-MPC\\SQLEXPRESS; Database=USB; Integrated Security=; Trusted_Connection=true; TrustServerCertificate=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
