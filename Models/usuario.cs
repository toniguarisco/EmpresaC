using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacora = new HashSet<Bitacora>();
            Comercio = new HashSet<Comercio>();
            Contrasena = new HashSet<Contrasena>();
            Cuenta = new HashSet<Cuenta>();
            OperacionCuenta = new HashSet<OperacionCuenta>();
            OperacionTarjeta = new HashSet<OperacionTarjeta>();
            OperacionesMonedero = new HashSet<OperacionesMonedero>();
            PagoIdUsuarioReceptorNavigation = new HashSet<Pago>();
            PagoIdUsuarioSolicitanteNavigation = new HashSet<Pago>();
            ReintegroIdUsuarioReceptorNavigation = new HashSet<Reintegro>();
            ReintegroIdUsuarioSolicitanteNavigation = new HashSet<Reintegro>();
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int NumIdentificacion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Estatus { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdTipoIdentificacion { get; set; }

        public virtual TipoIdentificacion IdTipoIdentificacionNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        public virtual ICollection<Comercio> Comercio { get; set; }
        public virtual ICollection<Contrasena> Contrasena { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<OperacionCuenta> OperacionCuenta { get; set; }
        public virtual ICollection<OperacionTarjeta> OperacionTarjeta { get; set; }
        public virtual ICollection<OperacionesMonedero> OperacionesMonedero { get; set; }
        public virtual ICollection<Pago> PagoIdUsuarioReceptorNavigation { get; set; }
        public virtual ICollection<Pago> PagoIdUsuarioSolicitanteNavigation { get; set; }
        public virtual ICollection<Reintegro> ReintegroIdUsuarioReceptorNavigation { get; set; }
        public virtual ICollection<Reintegro> ReintegroIdUsuarioSolicitanteNavigation { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
