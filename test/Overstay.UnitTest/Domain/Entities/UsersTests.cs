using System;
using Overstay.Domain.Entities.Users;
using Shouldly;
using Xunit;

namespace Overstay.UnitTest.Domain.Entities
{
    public class UsersTests
    {
        [Fact]
        public void Should_Create_Valid_User()
        {
            var user = new User(
                "John",
                "Doe",
                new Email("test@example.com"),
                new UserName("johndoe"),
                new Password("SecurePassword123")
            );

            user.FirstName.ShouldBe("John");
            user.LastName.ShouldBe("Doe");
            user.Email.Value.ShouldBe("test@example.com");
            user.UserName.Value.ShouldBe("johndoe");
            user.Password.Value.ShouldBe("SecurePassword123");
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_Email()
        {
            Should.Throw<ArgumentException>(() => new Email("invalid-email"));
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_Password()
        {
            Should.Throw<ArgumentException>(() => new Password("short"));
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_UserName()
        {
            Should.Throw<ArgumentException>(() => new UserName("ab"));
        }
    }
}
