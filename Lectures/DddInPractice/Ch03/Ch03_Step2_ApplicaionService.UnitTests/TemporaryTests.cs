using NHibernate;
using System;
using Xunit;

namespace Ch03_Step2_ApplicaionService.UnitTests
{
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");

            using (ISession session = SessionFactory.OpenSession())
            {
                long id = 1;
                var snackMachine = session.Get<SnackMachine>(id);
            }
        }
    }
}
