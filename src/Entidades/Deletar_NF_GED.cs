//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deletar_NF_GED
    {
        public int id { get; set; }
        public int id_log_import_ged { get; set; }
        public bool status { get; set; }
        public string mensagem_erro { get; set; }
    
        public virtual Log_Import_GED Log_Import_GED { get; set; }
    }
}
