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
    
    public partial class Pais
    {
        public Pais()
        {
            this.Estudios = new HashSet<Estudio>();
        }
    
        public byte IdPais { get; set; }
        public string NombrePais { get; set; }
        public bool EstadoPais { get; set; }
    
        public virtual ICollection<Estudio> Estudios { get; set; }
    }
}
