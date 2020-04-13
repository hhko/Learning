# How to Debug LINQ queries in C#
- https://michaelscodingspot.com/debug-linq-in-csharp/

## LINQ 확장 메서드
- LogLINQ 확장 메서드
  - ```foreach (var item in enumerable)```: 지연 처리를 위해 foreach 구문으로 순회한다.
  - ```string logName```: 로그 이름을 입력한다.
  - ```Func<T, string> printMethod```: LINQ 데이터(T)을 입력 받고, 로그를 반환한다.
- 구현  
  ```cs
    public static class LinqExt
    {
        public static IEnumerable<T> LogLINQ<T>(this IEnumerable<T> enumerable, string logName, Func<T, string> printMethod)
        {
    #if DEBUG
            int count = 0;
            foreach (var item in enumerable)
            {
                if (printMethod != null)
                {
                    Debug.WriteLine($"{logName}|item {count} = {printMethod(item)}");
                }
                count++;
                yield return item;
            }
            Debug.WriteLine($"{logName}|count = {count}");
    #else
            return enumerable;
    #endif
        }
    }
  ```	
- 적용 예
  ```cs
  var res = employees
        .LogLINQ("source", e=>e.Name)
        .Where(e => e.Gender == "Male")
        .LogLINQ("logWhere", e=>e.Name)
        .Take(3)
        .LogLINQ("logTake", e=>e.Name)
        .Where(e => e.Salary > avgSalary)
        .LogLINQ("logWhere2", e=>e.Name)
        .OrderBy(e => e.Age);  
  ```
- 로그 출력
  ![](./Images/LogLINQ.png)  
