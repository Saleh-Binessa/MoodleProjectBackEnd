
using System;
using System.Collections.Generic;
using System.Linq;

public class TodoService
{
    private static readonly List<TodoItem> DummyData = new List<TodoItem>
    {
        new TodoItem { Id = 1, Description = "IOS", Name = "Task2" },
        new TodoItem { Id = 2, Description = "Java Springboot ", Name = "Task2" }
    };

    public List<TodoItem> GetTodosForDate(DateTime date)
    {
        return DummyData;
    }
}
