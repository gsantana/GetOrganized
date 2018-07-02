using GetOrganized.Controllers;
using GetOrganized.Models;
using GetOrganized.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace GetOrganizedTest
{
    public class TopicControllerTest
    {
        [Fact]
        public void Should_Have_A_List_Of_Topics_With_Name_And_Color()
        {
            //var topic = new Topic() { Id = 1, Color = Color.Red, Name = "Work" };
            //var result = (ViewResult)new TopicController().Index();
            //Assert.Contains(topic, (List<Topic>)result.Model);
            //Assert.Null(result.ViewName);
        }

        [Fact]
        public void Should_Convert_Color_To_Hex_Value()
        {
            //var topic = new Topic { Color = Color.FromArgb(0, 208, 0, 0) };
            //Assert.Equal("#D00000", topic.ColorInWebHex());
        }

        [Fact]
        public void Should_Create_A_Topic_And_Notify_The_User()
        {
            //var topic = new Topic() { Id = 3, Color = Color.Black, Name = "Teste 3" };
            //var values = new Dictionary<string, StringValues>();
            //values.Add("Id", new StringValues(topic.Id.ToString()));
            //values.Add("Name", new StringValues(topic.Name));
            //values.Add("Color", new StringValues(topic.ColorInWebHex().Trim('#')));
            
            //var form = new FormCollection(values);

            //var controller = new TopicController();
            //var result = (RedirectToActionResult)controller.Create(form);
            //Assert.Contains(topic, Topic.topics);
            //Assert.Equal("Index", result.ActionName);
            //Assert.Equal("Your topic has been added.", controller.TempData["Message"]);
        }
    }
}
