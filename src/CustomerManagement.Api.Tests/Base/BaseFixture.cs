using AutoFixture;

namespace CustomerManagement.Api.Tests.Base
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
