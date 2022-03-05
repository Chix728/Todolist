using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todolist.Models;

namespace Todolist.Data
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<TodoListModel> TodoLists { get; set; }
    }
}
