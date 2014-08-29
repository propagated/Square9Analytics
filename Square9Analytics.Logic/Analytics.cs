﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Square9Analytics.Objects;

namespace Square9Analytics.Logic
{
    public class Analytics
    {
        public Int32 getActionCount(DateTime startDate, DateTime endDate, AuditEntry action)
        {
            Int32 iReturn = 0;

            if (startDate < endDate)
            {
                DataAccess.DataAnalytics da = new DataAccess.DataAnalytics();

                Int32 iCount = da.getActionCount(startDate, endDate, action);

                TimeSpan diff = endDate.Subtract(startDate);

                //can't divide by zero
                if (diff.Days != 0)
                {
                    if (iCount >= diff.Days)
                    {
                        iReturn = iCount / diff.Days;
                    }
                }
            }

            return iReturn;
        }

       
    }
}
