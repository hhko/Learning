using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Step_01_DomainCrossCutting
{
    public class UserService
    {
        public bool Exists(User user)
        {
            //
            // 문제점 
            //   - 데이터베이스는 도메인 객체가 아니다.
            //   - 데이터베이스를 직접 접근하고 있다.
            //          
            var connectionString = ConfigurationManager.ConnectionStrings["FooConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                using (var reader = command.ExecuteReader())
                {
                    var exist = reader.Read();
                    return exist;
                }
            }

            return false;
        }
    }
}
