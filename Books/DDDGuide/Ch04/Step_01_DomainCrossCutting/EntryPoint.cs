using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Step_01_DomainCrossCutting
{
    public class EntryPoint
    {
        public void CreateUser(string userName)
        {
            // 사용자를 생성한다.
            var user = new User(
                new UserName(userName)
            );

            // 사용자명 중복 여부를 확인한다.
            var userService = new UserService();
            if (userService.Exists(user))
            {
                throw new Exception($"{userName}은 이미 존재하는 사용자명임");
            }

            //
            // 문제점
            //  - "생성된 사용자 데이터를 데이터베이스에 저장한다" 코드의 의도를 파악하기 위해서
            //    코드를 자세히 뜯어보아야 한다
            // 
            var connectionString = ConfigurationManager.ConnectionStrings["FooConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "INSERT INTO users (id, name) VALUES(@id, @name)";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                command.ExecuteNonQuery();
            }
        }
    }
}
