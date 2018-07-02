using GetOrganized.Models;
using GetOrganized.Models.Domain;
using GetOrganized.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GetOrganizedTest.Repositories
{
    public class TodoRepositoryTest : RespositoryTestBase
    {
        public TodoRepository todoRepository { get; set; }

        public TodoRepositoryTest() : base()
        {
            todoRepository = new TodoRepository(session);
        }


        [Fact]
        public void Should_Create_And_Read()
        {
            var topic = Topic.topics.First();
            var topicRepo = new TopicRepository(session);
            topicRepo.SaveOrUpdate(topic);
            var topics = topicRepo.GetAll();
            Todo todo = new Todo { Completed = false, Outcome = "Teste", Title = "teste de dodo", Topic = topic };
            todoRepository.SaveOrUpdate(todo);
            session.Flush();
            var todos = todoRepository.GetAll();
            Assert.Contains(todo, todos);
            Assert.Single(todos);
        }
    }
}
