using System.Collections.Generic;

namespace AvoidMutatingArguments
{
    public class Order
    {
        public IList<OrderLine> OrderLines { get; } = new List<OrderLine>();
    }
}