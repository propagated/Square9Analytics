using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square9Analytics.Objects
{
    public class Objects
    {
        public class BatchSecurity
        {
            public List<BatchSecurityGroup> Groups { get; set; }
        }

        public class BatchSecurityGroup
        {

            public String UserGroup { get; set; }

            public String Connection { get; set; }

        }

    }
}
