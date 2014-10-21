using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square9Analytics.Objects
{
    public class AuditLog
    {
        public List<String> Users { get; set; }
        public List<AuditEntry> Log { get; set; }
    }

    public class AuditEntry
    {
        public DateTime Date { get; set; }
        public AuditAction Action { get; set; }
    }
    public class AuditTable
    {
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string UserName { get; set; }
    }
}
