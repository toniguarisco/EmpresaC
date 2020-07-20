using ApiRestDesarrollo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Data
{
    public class CommanderContext:DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) :base(opt)
        {
        }

        public DbSet<Usuario> usuario { get; set; }
    }
}
