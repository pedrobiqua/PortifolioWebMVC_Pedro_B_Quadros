using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

    public class WebContext : DbContext
    {
        public WebContext (DbContextOptions<WebContext> options)
            : base(options)
        {
        }
        public DbSet<WebMVC.Models.Portifolio>? Portifolio { get; set; }

        public DbSet<WebMVC.Models.Login>? Login { get; set; }
        
    }
