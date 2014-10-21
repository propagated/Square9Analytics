using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Square9Analytics.Objects;

namespace Square9Analytics.DataAccess
{
    public class DataAnalytics
    {
        public List<AuditTable> getActions(DateTime startDate, DateTime endDate, AuditAction Action, string UserName = "No UserName")
        {
          
            try
            {
                string action;
                string userName;
                DateTime date;
                string sql = "";
                List<AuditTable> audittable = new List<AuditTable>();
                using (var sqlConnection = new SqlConnection("Data Source=(local)\\GETSMART;Initial Catalog=SmartSearch;Integrated Security=SSPI;MultipleActiveResultSets=true"))
                {
                    sqlConnection.Open();
                    if (UserName == "No UserName")
                    {
                        sql = "SELECT Action, Username, Date FROM ssAudit WHERE Date BETWEEN'" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + endDate.ToString("yyyy-MM-dd") + " 23:59:59.999' AND Action LIKE '%" + Action + "%'";
                    }
                    else
                    {
                        sql = "SELECT Action, Username, Date FROM ssAudit WHERE UserName LIKE '%" + UserName + "%' AND Date BETWEEN'" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + endDate.ToString("yyyy-MM-dd") + " 23:59:59.999' AND Action LIKE '%" + Action + "%'";
                    }
                    using (var command = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    action = Convert.ToString(reader["Action"]);
                                    userName = Convert.ToString (reader["Username"]);
                                    date = Convert.ToDateTime(reader["Date"]);
                                    audittable.Add(new AuditTable() { Date = (DateTime)date, Action = action.ToString(), UserName = userName.ToString() });
                                }
                           }
                        }
                       
                        sqlConnection.Close();
                    }
                    
                    return audittable;
                }

            catch(SqlException sqlEx)
            {
                throw(sqlEx);
            }

        }
    }
}