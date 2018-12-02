using GoalsApplicationMark1.Models;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;


namespace GoalsApplicationMark1.Repository
{
    public class GoalRepository : IRepository<Goals>
    {
        private string connectionString;

        public GoalRepository(IConfiguration configuration)
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
        public void Add(Goals goal)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO goals (goal, description, ranking, deliverabledate, isspecific, ismeasureable, isachieveable, isrelevant, istimebound) VALUES (@goal, @description, @ranking, @deliverabledate, @isspecific, @ismeasureable, @isachieveable, @isrelevant, @istimebound)", goal);
            }
        }

        public IEnumerable<Goals> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Goals>("SELECT * FROM goals");
            }
        }

        public Goals FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Goals>("DELETE FROM goals WHERE Id=@Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM goals where Id=@Id", new { Id = id });
            }
        }

        public void Update(Goals goal)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE goals SET goal = @Goal, description = @Description, ranking = @Ranking, deliverabledate = @Deliverabledate, isspecific = @Isspecific, ismeasureable = @Ismeasureable, isachieveable = @Isachieveable, isrelevant = @Isrelevant, istimebound = @Istimebound", goal);
            }
        }
    }
}
 