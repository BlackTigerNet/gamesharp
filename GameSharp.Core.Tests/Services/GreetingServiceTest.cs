using GameSharp.Core.Repositories;
using GameSharpBackend.Services;
using System;
using Xunit;

namespace GameSharpBackendTests
{
    public class GreetingServiceTest
    {
        [Fact]
        public void ShouldAdd2And2()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void ShouldReturnGreeting()
        {
            var greetingService = new GreetingService();

            Assert.Equal("Hello, World!", greetingService.greet());
        }  
    }
}
