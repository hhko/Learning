using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Ch02_Step4_Akkatecture.Logic
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class SnackMachineId : Identity<SnackMachineId>
    {
        public SnackMachineId(string entityId)
            : base(entityId)
        {

        }
    }
}
