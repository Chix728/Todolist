
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todolist.Models;

namespace Todolist.Data.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _todocontext;
        public TodoService(TodoContext todoContext)
        {
            _todocontext = todoContext;
        }
        public ResponseModel delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                TodoListModel _todo = _todocontext.Find<TodoListModel>(id);
                if (_todo != null) 
                { 
                    _todocontext.Remove<TodoListModel>(_todo);
                    _todocontext.SaveChangesAsync();
                    response.message = "Todo removed succesfully";
                }
                else
                {
                    response.isSuccess = false;
                    response.message = "Todo Not Found";
                }


            }
            catch(Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        public List<TodoListModel> getTodos()
        {
            List<TodoListModel> todolist;
            try
            {
                todolist = _todocontext.Set<TodoListModel>().ToList();
                return todolist;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public TodoListModel getbyid(int todoId)
        {
            TodoListModel todo;
            try
            {
                todo = _todocontext.Find<TodoListModel>(todoId);
                return todo;
            }
            catch (Exception) { throw; }
        }
       
        public ResponseModel SaveTodo(TodoListModel todo)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                TodoListModel checkTodo = _todocontext.Find<TodoListModel>(todo.Id);
                if(checkTodo != null)
                {
                    _todocontext.Update<TodoListModel>(todo);
                    response.message = "Updated Successfully !!";
                    
                }
                else
                {
                    _todocontext.Add<TodoListModel>(todo);
                    response.message = "Added Successfully!";
                   
                }
                _todocontext.SaveChangesAsync();
                response.isSuccess = true;


            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }
    }
}
