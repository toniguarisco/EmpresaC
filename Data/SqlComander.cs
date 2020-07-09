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

        public void CreateUsuario(usuario usuario)
        {
            if (usuario == null) 
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.usuario.Add(usuario);

        }

        public void DeleteUsuario(usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Remove(usuario);
        }

        public IEnumerable<usuario> GetAppCommands()
        {
            return _context.usuario.ToList();
        }

        public usuario GetCommanderById(int id)
        {
            return _context.usuario.FirstOrDefault(p => p.id == id);
        }

        public bool saveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateUsuario(usuario usuario)
        {
            //nothing
        }
    }
}
