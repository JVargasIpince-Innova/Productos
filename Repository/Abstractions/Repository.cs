using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;

namespace Repository.Abstractions
{
    public abstract class Repository
    {
        private readonly IConfiguration _configuration;
        protected readonly string _connectionString;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;            
            
            var enviroment = _configuration.GetSection("env").Value;

            _connectionString = _configuration.GetConnectionString(enviroment);
        }
    }
}
