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
    
    public partial class DevolucionesPeliculas
    {
        public long IdDevolucion { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public long FKIdVenta { get; set; }
        public bool EstadoDevolucion { get; set; }
    
        public virtual VentaPelicula VentaPelicula { get; set; }
    }
}
