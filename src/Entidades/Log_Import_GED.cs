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
    
    public partial class Log_Import_GED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Log_Import_GED()
        {
            this.Deletar_NF_GED = new HashSet<Deletar_NF_GED>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDVISUAL { get; set; }
        public Nullable<int> agr_nr { get; set; }
        public string nf_nr { get; set; }
        public Nullable<int> ctrv_num { get; set; }
        public string vcl_placa { get; set; }
        public string forn_nome { get; set; }
        public string razao_social { get; set; }
        public string forn_cnpj { get; set; }
        public Nullable<decimal> vlr_bruto { get; set; }
        public Nullable<int> CTRV_CUS_NUM { get; set; }
        public string cus_name { get; set; }
        public string tp_pagamento { get; set; }
        public Nullable<int> fat_rebil_num { get; set; }
        public string rebil_sn { get; set; }
        public string mes_fat { get; set; }
        public Nullable<System.DateTime> dt_input { get; set; }
        public string usuario { get; set; }
        public Nullable<System.DateTime> dt_emiss_nf { get; set; }
        public Nullable<System.DateTime> dt_venc { get; set; }
        public string chave_acesso { get; set; }
        public int id_status_importacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deletar_NF_GED> Deletar_NF_GED { get; set; }
        public virtual Status_Importacao Status_Importacao { get; set; }
    }
}
