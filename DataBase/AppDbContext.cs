using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChatApp.DataBase
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public Microsoft.EntityFrameworkCore.DbSet<Chat> Chats { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Message> Messages { get; set; }
    }
    
}
