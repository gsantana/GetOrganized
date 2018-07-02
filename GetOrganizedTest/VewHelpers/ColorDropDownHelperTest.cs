using GetOrganized.Models;
using GetOrganized.Models.Domain;
using GetOrganized.VewHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace GetOrganizedTest.VewHelpers
{
    public class ColorDropDownHelperTest
    {
        [Fact]
        public void Should_Render_Colored_DropDown_Markup()
        {
            //var workTopic = new List<Topic> { new Topic {Id=1, Name="Work" , Color= Color.Red} };
            //Assert.Equal(
            //"<select id=\" Topic_Id\" " +
            //"name=\" Topic.Id\" style=\" background-color: transparent;\">" +
            //"<option style=\" color: white; background-color: Red\" " +
            //"value=\" 1\">Work</option></select>",
            //ColorDropDownHelper.Topic("Topic.Id", workTopic));
        }
    }
}
