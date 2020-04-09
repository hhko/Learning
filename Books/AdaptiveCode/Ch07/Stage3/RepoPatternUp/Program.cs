using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 교육 목표
// - 인터페이스 분리를 통한 구체화: IRepository -> IWriteOnlyRepository, IReadOnlyRepository
// - 덜 구체적: 함수 출력, out 
// - 더 구체적: 함수 입력, in

namespace Lab_03_RepoPattern_Improved
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IRepository<Employee> employeeRepository
                = new SqlRepository<Employee>(new EmployeeDb()))
            {
                //
                // 더 구체적: 함수 입력, in
                //           IWriteOnlyRepository<in T>
                //
                AddEmployees(employeeRepository);
                //AddManagers(employeeRepository);

                //
                // 덜 구체적: 함수 출력, out
                //           IReadOnlyRepository<out T>
                //
                QueryEmployees(employeeRepository);
                QueryPeople(employeeRepository);
            }
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Employee { Name = "Chris" });
            employeeRepository.Commit();
        }

        //
        // 더 구체적
        //
        private static void AddManagers(IWriteOnlyRepository<Manager> employeeRepository)
        {
            // 목표: 컴파일러 에러를 기대한다.
            //employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Manager { Name = "Alex" });
            employeeRepository.Commit();
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine(employee.Name);
        }

        //
        // 덜 구체적
        //
        private static void QueryPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
