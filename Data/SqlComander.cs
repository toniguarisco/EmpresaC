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


        public void CreateUsuario(Usuario usuario)
        {
            if (usuario == null) 
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.usuario.Add(usuario);

        }

        public void DeleteUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Remove(usuario);
        }

        public IEnumerable<Usuario> GetAppCommands()
        {
            var a = _context.usuario.ToList();
            return a;
        }

        public Usuario GetCommanderById(int id)
        {
            return _context.usuario.FirstOrDefault(p => p.id_usuario == id);
        }

        public bool saveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            //nothing
        }
    }
}
