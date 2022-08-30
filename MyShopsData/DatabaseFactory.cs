using Microsoft.Extensions.Logging;
using MyShopsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly string _connectionString = "Data Source = DINESH; Initial Catalog = MyShop;  Integrated Security=true";

        private IDbConnection _dbContext;
        public IDbConnection Get()
        {
            if (_dbContext == null)
            {
                try
                {
                    _dbContext = new SqlConnection(_connectionString);
                }
                catch (Exception ex)
                {
                }
            }
            return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
