//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pryStreaingUnicah
{
    using System;
    using System.Collections.Generic;
    
    public partial class Modulos
    {
        public Modulos()
        {
            this.PerfilModulo = new HashSet<PerfilModulo>();
            this.Perfiles = new HashSet<Perfiles>();
        }
    
        public short IdModulos { get; set; }
        public string DescripcionModulo { get; set; }
        public bool EstadoModulo { get; set; }
        public short FKModuloPrincipal { get; set; }
    
        public virtual ModuloPrincipal ModuloPrincipal { get; set; }
        public virtual ICollection<PerfilModulo> PerfilModulo { get; set; }
        public virtual ICollection<Perfiles> Perfiles { get; set; }
    }
}
