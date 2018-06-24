using GetOrganized.Controllers;
using GetOrganized.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace GetOrganizedTest
{
    public class TodoControllerTest
    {
        public TodoControllerTest()
        {
            Todo.ThingsToBoDone = new List<Todo>() {
                new Todo() { Title = "Get Milk", Completed = false},
                new Todo() { Title = "Bringg Home Bacon", Completed = true}
            };
        }

        [Fact]
        public void Should_display_A_List_Of_Todo_Items()
        {
            var viewResult = (ViewResult)new TodoController().Index();
            Assert.Equal(Todo.ThingsToBoDone, viewResult.Model);
        }


        [Fact]
        public void Should_Load_Create_View()
        {
            var viewResult = (ViewResult)new TodoController().Create();
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Should_Add_Todo_Item()
        {
            Todo todo = new Todo() { Completed = false, Title = "teste 3" };
            var result = (RedirectToActionResult)new TodoController().Create(todo);
            Assert.Equal(3, Todo.ThingsToBoDone.Count);
            Assert.Contains(todo, Todo.ThingsToBoDone);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Should_Delete_A_Todo()
        {
            Todo todo = Todo.ThingsToBoDone[0];
            var result = (RedirectToActionResult)new TodoController().Delete(todo.Title);
            Assert.DoesNotContain(todo, Todo.ThingsToBoDone);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Should_Load_A_Todo_For_Editing()
        {
            Todo todo = Todo.ThingsToBoDone[0];
            var result = (ViewResult)new TodoController().Edit(todo.Title);
            Assert.Equal(todo, result.Model);
            Assert.Null(result.ViewName);
        }


        [Fact]
        public void Should_Edit_Todo_Item()
        {
            Todo todo = new Todo() { Title = "Edited Todo"};
            var result = (RedirectToActionResult)new TodoController().Edit("Original title", todo);
            Assert.Contains(todo, Todo.ThingsToBoDone);
            Assert.Equal("Index", result.ActionName);
        }

    }
}
