//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FicticiaSAWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Clientes
    {
        public int idCliente { get; set; }
        [DisplayName("Nombre Completo")]
        public string nombreCompleto { get; set; }
        [DisplayName("Identificación")]
        public int identificacion { get; set; }
        [DisplayName("Edad")]
        public int edad { get; set; }
        [DisplayName("Genero")]
        public int idGenero { get; set; }
        [DisplayName("Estado")]
        public bool estado { get; set; }
        [DisplayName("¿Maneja?")]
        public Nullable<bool> maneja { get; set; }
        [DisplayName("¿Usa lentes?")]
        public Nullable<bool> lentes { get; set; }
        [DisplayName("¿Otra enfermedad?")]
        public Nullable<bool> otraEnfermedad { get; set; }
        [DisplayName("Descripcion de Otra Enfermedad")]
        public string descripcionOtraEnfermedad { get; set; }
    
        public virtual Generos Generos { get; set; }
    }
}
