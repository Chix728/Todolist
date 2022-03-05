using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todolist.Data.TodoService;
using Todolist.Models;

namespace Todolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoservice;
        public TodoController(ITodoService todoService)
        {
            _todoservice = todoService;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getTodos()
        {
            try
            {
                var todos = _todoservice.getTodos();
                return Ok(todos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult insertTodo(TodoListModel todo)
        {
            try
            {
                var todoItem = _todoservice.SaveTodo(todo);
                return Ok(todoItem);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getTodoById(TodoListModel todo)
        {
            try
            {
                var todoitem = _todoservice.getbyid(todo.Id);
                return Ok(todoitem);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("[action]")]
        public IActionResult deleteTodo(int id)
        {
            try
            {
                var todoitem = _todoservice.delete(id);
                return Ok(todoitem);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
