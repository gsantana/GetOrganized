using GetOrganized.Controllers;
using GetOrganized.Models;
using GetOrganizedTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            Todo todo = new Todo() { Title = "Edited Todo" };
            var result = (RedirectToActionResult)new TodoController().Edit("Original title", todo);
            Assert.Contains(todo, Todo.ThingsToBoDone);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Should_Convert_A_thought_In_A_Todo()
        {
            var title = "Title test";
            var outcome = "Outcome teste";
            SessionSummary value = new SessionSummary();
            var sessionMock = new Mock<ISession>();

            sessionMock.Setup(_ => _.Set<SessionSummary>("SessionSummary", It.IsAny<SessionSummary>()))
                .Callback<string, SessionSummary>((k, v) => value = v);

            sessionMock.Setup(_ => _.Get<SessionSummary>("SessionSummary")).Returns(value);

            var rmContext = new Mock<HttpContext>();
            rmContext.Setup(x => x.Session).Returns(sessionMock.Object);

            var expectedTodo = new Todo() { Title = title, Completed = false, Topic = Topic.topics.First(), Outcome = outcome };
            var thought = new Thought() { Id = 1, Name = title, Topic = Topic.topics.First() };
            var sessionSummary = new SessionSummary();
            sessionSummary.todos.Add(expectedTodo);

            var controller = new TodoController();
            var controllerContext = new ControllerContext();
            controllerContext.HttpContext = rmContext.Object;
            controller.ControllerContext = controllerContext;
            var result = (RedirectToActionResult)controller.Convert(thought, outcome);

            Assert.Contains(expectedTodo, Todo.ThingsToBoDone);
            Assert.DoesNotContain(thought, Thought.Thoughts);
            Assert.Equal("Process", result.ActionName);
            Assert.Equal("Thought", result.ControllerName);
            Assert.Equal(sessionSummary, controller.HttpContext.Session.Get<SessionSummary>("SessionSymmary"));
        }

        [Fact]
        public void Shoudl_Be_Logged_In_To_Do_Anything_With_Todos()
        {
            TesteHelper.AssertIsAuthorized(typeof(TodoController));
        }

        [Fact]
        public void Should_Route_To_Edit_Page_With_Title()
        {
            //MyMvc.Routing()
            //    .ShouldMap(request => request.WithLocation("/Todo/Edit?title=Get-A-LOT-MORE-milk").WithMethod(HttpMethod.Get))
            //    .To<TodoController>(c => c.Edit("Get-A-LOT-MORE-milk"));
            RouteCollection routes = new RouteCollection();
            //Startup(routes);
            //var moqRequest = new Mock<HttpRequest>();
            //moqRequest.Setup(e => e.Path).Returns(@"~/Home/Index");
            //// Act
            //var moqContext = new Mock<HttpContext>();
            //RouteData routeData = routes.GetVirtualPath(moqContext.Object);
            //// Assert
            //Assert.NotNull(routeData);
            //Assert.Equal("Home", routeData.Values["controller"]);
            //Assert.Equal("Index", routeData.Values["action"]);
        }

        [Fact]
        public void Should_Set_Loggin_User_To_View_Data()
        {
            var nameUser = "Joao";
            var rmContext = new Mock<HttpContext>();
            var user = new GenericPrincipal(new GenericIdentity(nameUser), null);
            rmContext.Setup(x => x.User).Returns(user);

            var todoController = new TodoController();
            var controllerContext = new ControllerContext();
            controllerContext.HttpContext = rmContext.Object;
            todoController.ControllerContext = controllerContext;

            //todoController.HttpContext.User = new GenericPrincipal(new GenericIdentity("Jonathan"), null);

            var result = (ViewResult)todoController.Index();

            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameUser, result.ViewData["UserName"]);
        }

    }
}
