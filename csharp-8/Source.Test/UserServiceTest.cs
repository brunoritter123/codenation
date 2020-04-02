using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Codenation.Challenge
{
    public class UserServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_User_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("UserById");
            fakeContext.FillWith<User>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<User>().Find(x => x.Id == id);

                var service = new UserService(context);
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new UserIdComparer());
            }
        }

        [Theory]
        [InlineData("Velvet Grass", 1)]
        [InlineData("Progesterone", 1, 2, 3)]
        [InlineData("Temazepam", 1, 2, 3)]
        [InlineData("Stool Softener", 1, 2, 3, 4)]
        [InlineData("")]
        [InlineData("Nao Existe")]
        [InlineData(null)]
        public void FindByAccelerationNameTest_Return_Right(string nameAcceleration, params int[] idUsersExpected)
        {
            var fakeContext = new FakeContext("FindByAccelerationName");
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<User> expected = new List<User>();
                foreach (var id in idUsersExpected)
                {
                    expected.Add(fakeContext.GetFakeData<User>().Find(x => x.Id == id));
                }

                var service = new UserService(context);
                var actual = service.FindByAccelerationName(nameAcceleration);

                Assert.Equal(expected, actual, new UserIdComparer());
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 3)]
        [InlineData(3, 3, 4)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(7, 7)]
        [InlineData(8, 8)]
        [InlineData(9, 9)]
        [InlineData(10)]
        public void FindByCompanyIdTest_Return_Right(int companyId, params int[] idUsersExpected)
        {
            var fakeContext = new FakeContext("FindByCompanyId");
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<Candidate>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<User> expected = new List<User>();
                foreach (var id in idUsersExpected)
                {
                    expected.Add(fakeContext.GetFakeData<User>().Find(x => x.Id == id));
                }

                var service = new UserService(context);
                var actual = service.FindByCompanyId(companyId);

                Assert.Equal(expected, actual, new UserIdComparer());
            }
        }

        [Fact]
        public void Should_Add_New_User_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewUser");

            var fakeUser = new User();
            fakeUser.FullName = "full name";
            fakeUser.Email = "email";
            fakeUser.Nickname = "nickname";
            fakeUser.Password = "pass";
            fakeUser.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new UserService(context);
                var actual = service.Save(fakeUser);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(fakeUser.FullName, actual.FullName);
                Assert.Equal(fakeUser.Email, actual.Email);
                Assert.Equal(fakeUser.Nickname, actual.Nickname);
                Assert.Equal(fakeUser.Password, actual.Password);
                Assert.Equal(fakeUser.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update()
        {
            var fakeContext = new FakeContext("UpdateUser");
            int idUserUpdate = 1;
            fakeContext.FillWith<User>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<User>().Find(x => x.Id == idUserUpdate);
                expected.FullName = "full name";
                expected.Email = "email";
                expected.Nickname = "nickname";
                expected.Password = "pass";
                expected.CreatedAt = DateTime.Today;

                var service = new UserService(context);
                var actual = service.Save(expected);

                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal(expected.FullName, actual.FullName);
                Assert.Equal(expected.Email, actual.Email);
                Assert.Equal(expected.Nickname, actual.Nickname);
                Assert.Equal(expected.Password, actual.Password);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update_Id_Not_Exist()
        {
            var fakeContext = new FakeContext("UpdateUser");
            fakeContext.FillWith<User>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = new User();
                expected.Id = 999;
                expected.FullName = "full name";
                expected.Email = "email";
                expected.Nickname = "nickname";
                expected.Password = "pass";
                expected.CreatedAt = DateTime.Today;

                var service = new UserService(context); var actual = service.Save(expected);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(expected.FullName, actual.FullName);
                Assert.Equal(expected.Email, actual.Email);
                Assert.Equal(expected.Nickname, actual.Nickname);
                Assert.Equal(expected.Password, actual.Password);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }
    }
}
