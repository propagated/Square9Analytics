using System;
using System.Collections.Generic;

namespace Square9Analytics.Objects
{
    public class AuditAction
    {
        private String AuditLogEntry { get; set; }
        private AuditAction(String auditString)
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

        /// <summary>
        /// Parses a db string into an AuditAction object
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public static AuditAction Parse(String Action)
        {
            return new AuditAction(Action);
        }

        //for each audit log entry, create a static object here returning an entry with the actual string in the db.
        public static AuditAction Indexed { get { return new AuditAction("Document Indexed"); } }
        public static AuditAction AnnotationUpdate { get { return new AuditAction("Document Annotation Data Updated"); } }
        public static AuditAction Emailed { get { return new AuditAction("Document Emailed"); } }
        public static AuditAction Printed { get { return new AuditAction("Document Printed"); } }
        public static AuditAction Deleted { get { return new AuditAction("Document Deleted"); } }

        
        
    }
}

