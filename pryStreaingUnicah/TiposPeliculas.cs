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
    
    public partial class TiposPeliculas
    {
        public TiposPeliculas()
        {
            this.Peliculas = new HashSet<Peliculas>();
        }
    
        public byte IdTipoPelicula { get; set; }
        public string DescripcionTipoPelicula { get; set; }
        public bool EstadoTipoPelicula { get; set; }
    
        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}
