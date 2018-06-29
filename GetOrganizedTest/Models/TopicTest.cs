using GetOrganized.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace GetOrganizedTest.Models
{
    public class TopicTest
    {
        [Fact]
        public void Should_Be_Equal_By_Value()
        {
            var topic = new Topic() { Id = 1, Color = Color.Red, Name = "Test" };
            var othertopic = new Topic() { Id = 1, Color = Color.Red, Name = "Test" };
            Assert.True(topic.Equals(othertopic));
        }

        [Fact]
        public void Shold_Not_Be_Equal_By_value()
        {
            var topic = new Topic() { Id = 1, Color = Color.Red, Name = "Test" };
            var othertopic = new Topic() { Id = 1, Color = Color.Blue, Name = "Test 2" };
            Assert.False(topic.Equals(othertopic));
        }

    }
}
