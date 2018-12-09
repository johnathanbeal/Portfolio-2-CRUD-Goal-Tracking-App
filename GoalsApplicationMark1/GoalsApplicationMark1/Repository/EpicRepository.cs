using GoalsApplicationMark1.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GoalsApplicationMark1.Repository
{
    public class EpicRepository : IRepository<Epics>
    {
        private string connectionString;

        public EpicRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Epics epic)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO epics (epic, description, category, subcategory) VALUES (@epic, @description, @category, @subcategory)", epic);
            }
        }

        public IEnumerable<Epics> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Epics>("SELECT * FROM goals");
            }
        }

        public Epics FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Epics>("SELECT * FROM epics WHERE Id=@Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM epics where Id=@Id", new { Id = id });
            }
        }

        public void Update(Epics epic)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE epics SET epic = @epic, @description, @category, @subcategory", epic);
            }
        }
    }
}
