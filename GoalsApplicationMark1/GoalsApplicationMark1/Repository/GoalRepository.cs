using GoalsApplicationMark1.Models;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using GoalsApplicationMark1.Common;

namespace GoalsApplicationMark1.Repository
{
    public class GoalRepository : IRepository<GoalEntity>
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
        public void Add(GoalEntity goal)
        {
            using (IDbConnection dbConnection = Connection)
            {
                goal.CategoryString = goal.Category.ToString();
                goal.SubCategoryString = goal.SubCategory.ToString();
                goal.NanoCategoryString = goal.NanoCategory.ToString();
                goal.GoalTypeString = goal.GoalType.ToString();
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO goals (goal, description, ranking, deliverabledate, isspecific, ismeasureable, isachieveable, isrelevant, istimebound, goaltype, category, subcategory, nanocategory) VALUES (@goal, @description, @ranking, @deliverabledate, @isspecific, @ismeasureable, @isachieveable, @isrelevant, @istimebound, @goaltypeString, @categoryString, @subcategoryString, @nanocategoryString)", goal);
            }
        }
        
        public IEnumerable<GoalEntity> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<GoalEntity>("SELECT * FROM goals");
            }
        }

        public GoalEntity FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<GoalEntity>("SELECT * FROM goals WHERE Id=@Id", new { Id = id }).FirstOrDefault();
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

        public void Update(GoalEntity goal)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE goals SET goal = @Goal, description = @Description, ranking = @Ranking, deliverabledate = @Deliverabledate, isspecific = @Isspecific, ismeasureable = @Ismeasureable, isachieveable = @Isachieveable, isrelevant = @Isrelevant, istimebound = @Istimebound WHERE id = @Id", goal);
            }
        }
    }
}
 