using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07_Step1_DomainEvent.Management
{
    public static class HeadOfficeInstance
    {
        private const long HeadOfficeId = 1;

        public static HeadOffice Instance { get; private set; }

        public static void Init()
        {
            var repository = new HeadOfficeRepository();
            Instance = repository.GetById(HeadOfficeId);
        }
    }
}
