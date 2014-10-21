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
        public DataTable getActions(DateTime Date, string Users, AuditAction Action)
        {
            DataTable actionTable = new DataTable();
          
            try
            {
                using (var sqlConnection = new SqlConnection("Data Source=(local)\\GETSMART;Initial Catalog=SmartSearch;Integrated Security=SSPI;MultipleActiveResultSets=true"))
                {
                    sqlConnection.Open();
                    string sql = "SELECT Action, Username, Date FROM ssAudit";
                    using (var command = new SqlCommand(sql, sqlConnection))
                    {
                       using (SqlDataAdapter adapter = new SqlDataAdapter())
                           
                            {         
                                    adapter.SelectCommand = command;
                                    adapter.Fill(actionTable);                           
                            }
                        
                    }
                    sqlConnection.Close();
                }
                return actionTable;

            }
            catch(SqlException sqlEx)
            {
                throw(sqlEx);
            }

        }
    }
}