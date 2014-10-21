using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Square9Analytics.Objects;

namespace Square9Analytics.Logic
{
    public class Analytics
    {
        // Changing the Return type of this function to Float for more accuracy - Jon H. 9/11
        // Changed variable names due to the change from int to Float
        public float getActionCount(DateTime startDate, DateTime endDate, AuditAction action)
        {
            float fReturn = 0.0f;

            if (startDate < endDate)
            {
                DataAccess.DataAnalytics da = new DataAccess.DataAnalytics();

                float fCount = da.getActionCount(startDate, endDate, action);

                TimeSpan diff = endDate.Subtract(startDate);

                //can't divide by zero
                //Removed day>count check for future change to data type to allow decimals
                if (diff.Days > 0)
                {
                    fReturn = fCount / diff.Days;
                }
                else
                {
                    // New exception added in here for the next layer of checking - Jon H. 9/12
                    // Once the exception has been hit, going to set iReturn to 0 and break out of function
                    throw new Exception("The difference in days is less than 0");
                }
            }
            else
            {

                throw new Exception("Current Date Range is invalid, End Date needs to be greater than Start Date");
            }

            return fReturn;
        }

        public AuditLog getAuditLog(DateTime startDate, DateTime endDate, AuditAction auditAction, string UserName = "")
        {
            AuditLog auditLog = new AuditLog();
            List<string> users = new List<string>();
            string auditUser = UserName;

            // Create the DataTable, and then clear the DataTable so that it is empty.
            DataTable auditTable = new DataTable();
            auditTable.Clear();
            
            DataAccess.DataAnalytics da = new DataAccess.DataAnalytics();

            // Fill in the datable with what is returned from DataAccess
            //auditTable = da.getActions(startDate, endDate, userName);

            // This would parse through the table given from DA and then return it up to the API layer
            foreach (DataRow dr in auditTable.Rows)
            {
                users.Add(dr["Users"].ToString());
                auditLog.Log.Add(new AuditEntry() { Date = (DateTime)dr["Date"], Action = (AuditAction)dr["Action"] });
            }

            auditLog.Users = users.Distinct().ToList();

            /*
            if (auditUser.Length > 0)
            {
                foreach (DataRow d in auditTable.Rows)
                {
                    if (auditUser == d["Users"].ToString())
                    {
                        auditLog.Users.Add(d["Users"].ToString());
                    }
                }

                foreach (DataRow drow in auditTable.Rows)
                {
                    if (auditUser == drow["Users"].ToString())
                    {
                        auditLog.Log.Add(new AuditEntry() { Date = (DateTime)drow["Date"], Action = (AuditAction)drow["Action"] });
                    }
                }
            }
            */

            return auditLog;
        }
    }
}