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
                if (diff.Days != 0)
                {
                    iReturn = iCount / diff.Days;
                }
            }
            else
            {
                throw new Exception("Current Date Range is invalid, End Date needs to be greater than Start Date");
            }
            return iReturn;
        }
    }
}