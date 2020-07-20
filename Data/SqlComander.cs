using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Data
{
    public class SqlComander : IcommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlComander(CommanderContext context)
        {
            _context = context;
        }


        public void CreateClass(Class usuario)
        {
            if (usuario == null) 
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Class.Add(usuario);

        }

        public void DeleteUsuario(Class usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Remove(usuario);
        }

        public IEnumerable<Class> GetAppCommands()
        {
            var a = _context.Class.ToList();
            return a;
        }

        public Class GetCommanderById(int id)
        {
            return _context.Class.FirstOrDefault(p => p.id == id);
        }

        public bool saveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateUsuario(Class usuario)
        {
            //nothing
        }
    }
}
