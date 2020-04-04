// 목표
// - RecomputeTotal 함수를 순수 함수로 변경한다.
//   > 변경 전: linesToDelete 입력 인자를 변경 시킨다.
//   > 변경 후: linesToDelete을 생성하여 반환한다.

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace AvoidMutatingArguments.Stage2
{
    public class PureDiscovery
    {
        [Pure]
        public (decimal, IEnumerable<OrderLine>) RecomputeTotal(Order order) =>
             (order.OrderLines.Sum(l => l.Product.Price * l.Quantity),
                order.OrderLines.Where(l => l.Quantity == 0));
    }
}
