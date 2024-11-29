using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Config
{
    public class GlobalConfig
    {
        public static readonly string BASE_URL= "http://localhost:5173/api/v1";
        public static readonly string CONNECTION_STRING  = "Server=localhost;Database=InboundTourism;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
    }
}
