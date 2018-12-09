using GoalsApplicationMark1.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Repository
{
    public class GoalCandidatesRepository : IRepository<GoalCandidates>
    {
        private string connectionString;

        public GoalCandidatesRepository(IConfiguration configuration)
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

        public void Add(GoalCandidates goalCandidate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO goalCandidates (goalcandidate,description, importance) VALUES (@goalCanidates, @description, @importance", goalCandidate);
            }
        }

        public IEnumerable<GoalCandidates> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<GoalCandidates>("SELECT * FROM goalcandidates");
            }
        }

        public GoalCandidates FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<GoalCandidates>("SELECT FROM goalcandidates WHERE Id=@Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM goalcandidates where Id=@Id", new { Id = id });
            }
        }

        public void Update(GoalCandidates goalCandidate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE goalcandidates SET goalCandidate = @GoalCandidate, description = @Description, importance = @Importance", goalCandidate);
            }
            
        }
    }
}
