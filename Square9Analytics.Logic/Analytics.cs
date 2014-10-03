using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Square9Analytics.Objects;

namespace Square9Analytics.Logic
{
    public class Analytics
    {
        // Changing the Return type of this function to Float for more accuracy - Jon H. 9/11
        public float getActionCount(DateTime startDate, DateTime endDate, AuditEntry action)
        {
            float iReturn = 0.0f;

            if (startDate < endDate)
            {
                DataAccess.DataAnalytics da = new DataAccess.DataAnalytics();

                float iCount = da.getActionCount(startDate, endDate, action);

                TimeSpan diff = endDate.Subtract(startDate);

                //can't divide by zero
                //Removed day>count check for future change to data type to allow decimals
                if (diff.Days > 0)
                {
                    iReturn = iCount / diff.Days;
                }
                else
                {
                    // New exception added in here for the next layer of checking - Jon H. 9/12
                    // Once the exception has been hit, going to set iReturn to 0 and break out of function
                    throw new Exception("The difference in days is less than 0");
                    return iReturn;
                }
            }
            else
            {
                
                throw new Exception("Current Date Range is invalid, End Date needs to be greater than Start Date");
                return iReturn;
            }
            return iReturn;
<<<<<<< HEAD
        }    

        // New function to be able to return an object so that API can parse through it and display data
        public List<DataObject> getActionTable(DateTime startDate, DateTime endDate, AuditEntry action)
        {
            // Create a list to be able to store the data
            List<DataObject> objectList = new List<DataObject>();
            DataAccess.DataAnalytics da = new DataAccess.DataAnalytics();

            // Store the data gotten from DA and store it in a Temp variable
            DataTable dataTable = new DataTable();

            // This is just something temporary while I wait to get the function name that DA is using (if it's different)
            // This function is not 100% functional or tested until I can get data back from DA
            
            //dataTable = da.getActionTable( startDate, endDate, action );

            // Parse through the temp variable and store it into the list object
            foreach( DataRow dr in dataTable.Rows )
            {
                objectList.Add(new DataObject() { ID = (int)dr["ID"], Date = (DateTime)dr["Date Entered"], UserName = dr["UserName"].ToString() });
            }
            
            // Once the DataTable is parsed through, be able to return the list object up
            return objectList;
        }
=======
        }     
>>>>>>> parent of f0f944a... Adding in new function and new object
    }
}
