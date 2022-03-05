using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todolist.Models;

namespace Todolist.Data.TodoService
{
   public interface ITodoService
    {
        ///<summary>get list of all employees</summary>
        /// ///
        ///<returns>Todo list</returns>
        List<TodoListModel> getTodos();

        ///<summary>get employee by id</summary>
        /// ///
        ///<returns>Todo by id</returns>
        TodoListModel getbyid(int todoId);
        
        ///<summary>delete todo</summary>
        /// ///
        ///<returns>deleted todo</returns>
        ResponseModel delete(int id);
        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        ResponseModel SaveTodo(TodoListModel todo);


    }
}
