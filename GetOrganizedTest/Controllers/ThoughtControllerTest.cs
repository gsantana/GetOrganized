using GetOrganized.Controllers;
using GetOrganized.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Xunit;

namespace GetOrganizedTest.Controllers
{
    public class ThoughtControllerTest
    {
        [Fact]
        public void Should_List_Thoughts()
        {
            var result = (ViewResult) new ThoughtController().Index();
            Assert.Equal(Thought.Thoughts, result.Model);
        }

        [Fact]
        public void Should_Provide_A_List_Of_Topic_For_Creating_A_New_Thought()
        {
            var list = Topic.topics.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            var result = (ViewResult)new ThoughtController().Create();
            var item = ((List<SelectListItem>)result.ViewData["Topics"])[0];
            Assert.Equal(item.Text, list[0].Text);
            Assert.Equal(item.Value, list[0].Value);
        }

        [Fact]
        public void Shold_Display_Frist_thought_When_Processing_thoughts()
        {
            var thought = Thought.Thoughts.First();
            var result = (ViewResult)new ThoughtController().Process();

        }
    }
}
