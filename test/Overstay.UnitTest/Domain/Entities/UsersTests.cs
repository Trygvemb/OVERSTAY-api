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
                new PersonName("John", "Doe"),
                new Email("test@example.com"),
                new UserName("johndoe"),
                new Password("SecurePassword123")
            );

            user.PersonName.FirstName.ShouldBe("John");
            user.PersonName.LastName.ShouldBe("Doe");
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

        [Fact]
        public void Should_Throw_Exception_For_Empty_Name()
        {
            Should.Throw<ArgumentNullException>(
                () =>
                    new User(
                        null,
                        new Email("test@example.com"),
                        new UserName("johndoe"),
                        new Password("SecurePassword123")
                    )
            );
        }
    }
}
