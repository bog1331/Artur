using ConsoleApp3;
using Moq;

namespace TestProject1
{
    public class DataSet
    {
        public User InsertUser { set; get; }
        public bool Expected { set; get; }
        public bool MockExpected { set; get; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDbServiceLogin()
        {
            var dbService = new DbService();

            var result = dbService.Login(new User { Login = "Artem", Password = "qwe" });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDbServiceAddUser()
        {
            var dbService = new DbService();

            var result = dbService.AddUser(new User { Login = "Artem", Password = "qwe" });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUseCaseAddUser()
        {
            var DbMock = new Mock<IDb>();
            var useCase = new UseCase(DbMock.Object);

            DataSet[] dataSets = new DataSet[]
            {
                 new DataSet() {
                    InsertUser = new User() { Login = "Artem", Password="qwe" },
                    MockExpected = true,
                    Expected = true,
                 },

                 new DataSet()
                 {
                    InsertUser = new User() { Login="qw", Password="qwe"},
                    MockExpected = false,
                    Expected = false,

                 },
  
                new DataSet()
                {
                    InsertUser = new User() { Login="qwee", Password="qw"},
                    MockExpected = false,
                    Expected = false,
                }
            };

            foreach (var dataSet in dataSets)
            {
                var result = useCase.Add(dataSet.InsertUser);

                if (dataSet.MockExpected)
                    DbMock.Verify(db => db.AddUser(dataSet.InsertUser));

                Assert.AreEqual(dataSet.Expected, result);
            }
        }

        [TestMethod]
        public void TestUseCaseLogin()
        {
            var DbMock = new Mock<IDb>();
            var useCase = new UseCase(DbMock.Object);

            DataSet[] dataSets = new DataSet[]
            {
                 new DataSet() {
                    InsertUser = new User() { Login = "Artem", Password="qwe" },
                    Expected = true,
                 },

                 new DataSet()
                 {
                    InsertUser = new User() { Login="qw", Password="qwe"},
                    Expected = false,

                 },
            };

            foreach (var dataSet in dataSets)
            {
                DbMock.Setup(db => db.Login(dataSet.InsertUser)).Returns(dataSet.Expected);
                var result = useCase.Login(dataSet.InsertUser);


                DbMock.Verify(db => db.Login(dataSet.InsertUser));
                Assert.AreEqual(dataSet.Expected, result);
            }
        }
    }
}