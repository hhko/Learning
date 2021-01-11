using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Step4_Akkatecture
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
