using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Step_01_Repository
{
    public class EntryPoint
    {
        private IUserRepository _userRepository;

        public EntryPoint(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(string userName)
        {
            // 사용자를 생성한다.
            var user = new User(
                new UserName(userName)
            );

            // 사용자명 중복 여부를 확인한다.
            var userService = new UserService(_userRepository);
            if (userService.Exists(user))
            {
                throw new Exception($"{userName}은 이미 존재하는 사용자명임");
            }

            // 생성된 사용자 데이터를 데이터베이스에 저장한다.
            _userRepository.Save(user);
        }
    }
}
