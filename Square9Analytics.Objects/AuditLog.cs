﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square9Analytics.Objects
{
    public class AuditLog
    {
        List<String> Users { get; set; }
        List<AuditEntry> Log { get; set; }
    }

    public class AuditEntry
    {
        DateTime Date { get; set; }
        AuditAction Action { get; set; }
    }
}
