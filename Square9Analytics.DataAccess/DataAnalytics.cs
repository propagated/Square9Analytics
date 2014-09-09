using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Square9Analytics.Objects;

namespace Square9Analytics.DataAccess
{
    public class DataAnalytics
    {
        public int getActionCount(DateTime startDate, DateTime endDate, AuditEntry action)
        {
            int actionCount = 0;
            using (var sqlConnection = new SqlConnection("Data Source=(local)\\GETSMART;Initial Catalog=SmartSearch;Integrated Security=SSPI;MultipleActiveResultSets=true"))
            {
                sqlConnection.Open();
                string sql = "SELECT Count(*) AS Count FROM ssAudit WHERE ACTION LIKE '%" + action + "%' AND Date BETWEEN'" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + endDate.ToString("yyyy-MM-dd") + " 23:59:59.999'";
                using (var command = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            actionCount = Convert.ToInt32(reader["Count"]);
                        }
                    }
                }
                sqlConnection.Close();

            }
           return actionCount; 
        }
    }
}
