using AutoFixture;

namespace CustomerManagement.Application.Tests.Base
{
    public class BaseFixture
    {
        public readonly IFixture Fixture;

        public BaseFixture()
        {
            Fixture = new Fixture();
        }
    }
}
