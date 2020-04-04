// 목표
// - RecomputeTotal 함수는 불순(Impure) 함수임을 확인한다.
//   > linesToDelete 입력 인자를 변경 시키기 때문이다.

using System.Collections.Generic;

namespace AvoidMutatingArguments.Stage1
{
    public class Impure
    {
        public decimal RecomputeTotal(Order order, List<OrderLine> linesToDelete)
        {
            var result = 0m;
            foreach (var line in order.OrderLines)
            {
                if (line.Quantity == 0) 
                    linesToDelete.Add(line);

                else 
                    result += line.Product.Price * line.Quantity;
            }
        
            return result;
        }
    }
}