using System;
using System.Collections.Generic;

namespace Square9Analytics.Objects
{
    public class AuditEntry
    {
        private String AuditLogEntry { get; set; }
        private AuditEntry(String auditString)
        {
            AuditLogEntry = auditString;
        }

        /// <summary>
        /// Returns the string as it appears in the ssAudit table for this AuditEntry type.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return AuditLogEntry;
        }

        //for each audit log entry, create a static object here returning an entry with the actual string in the db.
        public static AuditEntry DocumentIndexed { get { return new AuditEntry("Document Indexed"); } }
    }
}
