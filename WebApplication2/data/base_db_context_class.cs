using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;
using WebApplication2.model;

namespace WebApplication2.Data
{
    public class base_db_context_class : DbContext
    {
        public base_db_context_class(DbContextOptions<base_db_context_class> options) : base(options) { }
        public DbSet<my_model> mytable { get; set; }

    }
}