using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch02.LifecycleDI.Services
{
    public class GuidService
    {
        private readonly Guid ServiceGuid;

        public GuidService()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => 
            ServiceGuid.ToString();
    }
}
