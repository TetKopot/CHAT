using ChatApp.DataBase;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _ctx;
        public HomeController(AppDbContext ctx) => _ctx = ctx;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            _ctx.Chats.Add(new Chat
            {
                Name = name,
                Type = ChatType.Room
            });
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
